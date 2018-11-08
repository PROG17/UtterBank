using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankALM.Repo;
using BankALM.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BankALM.Controllers
{
    public class TransactionController : Controller
    {
        private readonly BankRepository _bankContext;

        public TransactionController(BankRepository bankContext)
        {
            _bankContext = bankContext;
        }
        public IActionResult Index()
        {
            return View(new TransactionViewModel());
        }

        public IActionResult Withdraw(TransactionViewModel vm)
        {
            vm.From = vm.To;
            var res = _bankContext.Withdraw(vm);
            ViewData["Message"] = vm.Message;
            return View("Index",new TransactionViewModel());
        }
        public IActionResult Deposit(TransactionViewModel vm)
        {
            var res = _bankContext.Deposit(vm);
            ViewData["Message"] = vm.Message;
            return View("Index", new TransactionViewModel());
        }
    }
}