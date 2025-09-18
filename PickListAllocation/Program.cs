using Azure;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Serialization;
using PickListAllocation.Data;
using PickListAllocation.Models;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Db Connection.
builder.Services.AddDbContext<PicklistContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DatabaseConnection")
    ));

builder.Services.AddControllers()
    .AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore)
    .AddJsonOptions(options => options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles)
    .AddNewtonsoftJson(options => options.SerializerSettings.ContractResolver = new DefaultContractResolver());

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "Web Api",
        Version = "v1",
    });

    // Add this line to modify the controller names in Swagger
    options.CustomSchemaIds(type => type.FullName);
});

//IGNORE NULL VALUE
builder.Services.AddControllers().AddNewtonsoftJson(options =>
{
    options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
    options.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
});
builder.Services.AddMvc(options => options.EnableEndpointRouting = false)
.AddJsonOptions(opt =>
{
    opt.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
});
Config.SetMapping(builder.Services);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowOrigin", policy =>
    {
        policy.AllowAnyHeader()
                .AllowAnyMethod() //allow any http methods
                .SetIsOriginAllowed(isOriginAllowed: _ => true) //no restriction in any domain
                .AllowCredentials();
    });
});


builder.Services.AddControllersWithViews().AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore).AddNewtonsoftJson(options => options.SerializerSettings.ContractResolver = new DefaultContractResolver());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Web Api V1");
    });
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();


app.Run();
