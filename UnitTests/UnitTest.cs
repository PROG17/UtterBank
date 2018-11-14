using System;
using System.Collections.Generic;
using System.Linq;
using BankALM.Models;
using BankALM.Repo;
using BankALM.ViewModels;
using Xunit;

namespace UnitTests
{
    public class UnitTest
    {
        public BankRepository BankRepository { get; set; }
        public UnitTest()
        {
            BankRepository = new BankRepository();
        }
        [Fact]
        public void WithdrawTest()
        {
            var expectedValue = 40;
            BankRepository.BankAccounts.Add(new Account(){AccountNumber = 1,Balance = 100});
            var model = new TransactionViewModel {Amount = 60, From = 1};

            var result = BankRepository.Withdraw(model);
            var actualValue = BankRepository.BankAccounts.First(x => x.AccountNumber == 1).Balance;

            Assert.True(result);
            Assert.Equal(expectedValue,actualValue);
        }
        [Fact]
        public void DepositTest()
        {
            var expectedValue = 140;
            BankRepository.BankAccounts.Add(new Account() { AccountNumber = 1, Balance = 100 });
            var model = new TransactionViewModel { Amount = 40, To = 1 };

            var result = BankRepository.Deposit(model);
            var actualValue = BankRepository.BankAccounts.First(x => x.AccountNumber == 1).Balance;

            Assert.True(result);
            Assert.Equal(expectedValue, actualValue); 
        }

        [Theory]
        [InlineData(120,1)]
        [InlineData(-500, 1)]
        [InlineData(60, 2)]

        public void WithdrawalErrorTest(int amount, int from)
        {
            BankRepository.BankAccounts.Add(new Account() { AccountNumber = 1, Balance = 100 });
            var model = new TransactionViewModel { Amount = amount, From = from };
            

            var result1 = BankRepository.Withdraw(model);

            Assert.False(result1);
        }

        [Theory]
        [InlineData(-100, 1)]
        [InlineData(100, 2)]
        public void DepositErrorTest(int amount, int to)
        {
            BankRepository.BankAccounts.Add(new Account() { AccountNumber = 1, Balance = 100 });
            var model = new TransactionViewModel { Amount = amount, To = to };

            var result = BankRepository.Deposit(model);

            Assert.False(result);
        }

        [Theory]
        [InlineData(-100, 1, 2)]
        [InlineData(100, 1, 2)]
        public void TransferErrorTest(int amount, int to, int from)
        {
            BankRepository.BankAccounts.Add(new Account() { AccountNumber = 1, Balance = 10 });
            BankRepository.BankAccounts.Add(new Account() { AccountNumber = 2, Balance = 10 });
            var model = new TransactionViewModel { Amount = amount, To = to , From = from};

            var result = BankRepository.Transfer(model);

            Assert.False(result);
        }

        [Fact]
        public void TransferTest()
        {
            var fromExpectedValue = 5;
            var toExpectedValue = 15;
            BankRepository.BankAccounts.Add(new Account() { AccountNumber = 1, Balance = 10 });
            BankRepository.BankAccounts.Add(new Account() { AccountNumber = 2, Balance = 10 });
            var model = new TransactionViewModel { Amount = 5, To = 2, From = 1 };

            var result = BankRepository.Transfer(model);
            var fromActualValue = BankRepository.BankAccounts.First(x => x.AccountNumber == 1).Balance;
            var toActualValue = BankRepository.BankAccounts.First(x => x.AccountNumber == 2).Balance;

            Assert.True(result);
            Assert.Equal(fromExpectedValue, fromActualValue);
            Assert.Equal(toExpectedValue, toActualValue);

        }
    }
}
