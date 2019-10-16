using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TrainingCore.Controllers
{
    [Route("Admin")]
    public class AdminController : Controller
    {

      
        [Route("")]
        public string Save()
        {
            return "Saved";
        }
    }
}