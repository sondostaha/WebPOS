using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Reflection.Emit;
using WebPOS.Models;

namespace WebPOS.Data
{
    public class AppDbContext : IdentityDbContext 
    {
        public AppDbContext(DbContextOptions<AppDbContext> option) :base(option) 
        {
            
        }
        public DbSet<Branches> Branches { get; set; }
        public DbSet<Users> users { get; set; }
        public DbSet<Shifts> shifts { get; set; }
        public DbSet<Areas> areas { get; set; }
        public DbSet<Customers> customers { get; set; }
        public DbSet<CustomerPhones> customerPhones { get; set; }
        public DbSet<CustomerAddress> customerAddress { get; set; }
        public DbSet<SystemLog> systemLogs { get; set; }
        public DbSet<Category> categories { get; set; }
        public DbSet<Items> items { get; set; }
        public DbSet<Ingrediants> ingrediants { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)

        {
            
            base.OnModelCreating(builder);

            builder.Entity<Users>()
                .Property(x => x.Type)
                .IsRequired(true)
                .HasConversion(new EnumToStringConverter<Models.Type>());
            //.HasDefaultValueSql<Models.Type>("Userr");
            builder.Entity<Users>()
                .Property(c => c.Status)
                .HasDefaultValueSql("1");
            builder.Entity<Branches>()
                .Property(x => x.HasSeats)
           .HasDefaultValueSql("0");

            builder.Entity<Branches>()
           .Property(x => x.DispatcherAcceptRequired)
            .HasDefaultValueSql("1");

            builder.Entity<Shifts>()
                .Property(x => x.Status)
                //.HasDefaultValueSql("Active")
                .HasConversion(new EnumToStringConverter<Status>());
            builder.Entity<Shifts>()
                .Property(x => x.CreatedAt).HasDefaultValueSql("GETDATE()");
            builder.Entity<Shifts>()
                .Property(x => x.ShiftID)
                .HasComputedColumnSql("CONCAT(SUBSTRING(CAST(YEAR(CreatedAt) AS CHAR(10)), 3, 2), SUBSTRING(CAST(MONTH(CreatedAt) AS CHAR(2)), 1, 2), SUBSTRING(CAST(DAY(CreatedAt) AS CHAR(2)), 1, 2), Location, User)");

            builder.Entity<Areas>()
                .Property(x => x.CreatedAt)
                .HasDefaultValueSql("GETDATE()");
            builder.Entity<Customers>()
                .Property(x => x.CreatedAt)
                .HasDefaultValueSql("GETDATE()");
            builder.Entity<CustomerPhones>()
                .Property(x => x.CreatedAt)
                .HasDefaultValueSql("GETDATE()");
            builder.Entity<CustomerAddress>()
                .Property(x => x.CreatedAt)
                .HasDefaultValueSql("GETDATE()");
            builder.Entity<Category>()
               .Property(x => x.CreatedAt)
               .HasDefaultValueSql("GETDATE()");
            builder.Entity<Items>()
                .Property(x => x.ReadyByDefault)
                .HasConversion(new EnumToStringConverter<ReadyByDefault>());
            builder.Entity<Items>()
               .Property(x => x.CreatedAt)
               .HasDefaultValueSql("GETDATE()");
            builder.Entity<ItemIngrediants>()
               .Property(x => x.CreatedAt)
               .HasDefaultValueSql("GETDATE()");

            builder.Entity<Branches>()
                .HasData(
                new Branches() {Id =1 ,Title = "Cirnckle1", Address = "6th of october", HasSeats = 1, DispatcherAcceptRequired = 1 },
                new Branches() {Id =2, Title = "Cirnckle2", Address = "Faiyum", HasSeats = 1, DispatcherAcceptRequired = 1 }

                );
            builder.Entity<SystemLog>()
                .Property(x => x.CreatedAt)
                .HasDefaultValueSql("GETDATE()");
        }
    }
}
