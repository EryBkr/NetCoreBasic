using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TrainingCore.Models;
using TrainingCore.Services;

namespace TrainingCore.Controllers
{
    public class CustomerController : Controller
    {

        List<Customer> customers = new List<Customer>();
        ICalculator _calculator;

        public CustomerController(ICalculator calculator)
        {
            _calculator = calculator;
        }

        public string Calculate()
        {
            return _calculator.Calculate(20).ToString();
        }

        [HttpGet]
        public IActionResult Add()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Add(Customer customer)
        {
            customers.Add(customer);
            return RedirectToAction("Add","Customer");
        }
    }
}