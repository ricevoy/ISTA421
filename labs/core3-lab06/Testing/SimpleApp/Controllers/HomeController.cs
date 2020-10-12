using Microsoft.AspNetCore.Mvc;
using SimpleApp.Models;
namespace SimpleApp.Controllers
{
    public class HomeController : Controller
    {
        //what kind of method is this? action method!
        // expects a view with the name of the action method
        // located inside views/home
        public ViewResult Index()
        {
            return View(Product.GetProducts());
        }
    }
}