using Microsoft.EntityFrameworkCore;
using ReservationApiUygulamasi.EL.ApiModels;
using ReservationApiUygulamasi.EL.TabelModels;

namespace ReservationApiUygulamasi.WebApi.Context
{
    public class ApiContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-J60E0B5\\ATABEY;Database=PEN;User Id=sa;Password=1234;TrustServerCertificate=True;");
        }

        public DbSet<ProductDto>? ProductDto { get; set; }
        public DbSet<ReservationDto>? ReservationDto { get; set; }
        public DbSet<UserDto>? UserDto { get; set; }
        public DbSet<Log> Logs { get; set; } = null!;

		protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ReservationDto>().HasKey(x => x.Id); //Tablonun primary key'ini YAZ !
            modelBuilder.Entity<ProductDto>().HasKey(x => x.Id); //Eğer Id ise yazmaya gerek yok ama eğer ProductID gibi farklı bir prımarykey olsaydı KESINLIKKLE BELİRTİLMELi !
			modelBuilder.Entity<UserDto>().HasKey(x => x.ID);
            modelBuilder.Entity<Log>().HasKey(x => x.Id);
		}
    }
}