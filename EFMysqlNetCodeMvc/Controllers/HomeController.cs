using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EFMysqlNetCodeMvc.Models;

namespace EFMysqlNetCodeMvc.Controllers
{
    //[Route("home")]
    public class HomeController : Controller
    {
        DBEntities db;

        public HomeController(DBEntities db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        //[HttpGet("test")]
        public IActionResult Test()
        {
          
            //查询
            List<User> list = db.User.ToList();
            
            //json序列化
            //var userJson = JsonConvert.SerializeObject(list);
            //var userList = JsonConvert.DeserializeObject<List<User>>(userJson);

            return Json(list);
        }

        public IActionResult Add([FromBody] User user)
        {
            //新增
            //User user = new User();
            //user.Id = Guid.NewGuid().ToString().Replace("-", "");
            //db.User.Add(user);
            //db.SaveChanges();

            return Json(user);
        }
    }
}
