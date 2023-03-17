using Microsoft.EntityFrameworkCore;
using ZooManagement.Models.Database;

namespace ZooManagement
{
    public class ZooManagementDbContext : DbContext
    {
        public ZooManagementDbContext(DbContextOptions<ZooManagementDbContext> options) : base(options) {}
        
        public DbSet<AnimalModel> Animals { get; set; }
        public DbSet<SpeciesModel> Species { get; set; }
        public DbSet<ClassificationModel> Classifications { get; set; }
        public DbSet<EnclosureModel> Enclosures{get;set;}
    }
}