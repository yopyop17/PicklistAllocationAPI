using Microsoft.EntityFrameworkCore;
using PickListAllocation.Models;

namespace PickListAllocation.Data
{
    public class PicklistContext(DbContextOptions<PicklistContext> options) : DbContext(options)
    {
        public DbSet<Clubs> Clubs { get; set; }
    }
}
