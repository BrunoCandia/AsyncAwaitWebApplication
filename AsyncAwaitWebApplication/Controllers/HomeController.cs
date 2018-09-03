using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace AsyncAwaitWebApplication.Controllers
{
    public class HomeController : Controller
    {
        public async Task<ActionResult> Index()
        {
            using(var client = new HttpClient())
            {
                Stopwatch sw = new Stopwatch();
                sw.Start();

                //var httpMessage = await client.GetAsync("http://www.filipekberg.se/rss/");

                //var content = await httpMessage.Content.ReadAsStringAsync();

                var httpMessage = await client.GetAsync("http://www.filipekberg.se/rss/").ConfigureAwait(false);

                var content = await httpMessage.Content.ReadAsStringAsync().ConfigureAwait(false);

                sw.Stop();
                Console.WriteLine($"Time elapsed: {sw.Elapsed}");

                return Content(content);
            }            
        }

        //public ActionResult Index()
        //{
        //    //ViewBag.Title = "Home Page";
        //    //return View();

        //    return Content("Hello world !!!");
        //}
    }
}
