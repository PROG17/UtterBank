using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankALM.Models;
using BankALM.ViewModels;

namespace BankALM.Repo
{
    public class BankRepository
    {
        public BankRepository()
        {
            BankAccounts = new List<Account>
            {
                new Account(){AccountNumber = 132265, Balance = 12004},
                new Account(){AccountNumber = 655929, Balance = 21600},
                new Account(){AccountNumber = 971394, Balance = 54000},
                new Account(){AccountNumber = 465231, Balance = 6500},
                new Account(){AccountNumber = 6532323, Balance = 25},
                new Account(){AccountNumber = 6567771, Balance = 500},
                new Account(){AccountNumber = 110221, Balance = 179}
            };
            BankCustomers = new List<Customer>
            {
                new Customer(){CustomerId = 1, CustomerName = "Jocke",Accounts =
                {
                    BankAccounts[0],
                    BankAccounts[1]
                }},
                new Customer(){CustomerId = 2, CustomerName = "Markus",Accounts =
                {
                    BankAccounts[2],
                    BankAccounts[3]
                }},
                new Customer(){CustomerId = 3, CustomerName = "Thomas",Accounts =
                {
                    BankAccounts[4]
                }},
                new Customer(){CustomerId = 4, CustomerName = "Micke",Accounts =
                {
                    BankAccounts[5],
                    BankAccounts[6]
                }}
            };
        }

        public List<Customer> BankCustomers { get; set; }
        public List<Account> BankAccounts { get; set; }
        public bool Withdraw(TransactionViewModel vm)
        {
            if (vm.Amount <= 0)
            {
                vm.Message = "Amount must be greater than 0";
                return false;
            }

            if (!BankAccounts.Any(x => x.AccountNumber == vm.From))
            {
                vm.Message = "Invalid account number";
                return false;
            }

            var model = BankAccounts.First(x => x.AccountNumber == vm.From);
            if (model.Balance < vm.Amount)
            {
                vm.Message = "There is not enough money on the account";
                return false;
            }

            model.Balance -= vm.Amount;
            vm.Message = $"New balance for the account is {model.Balance}";
            return true;
        }
        public bool Deposit(TransactionViewModel vm)
        {
            if (vm.Amount <= 0)
            {
                vm.Message = "Amount must be greater than 0 0";
                return false;
            }

            if (!BankAccounts.Any(x => x.AccountNumber == vm.To))
            {
                vm.Message = "Invalid account number";
                return false;
            }

            var model = BankAccounts.First(x => x.AccountNumber == vm.To);

            model.Balance += vm.Amount;
            vm.Message = $"New balance for the account is {model.Balance}";
            return true;
        }


    }
}
