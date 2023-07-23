using GerandoRelactorioComFastReport.Models;

namespace GerandoRelactorioComFastReport.Services
{
    public interface IDataSercice
    {
        List<Product> GetProducts();
        List<Category> GetCategories();
    }
}
