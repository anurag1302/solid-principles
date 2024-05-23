using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class LSP
    {
        //Liskov Substitution Principle states that a child class object should be able to replace base class object
        //In simpler words, LSP is respected if all the base class methods are applicable for child class 

        public class BaseEmployee
        {
            public virtual int Salary()
            {
                return 10000;
            }

            public virtual int Bonus()
            {
                return 1000;
            }
        }

        public class PermanentEmployee:BaseEmployee
        {
            public override int Salary()
            {
                return 20000;
            }
            public override int Bonus()
            {
                return 2000;
            }
        }

        public class ContractEmployee : BaseEmployee
        {
            public override int Salary()
            {
                return 15000;
            }
            public override int Bonus()
            {
                throw new NotImplementedException();
            }
        }

        public void Main()
        {

            BaseEmployee baseEmployee = new BaseEmployee();
            PermanentEmployee permanentEmployee = new PermanentEmployee();
            ContractEmployee contractEmployee = new ContractEmployee();

            baseEmployee.Salary();
            baseEmployee.Bonus();

            permanentEmployee.Salary();
            permanentEmployee.Bonus();

            contractEmployee.Salary();
            contractEmployee.Bonus();//throws Exception, expected but the design is incorrect, doesn't follow LSP


        }


    }
}
