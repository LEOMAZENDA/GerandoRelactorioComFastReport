using FastReport.Data;
using FastReport.Export.PdfSimple;
using FastReport.Web;
using GerandoRelactorioComFastReport.Models;
using GerandoRelactorioComFastReport.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GerandoRelactorioComFastReport.Controllers
{
    public class HomeController : Controller
    {
        public readonly IWebHostEnvironment _webHostEnv;
        private readonly IDataSercice _dataService;
        private IConfiguration _conficuration;

        public HomeController(IWebHostEnvironment webHostEnv,
            IDataSercice productService)
        {
            _webHostEnv = webHostEnv;
            _dataService = productService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }


        [Route("ProductsCategory")]
        public IActionResult ProductsCategory()
        {
            //criamos uma instancia do objeto webreport
            var webReport = new WebReport();

            // Obtemos uma instância do objeto MsSqlDataConnection
            // e definimos a string de conexão para o banco de dados nele
            var mssqlDataConnection = new MsSqlDataConnection();

            webReport.Report.Dictionary.Connections.Add(mssqlDataConnection);

            //carregamos o relatório criado na pasta reports
            webReport.Report.Load(Path.Combine(_webHostEnv.ContentRootPath, "wwwroot/reports", "ProductByCategory.frx"));

            //obtemos os dados para categorias e products
            var categories = HelperFastReport.GetTable(_dataService.GetCategories(), "Categories");
            var products = HelperFastReport.GetTable(_dataService.GetProducts(), "Products");

            //registramos as fontes de dados 
            webReport.Report.RegisterData(categories, "Categories");
            webReport.Report.RegisterData(products, "Products");

            //exibirmos o relatorio
            return View(webReport);
        }



        [Route("ProductsCategoryPdf")]
        public IActionResult ProductsCategoryPdf()
        {
            var webReport = new WebReport();
            var mssqlDataConnection = new MsSqlDataConnection();

            webReport.Report.Dictionary.Connections.Add(mssqlDataConnection);
            webReport.Report.Load(Path.Combine(_webHostEnv.ContentRootPath, "wwwroot/reports", "ProductByCategory.frx"));

            var categories = HelperFastReport.GetTable(_dataService.GetCategories(), "Categories");
            var products = HelperFastReport.GetTable(_dataService.GetProducts(), "Products");

            webReport.Report.RegisterData(categories, "Categories");
            webReport.Report.RegisterData(products, "Products");

            webReport.Report.Prepare();

            Stream stream = new MemoryStream();
            webReport.Report.Export(new PDFSimpleExport(), stream);
            stream.Position = 0;

            // retorna o stream no navegador
            return File(stream, "application/zip", "ProductsCategory.pdf");

        }
    }
}