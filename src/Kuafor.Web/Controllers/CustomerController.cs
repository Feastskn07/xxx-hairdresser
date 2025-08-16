using Microsoft.AspNetCore.Mvc;

namespace Kuafor.Web.Controllers
{
    // Not: Bu controller sadece dashboard görünümünü göstermek içindir.
    // ViewModel, veri erişimi vb. kısımlar eklenecek.
    public class CustomerController : Controller
    {
        // GET: /Customer
        public IActionResult Index()
        {
            // TODO: Kullanıcıya ait yaklaşan randevular vb. ViewModel ile doldurulacak.
            return View();
        }
    }
}