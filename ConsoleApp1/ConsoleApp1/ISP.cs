using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class ISP
    {
        //ISP says that a class/type should not be forced to use the interfaces/types that it does not want to

        interface IAccount
        {
            void Salary();
            void Bonus();
        }

        class PermanentEmp : IAccount
        {
            public void Bonus()
            {
                
            }

            public void Salary()
            {
                
            }
        }

        class ContractEmp : IAccount
        {
            public void Bonus()
            {
                throw new NotImplementedException();
            }

            public void Salary()
            {

            }
        }

        //Contract Employee does not have a bonus component, but over here it is forced to use the Bonus() method as well.
        //We can solve this by ISP.
        //We can create 2 interfaces and use them wherever required.

        interface ISalary
        {
            void Salary();
        }
        interface IBonus
        {
            void Bonus();
        }
        class PermanentEmp1 : ISalary, IBonus
        {
            public void Bonus()
            {

            }

            public void Salary()
            {

            }
        }

        class ContractEmp1 : ISalary
        {
            public void Salary()
            {

            }
        }
    }
}
