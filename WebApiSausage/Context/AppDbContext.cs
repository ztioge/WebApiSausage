using Microsoft.EntityFrameworkCore;
using WebApiSausage.Models;

namespace WebApiSausage.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)  

        {
            
        }

        public DbSet<Sausage> Sausages { get; set; }
    }
}
