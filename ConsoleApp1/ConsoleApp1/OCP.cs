using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class OCP
    {
        public class Account
        {
            public string AccountType { get; set; }
            public double Balance { get; set; }

            public double CalculateDiscount()
            {
                if(AccountType=="A")
                {
                    return Balance * 0.5;
                }
                else if(AccountType=="B")
                {
                    return Balance * 0.3;
                }
                return 0;
            }

            //OCP states that a class should be open for extension but closed for modification.
            //In the above method, if we need to add multiple types, then we need to modify the method, which violates OCP.
            //In order to practice OCP, we should first follow SRP and then extend the class using an interface
        }

        public interface IDiscount
        {
            double CalculateDiscount(Account account);
        }

        public class AccountA : IDiscount
        {
            public double CalculateDiscount(Account account)
            {
                return account.Balance * 0.5;
            }
        }

        public class AccountB : IDiscount
        {
            public double CalculateDiscount(Account account)
            {
                return account.Balance * 0.3;
            }
        }

        public class AccountC : IDiscount
        {
            public double CalculateDiscount(Account account)
            {
                return account.Balance * 0.7;
            }
        }
    }
}
