using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace deadlock
{
    public class Account
    {
        public int OneNumber { get; set; } = 2;
        public int SecondNumber { get; set; } = 2;
        private decimal balance;

        public Account(decimal initialBalance) => balance = initialBalance;

        public decimal Debit(decimal amount)
        {
            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "The debit amount cannot be negative.");
            }

            decimal appliedAmount = 0;
           
            {
                if (balance >= amount)
                {
                    Program.WhatToDo();
                    balance -= amount;
                    appliedAmount = amount;
                }
            }
            return appliedAmount;
        }

        public void Credit(decimal amount)
        {
            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "The credit amount cannot be negative.");
            }

           
            {
                balance += amount;
            }
        }

        public decimal GetBalance()
        {
            
            {
                return balance;
            }
        }
    }
}
