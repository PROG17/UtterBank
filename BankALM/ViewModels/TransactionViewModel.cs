using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankALM.ViewModels
{
    public class TransactionViewModel
    {
        public int From { get; set; }
        public int To { get; set; }
        public int Amount { get; set; }
        public string Message { get; set; }
    }
}
