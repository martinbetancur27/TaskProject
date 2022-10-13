using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Task.Core.Entities;
using Task.Infrastructure.Identity;

namespace Task.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<ImportantTask> ImportantTasks { get; set; }

        public DbSet<UrgentTask> UrgentTasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ImportantTask>(important =>
            {
                important.ToTable("ImportantTask");
                important.HasKey(p => p.Id);
                important.Property(p => p.Id).ValueGeneratedOnAdd();
                important.Property(p => p.Description).IsRequired();
                important.Property(p => p.EndDate).IsRequired();
                important.HasOne<ApplicationUser>().WithMany(u => u.ImportantTasks).HasForeignKey(i => i.IdUser);
            });

            modelBuilder.Entity<UrgentTask>(urgent =>
            {
                urgent.ToTable("UrgentTask");
                urgent.HasKey(p => p.Id);
                urgent.Property(p => p.Id).ValueGeneratedOnAdd();
                urgent.Property(p => p.Description).IsRequired();
                urgent.Property(p => p.EndDate).IsRequired();
                urgent.HasOne<ApplicationUser>().WithMany(u => u.UrgentTasks).HasForeignKey(i => i.IdUser);
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}