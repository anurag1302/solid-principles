using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public static class StaticClass
    {
        public static int Id { get; set; }
        public static string Name { get; set; }

        static StaticClass()
        {
            Id = 101;
            Name = "John";
        }

        public static string Message()
        {
            return $"{Name} has id = {Id}";
        }

    }

    public class Sample
    {
        public static int Id { get; set; }
        public static string Name { get; set; }

        static Sample()
        {
            Id = 101;
            Name = "John";
        }

        public Sample()
        {
            Id = Id + 5;
            Name = Name + "Doe";
        }

        public static string Message()
        {
            return $"{Name} has id = {Id}";
        }

        public string NewMessage()
        {
            return $"New {Name} has id = {Id}";

        }
    }
}
