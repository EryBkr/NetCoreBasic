using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TrainingCore.Filters;
using TrainingCore.Models;

namespace TrainingCore.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var customers = new List<Customer>()
            {
                new Customer{Id = 1,Name = "Eray"},
                new Customer{Id = 1,Name = "Berkay"},
                new Customer{Id = 1,Name = "James"},
                new Customer{Id = 1,Name = "George"},
                new Customer{Id = 1,Name = "Tahm"},
            };

            return View(customers);
        }

        [HandleException]
        public IActionResult Index2()
        {
            throw new Exception("Hata Fırlatıldı");
            return RedirectToRoute("default");
        }

      
        public JsonResult Index3()
        {
            var customer = new Customer()
            {
                Id = 1,
                Name = "Eray"
            };

            return Json(customer);
        }

        public IActionResult Index4(string key)
        {

            var customers = new List<Customer>()
            {
                new Customer{Id = 1,Name = "Eray"},
                new Customer{Id = 1,Name = "Berkay"},
                new Customer{Id = 1,Name = "James"},
                new Customer{Id = 1,Name = "George"},
                new Customer{Id = 1,Name = "Tahm"},
            };
            if (String.IsNullOrEmpty(key))
            {
                return Json(customers);
            }
            var result = customers.Where(i => i.Name.ToLower().Contains(key.ToLower())).ToList();
            return View(result);
        }

    }
}