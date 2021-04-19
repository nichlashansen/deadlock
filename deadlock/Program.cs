using System;
using System.Threading;
using System.Threading.Tasks;

namespace deadlock
{
    class Program
    {
        public static void WhatToDo()
        {
            Thread thread = new Thread(WhatToDo);
            Thread threadss = new Thread(WhatToDo);
            Thread threae = new Thread(WhatToDo);

            thread.Start();
            threadss.Start();
            threae.Start();

            var y = 4;

            
            for (int i = 0; i < 10000; i++)
            {
                var rna = new Random();
                Console.WriteLine($"Thread is working {rna.Next(2343,934798874)}");
                Account ac = new Account(y);

            }
        }


        class AccountTest
        {

            static async Task Main()
            {
                var account = new Account(1000);
                var tasks = new Task[100];
                for (int i = 0; i < tasks.Length; i++)
                {
                    tasks[i] = Task.Run(() => Update(account));
                }
                await Task.WhenAll(tasks);
                Console.WriteLine($"Account's balance is {account.GetBalance()}");
                // Output:
                // Account's balance is 2000
            }

            static void Update(Account account)
            {
                decimal[] amounts = { 0, 2, -3, 6, -2, -1, 8, -5, 11, -6 };
                foreach (var amount in amounts)
                {
                    if (amount >= 0)
                    {
                        account.Credit(amount);
                    }
                    else
                    {
                        account.Debit(Math.Abs(amount));
                    }
                }
            }
        }
    }
}


