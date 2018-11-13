using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankALM.Repo;
using BankALM.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BankALM.Controllers
{
    public class TransferController : Controller
    {
        private readonly BankRepository bankContext;

        public TransferController(BankRepository bankContext)
        {
            this.bankContext = bankContext;
        }

        public IActionResult Index()
        {
            return View(new TransactionViewModel());
        }

        public IActionResult Transfer(TransactionViewModel vm)
        {
            bankContext.Transfer(vm);
            ViewData["Message"] = vm.Message;
            return View("Index", new TransactionViewModel());
        }
    }
}