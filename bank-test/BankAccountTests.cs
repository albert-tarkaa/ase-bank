using ase_bank;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;


namespace BankTests
{
    [TestClass]
    public class BankAccountTests
    {
        [TestMethod]
        public void Credit_WithValidAmount_UpdatesBalance()
        {
            // arrange
            double beginningBalance = 11.99;
            double creditAmount = 4.55;
            double expected = 16.54;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);

            // act
            account.Credit(creditAmount);

            // assert
            double actual = account.Balance;
            Assert.AreEqual(expected, actual, 0.001, "Account not credited correctly");
        }

        [TestMethod]
        public void Credit_WithZeroAmount_DoesNotUpdateBalance()
        {
            // arrange
            double beginningBalance = 11.99;
            double creditAmount = 0.0;
            double expected = beginningBalance;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);

            // act
            account.Credit(creditAmount);

            // assert
            double actual = account.Balance;
            Assert.AreEqual(expected, actual, 0.001, "Account not credited correctly.");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "The expected exception was not thrown.")]
        public void Credit_WithNegativeAmount_ThrowsException()
        {
            // arrange
            double beginningBalance = 11.99;
            double creditAmount = -3.52;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);

            // act
            account.Credit(creditAmount);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "The expected exception was not thrown.")]
        public void Credit_FrozenAccount_ThrowsException()
        {
            // arrange
            double beginningBalance = 11.99;
            double creditAmount = -3.52;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);
            account.FreezeAccount();

            // act
            account.Credit(creditAmount);
        }

        [TestMethod]
        public void Debit_WithValidAmount_UpdatesBalance()
        {
            //arrange
            double beginningBalance = 11.99;
            double debitAmount = 1.99;
            double expected = 10;
            BankAccount account = new BankAccount ("Mr. Bryan Walton", beginningBalance);

            //act
            account.Debit(debitAmount);

            //assert
            double actual = account.Balance;
            Assert.AreEqual(expected, actual, 0.001, "Account was debit wrongly");
        }

        [TestMethod]
        public void Debit_WithZeroAmount_DoesNotUpdateBalance()
        {
            // arrange
            double beginningBalance = 11.99;
            double debitAmount = 0;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);

            // act
            account.Debit(debitAmount);

            //Assert
            double actual = account.Balance;
            Assert.AreEqual(actual, beginningBalance, 0.001, "Account not credited correctly");
        }

        [TestMethod]

        [ExpectedException(typeof(ArgumentOutOfRangeException), "The expected exception was not thrown.")]
        public void Debit_WithNegativeAmount_ThrowsException()
        {
            // arrange
            double beginningBalance = 11.99;
            double debitAmount = -3.52;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);

            // act
            account.Debit(debitAmount);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "The expected exception was not thrown.")]
        public void Debit_FrozenAccount_ThrowsException()
        {
            // arrange
            double beginningBalance = 11.99;
            double debitAmount = -3.52;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);
            account.FreezeAccount();

            // act
            account.Debit(debitAmount);
        }
    }
}
