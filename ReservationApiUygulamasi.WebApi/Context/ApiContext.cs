using Microsoft.EntityFrameworkCore;
using ReservationApiUygulamasi.EL.ApiModels;

namespace ReservationApiUygulamasi.WebApi.Context
{
    public class ApiContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-J60E0B5\\ATABEY;Database=PEN;User Id=sa;Password=1234;TrustServerCertificate=True;");
        }

        public DbSet<ProductDto> ProductDto { get; set; }
        public DbSet<ReservationDto> ReservationDto { get; set; }
        public DbSet<UserDto> UserDto { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ReservationDto>().HasKey(x => x.ProductRef);
        }
    }
}