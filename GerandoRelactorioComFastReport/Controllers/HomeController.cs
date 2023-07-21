using FastReport.Export.PdfSimple;
using GerandoRelactorioComFastReport.Models;
using GerandoRelactorioComFastReport.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GerandoRelactorioComFastReport.Controllers
{
    public class HomeController : Controller
    {
        public readonly IWebHostEnvironment _webHostEnv;
        private readonly IProductSercice _productService;

        public HomeController(IWebHostEnvironment webHostEnv,
            IProductSercice productService)
        {
            _webHostEnv = webHostEnv;
            _productService = productService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [Route("CreateReport")]
        public IActionResult CreateReport()
        {
            var caminhoReport = Path.Combine(_webHostEnv.WebRootPath, @"reports\ReportMvc.frx");
            var reportFile = caminhoReport;
            var freport = new FastReport.Report();
            var productList = _productService.GetProducts();

            freport.Dictionary.RegisterBusinessObject(productList, "productList", 10, true);
            freport.Report.Save(reportFile);

            return Ok($" Relatorio gerado : {caminhoReport}");
        }


        [Route("ProductsReport")]
        public IActionResult ProductsReport()
        {
            var caminhoReport = Path.Combine(_webHostEnv.WebRootPath, @"reports\ReportMvc.frx");
            var reportFile = caminhoReport;
            var freport = new FastReport.Report();
            var productList = _productService.GetProducts();

            freport.Report.Load(reportFile);
            freport.Dictionary.RegisterBusinessObject(productList, "productList", 10, true);

            freport.Prepare();

            var pdfExport = new PDFSimpleExport();

            using MemoryStream ms = new MemoryStream();

            pdfExport.Export(freport, ms);
            ms.Flush();

            return File(ms.ToArray(), "application/pdf");
            //return Ok($"Relatorio gerado: {caminhoReport}");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


    }
}