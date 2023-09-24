using SOLID.LSP;

namespace Main
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LiskovTest();
            Console.ReadKey(); 
        }

        static void LiskovTest()
        {
            TestDrive.Drive(new Car());
            TestDrive.Drive(new Truck());
        }
    }
}