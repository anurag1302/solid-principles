using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class SRP
    {
        public class Employee
        {
            public int Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Department { get; set; }
            public double Salary { get; set; }

            //own responsibility
            public void GetDepartment()
            {

            }

            //own responsibility
            public void GetSalary()
            {

            }

            //not own responsibility
            public void SaveEmployee()
            {
                var empRepo = new EmpRepository();
                empRepo.Save(this);
            }

            //not own responsibility
            public void SendWelcomeEmail()
            {
                var emailNotif = new EmailNotifier();
                emailNotif.SendWelcomeEmail(this);
            }

            //SaveEmployee and SendWelcomeEmail are not the jpb of Employee class,
            //these should be removed from the class and delegated some where else
            //as done in EmpRepository and EmailNotifier classes
        }

        public class EmpRepository
        {
            public void Save(Employee employee)
            {

            }
        }

        public class EmailNotifier
        {
            public void SendWelcomeEmail(Employee employee)
            {

            }
        }
    }
}
