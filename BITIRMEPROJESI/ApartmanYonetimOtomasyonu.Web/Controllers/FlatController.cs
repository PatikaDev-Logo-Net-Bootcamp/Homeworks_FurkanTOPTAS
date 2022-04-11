using Microsoft.AspNetCore.Mvc;

namespace ApartmanYonetimOtomasyonu.Web.Controllers
{
    public class FlatController : Controller
    {
        //[AuthorizeByRole(Roles="Admin")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
