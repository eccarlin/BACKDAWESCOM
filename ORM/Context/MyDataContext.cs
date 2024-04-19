using Microsoft.EntityFrameworkCore;
using ORM.Model;
using System.ComponentModel;

namespace ORM.Context
{
    public class MyDataContext:DbContext
    {
        public DbSet<Users> users { set; get; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseMySQL("server=localhost;database=ormabril;user=ormejemplo;password=123456");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Users>(entity => {
                entity.HasKey(e => e.Username);
                entity.Property(e => e.Password);
                entity.Property(e => e.DateLogin);
            });
        }
    }
}
