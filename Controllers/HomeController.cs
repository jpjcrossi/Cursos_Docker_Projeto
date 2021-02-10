using System.Runtime.InteropServices;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using mvc1.Models;
using Microsoft.Extensions.Configuration;

namespace mvc1.Controllers
{
    public class HomeController : Controller
    {
        
        private IRepository repostitory;
        private string message;


        public HomeController( IRepository repo, IConfiguration config)
        {

            repostitory = repo;
            message = $"Docker - ({config["HOSTNAME"]?? "localhost"})";
            
            
        }

        public IActionResult Index()        
        {
            ViewBag.Message = message;
            return View(repostitory.Produtos);
        }

    }
}
