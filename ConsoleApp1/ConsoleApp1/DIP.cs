using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class DIP
    {
        //Dependency Inversion Principle states that a high level class must not depend on the low level class, rather on 
        //an abstraction of it

        public class Employee
        {
            public void SomeMethod()
            {
                FileLogger logger = new FileLogger();
                logger.Log();
            }
        }

        public class  FileLogger
        {
            public void Log()
            {

            }
        }

        //FileLogger is a low level class and Employee is a high level class, here Employee depends on FileLogger
        //It violates DIP

        public interface ILogger
        {
            void Log();
        }

        public class FileLogger1ILogger
        {
            public void Log()
            {

            }
        }

        public class Employee1
        {
            private readonly ILogger _logger;
            public Employee1(ILogger logger)
            {
                _logger = logger;
            }

            public void SomeMethod()
            {
                _logger.Log();
            }
        }
    }
}
