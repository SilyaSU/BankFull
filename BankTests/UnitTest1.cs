using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankAccountNS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountNS.Tests
{
    [TestClass()]
    public class BankAccountTests
    {
        [TestMethod]
        public void Debit_WithValidAmount_UpdatesBalance()
        {
            // Arrange
            double beginningBalance = 11.99;
            double debitAmount = 4.55;
            double expected = 7.44;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);

            // Act
            account.Debit(debitAmount);

            // Assert
            double actual = account.Balance;
            Assert.AreEqual(expected, actual, 0.001, "Account not debited correctly");
        }

        [TestMethod]
        public void Debit_WhenAmountIsZero()
        {
            // Arrange
            double beginningBalance = 11.99;
            double debitAmount = 0;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);

            // Act
            account.Debit(debitAmount);

            // Assert
            double expected = beginningBalance;
            double actual = account.Balance;
            Assert.AreEqual(expected, actual, 0.001, "Account balance changed incorrectly");
        }

        [TestMethod]
        public void Credit_WithValidAmount_UpdatesBalance()
        {
            // Arrange
            double beginningBalance = 11.99;
            double creditAmount = 5.77;
            double expected = 17.76;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);

            // Act
            account.Credit(creditAmount);

            // Assert
            double actual = account.Balance;
            Assert.AreEqual(expected, actual, 0.001, "Account not credited correctly");
        }

      

        [TestMethod]
        public void Credit_WithNegativeAmount()
        {
            // Arrange
            double beginningBalance = 11.99;
            double creditAmount = -3;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);

            // Act and Assert
            Assert.ThrowsException<System.ArgumentOutOfRangeException>(() => account.Credit(creditAmount));
        }

        [TestMethod]
        public void WithValidArguments_SetsCustomerNameAndBalance()
        {
            // Arrange
            string customerName = "Mr. Bryan Walton";
            double beginningBalance = 11.99;

            // Act
            BankAccount account = new BankAccount(customerName, beginningBalance);

            // Assert
            Assert.AreEqual(customerName, account.CustomerName);
            Assert.AreEqual(beginningBalance, account.Balance);
        }


        [TestMethod]
        public void Constructor_WithEmptyCustomerName()
        {
            // Arrange
            string customerName = "";
            double beginningBalance = 11.99;

            // Act and Assert
            Assert.ThrowsException<ArgumentException>(() => new BankAccount(customerName, beginningBalance));
        }

        [TestMethod]
        public void Constructor_WithNegativeBalance()
        {
            // Arrange
            string customerName = "Mr. Bryan Walton";
            double beginningBalance = -11.99;

            // Act and Assert
            Assert.ThrowsException<System.ArgumentOutOfRangeException>(() => new BankAccount(customerName, beginningBalance), "Initial balance cannot be negative.");
        }

    }
}