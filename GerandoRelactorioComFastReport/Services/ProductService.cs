using GerandoRelactorioComFastReport.Context;
using GerandoRelactorioComFastReport.Models;

namespace GerandoRelactorioComFastReport.Services
{
    public class ProductService : IProductSercice
    {
        private readonly AppDbContext _context;

        public ProductService(AppDbContext context)
        {
            _context = context;
        }

        public List<Product> GetProducts()
        {
            var products = _context.Products.ToList();

            return products;
        }
    }
}
