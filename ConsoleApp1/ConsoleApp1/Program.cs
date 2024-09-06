namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            Console.WriteLine(StaticClass.Message());

            var obj = new Sample();
            Console.WriteLine(obj.NewMessage());

            var obj1 = new Sample();
            Console.WriteLine(obj1.NewMessage());

            Console.ReadLine();
        }
    }
}

