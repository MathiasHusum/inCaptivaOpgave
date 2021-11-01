using ASP.NETCoreWebApplication.Entities;
using Microsoft.EntityFrameworkCore;

namespace ASP.NETCoreWebApplication.DAL
{
    public class InCaptivaContext : DbContext 
    {
        public InCaptivaContext() { }

        public InCaptivaContext(DbContextOptions options) : base(options)
        {
            
        }
        
        public DbSet<Opgave> Opgaver { get; set; }
        public DbSet<Medarbejder> Medarbejdere { get; set; }
        public DbSet<Vagt> Vagter { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Vagt>(entity =>
            {
                entity.HasOne(d => d.Medarbejder).WithMany(
                    p => p.Vagter).HasForeignKey(d => d.VagtId);
            });
        }

    }
}