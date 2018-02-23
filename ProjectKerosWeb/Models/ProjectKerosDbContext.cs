using Microsoft.EntityFrameworkCore;

namespace ProjectKerosWeb.Models
{
    public partial class ProjectKerosDbContext : DbContext
    {
        public virtual DbSet<UserModel> UserModel { get; set; }

        public ProjectKerosDbContext(DbContextOptions<ProjectKerosDbContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserModel>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Address)
                    .HasColumnName("address")
                    .HasMaxLength(50);

                entity.Property(e => e.Age).HasColumnName("age");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(30);
            });
        }
    }
}