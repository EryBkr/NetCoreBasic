using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TrainingCore.Filters;

namespace TrainingCore.Controllers
{
    public class FilterController : Controller
    {
        [CustomFilter]
        public IActionResult Index()
        {
            return View();
        }
    }
}