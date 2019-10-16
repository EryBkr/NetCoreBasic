using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainingCore.Models;

namespace TrainingCore.ViewComponents
{
    public class CustomerListViewComponent:ViewComponent
    {
     
        public ViewViewComponentResult Invoke()
        {

            return View();
        }
    }
}
