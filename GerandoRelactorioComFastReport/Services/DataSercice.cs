using GerandoRelactorioComFastReport.Context;
using GerandoRelactorioComFastReport.Models;

namespace GerandoRelactorioComFastReport.Services
{
    public class DataSercice : IDataSercice
    {
        private readonly AppDbContext _context;

        public DataSercice(AppDbContext context)
        {
            _context = context;
        }

        public List<Category> GetCategories()
        {
            var cat = _context.Categories.ToList();

            return cat;
        }

        public List<Product> GetProducts()
        {
            var products = _context.Products.ToList();

            return products;
        }
    }
}
