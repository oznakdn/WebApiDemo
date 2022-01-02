using Microsoft.EntityFrameworkCore;
using WebApiDemo.Entities;

namespace WebApiDemo.DataAccess.Concrete
{
    public class NorthwindContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-9DAI51M;Integrated Security=True;database=Northwind");
        }

        public DbSet<Product> Products { get; set; }
    }
}
