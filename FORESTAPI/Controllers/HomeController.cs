using DBLib.Masters;

using FO.Models;

using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FORestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IEnumerable<SHAClasses> Get()
        {
            var helper = new DBHelper();

            return helper.Data.SHAClasses;
        }
    }
}
