using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrainingCore.ExtensionMethods;
using TrainingCore.Models;

namespace TrainingCore.Controllers
{
    public class SessionDemoController : Controller
    {
        public string Index()
        {
            Customer c = new Customer() {Id=5,City="İstanbul",Name="Eray"};
            SessionExtensionMethod.SetObject(HttpContext.Session, "Customer", c);

            return "session created"; 
        }

        public Customer GetSession()
        {
            var c=SessionExtensionMethod.GetObject<Customer>(HttpContext.Session, "Customer");
            return c;
        }
    }
}