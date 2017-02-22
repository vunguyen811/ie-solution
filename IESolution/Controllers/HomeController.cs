using System;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using IESolution.Services;

namespace IESolution.Controllers
{
    public class HomeController : Controller
    {
        private ExportService _exportService;
        private OrderService _orderService;
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Import()
        {
            ViewBag.Message = "import page.";

            return View();
        }

        public ActionResult Export()
        {
            ViewBag.Message = "export page";
            return View();
        }

        public async Task<ActionResult> ExportFile(int records)
        {
            _exportService = new ExportService();
            _orderService = new OrderService();
            var orders = await _orderService.GetOrdersAsync(records);
            Stopwatch sw = new Stopwatch();
            sw.Start();
            var file = _exportService.ExportOrder(orders);
            sw.Stop();
            return File(file, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "test.xlsx");
        }

        [HttpPost]
        public async Task<ActionResult> ImportFile(HttpPostedFileBase importFile, string runWith)
        {
            if (importFile == null || importFile.ContentLength == 0)
            {
                ViewBag.Error = "File invalid";
                return View("Import");
            }

            if (importFile.ContentType != "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
            {
                ViewBag.Error = "File format invalid";
                return View("Import");
            }

            Stream stream = importFile.InputStream;
            _orderService = new OrderService();
            Stopwatch sw = new Stopwatch();
            bool isSucces;
            sw.Start();
            if (runWith == "1")
            {
                isSucces = await _orderService.ImportOrdersAsync(stream);
            }
            else
            {
                isSucces = await _orderService.ImportOrdersAsyncV2(stream);
            }

            sw.Stop();
            ViewBag.ExcuteTime = sw.ElapsedMilliseconds + " ms";
            if (!isSucces)
            {
                ViewBag.Error = "Import error";
                return View("Import");
            }
            ViewBag.Success = "Import success";
            return View("Import");
        }

        [HttpGet]
        public async Task<ActionResult> DeleteImportedOrder()
        {
            _orderService = new OrderService();
            _orderService.DeleteImportedOrder();
            ViewBag.Success = "Delete success";
            return View("Import");
        }
    }
}