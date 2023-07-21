using GerandoRelactorioComFastReport.Models;
using Microsoft.EntityFrameworkCore;

namespace GerandoRelactorioComFastReport.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
    }

}
