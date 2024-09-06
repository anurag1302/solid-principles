using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public sealed class SealedClass
    {
        public void Message()
        {

        }
    }

    //public class A: SealedClass // can't inherit a sealed class
    //{

    //}

    public class A // an object of a sealed class can be created and the methods can be used. Ex: SqlDbConnection is a sealed class
    {
        public void ABC()
        {
            SealedClass obj = new SealedClass();
            obj.Message();
        }
    }

}
