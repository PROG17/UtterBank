using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankALM.Models;

namespace BankALM.Repo
{
    public class BankRepository
    {
        public BankRepository()
        {
            Customers = new List<Customer>
            {
                new Customer(){CustomerId = 1, CustomerName = "Jocke",Accounts =
                {
                    new Account(){AccountNumber = 132265, Balance = 12004},
                    new Account(){AccountNumber = 655929, Balance = 21600}
                }},
                new Customer(){CustomerId = 2, CustomerName = "Markus",Accounts =
                {
                    new Account(){AccountNumber = 971394, Balance = 54000},
                    new Account(){AccountNumber = 465231, Balance = 6500}
                }},
                new Customer(){CustomerId = 3, CustomerName = "Thomas",Accounts =
                {
                    new Account(){AccountNumber = 6532323, Balance = 25}
                }},
                new Customer(){CustomerId = 4, CustomerName = "Micke",Accounts =
                {
                    new Account(){AccountNumber = 6567771, Balance = 500},
                    new Account(){AccountNumber = 110221, Balance = 179}
                }}
            };
        }

        public List<Customer> Customers { get; set; }

        
    }
}
