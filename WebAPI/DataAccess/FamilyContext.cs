using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI.DataAccess
{
    public class FamilyContext : DbContext
    {        public DbSet<Family> Families { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            // name of database
            optionsBuilder.UseSqlite("Data Source = families.db");
        }
    }
}