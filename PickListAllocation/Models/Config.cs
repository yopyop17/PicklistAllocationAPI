namespace PickListAllocation.Models
{
    public class Config
    {

        #region Mapper
        public static void SetMapping(IServiceCollection service)
        {
            service.AddAutoMapper(typeof(MappingProfile));
        }
        #endregion
    }
}
