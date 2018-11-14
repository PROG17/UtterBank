using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankALM.Models
{
    public class Account
    {
        public int AccountNumber { get; set; }
        public int CustomerId { get; set; }
        public decimal Balance { get; set; }

        public void Transfer(bool from, decimal amount)
        {
            if(from)
            {
                Balance -= amount;
            } else
            {
                Balance += amount;
            }
        }
    }
}
