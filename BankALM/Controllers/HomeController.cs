using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankALM.Repo;
using Microsoft.AspNetCore.Mvc;

namespace BankALM.Controllers
{
    public class HomeController : Controller
    {
        private readonly BankRepository _bankContext;
         
        public HomeController(BankRepository bankContext)
        {
            _bankContext = bankContext;
        }
        public IActionResult Index()
        {
            var model = _bankContext.Customers;
            return View(model);
        }
    }
}