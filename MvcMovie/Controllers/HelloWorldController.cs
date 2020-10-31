using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
namespace MvcMovie.Controllers
{
    //inherits from controller base class
    public class HelloWorldController : Controller
    {
       //GET :/HelloWorld/
       public IActionResult Index()
       {
           return View();
       } 
    
        //GET: /HelloWorld/Welcome?name=Bryan&ID=1
        //The MVC model binding system automatically mapts the named parameters from the query string
        //in the address bar to the parameters in the method.
       public IActionResult Welcome(string name, int numTimes = 1)
       {
           //ViewData is a dynamic dicitonary object.
           //This dictionary will be available in the view
           ViewData["Message"] = $"Hello {name}";
           ViewData["NumTimes"] = numTimes;

            return View();
       }
    }
}