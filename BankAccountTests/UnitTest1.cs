using NUnit.Framework;
using System;
using Zad1;

namespace BankAccountTests
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void DepositShouldIncreaseBalance()
        {
            BankAccount bankAccount = new BankAccount(123);
            decimal depositAmount = 100;

            bankAccount.Deposit(depositAmount);

            Assert.AreEqual(depositAmount, bankAccount.Balance);
        }

        [Test]
        public void AccountInicializeWithPositiveValue()
        {
            BankAccount bankAccount = new BankAccount(123, 2000m);

            Assert.AreEqual(2000m, bankAccount.Balance);
        }
        [TestCase(100)]
        [TestCase(3500)]
        [TestCase(2400)]
        public void DepositShouldIncreaseBalanceAll(decimal depositAmount)
        {
            BankAccount bankAccount = new BankAccount(123);


            bankAccount.Deposit(depositAmount);

            Assert.AreEqual(depositAmount, bankAccount.Balance);
        }
        [Test]
        public void NegativeAmountShouldTrowInvalidOperationExceptions()
        {
            BankAccount bankAccount = new BankAccount(123);
            decimal depositAmount = -100;

            var ex = Assert.Throws<InvalidOperationException>(() =>
                                                 bankAccount.Deposit(depositAmount));
        }
        [Test]
        public void NegativeAmountShouldTrowInvalidOperationExceptionsWithMessage()
        {
            BankAccount bankAccount = new BankAccount(123);
            decimal depositAmount = -100;

            var ex = Assert.Throws<InvalidOperationException>(() =>
                                                 bankAccount.Deposit(depositAmount));

            Assert.AreEqual(ex.Message, "Negative amount");

        }
        [Test]
        public void CreditShouldIncreaseBalance()
        {
            BankAccount bankAccount = new BankAccount(123);
            decimal percent = 10;
            bankAccount.Credit(percent);
            Assert.AreEqual(percent, bankAccount.Balance);
        }
        [TestCase(1001)]
        [TestCase(2004)]
        [TestCase(3500)]
        public void BonusShouldIncreaseBalance(decimal
            bonusAmount)
        {
            BankAccount bankAccount = new BankAccount(123);
            bankAccount.Balance = bankAccount.Bonus();
            Assert.AreEqual(bankAccount.Bonus(), bankAccount.Balance);
        }

    }

}