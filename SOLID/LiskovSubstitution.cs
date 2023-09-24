namespace SOLID.LSP
{
    /// <summary>
    /// The Liskov substitution principle states that derived classes should be substitutable
    /// for their base class without causing any errors/side effects.
    /// "A derived class should correctly implement methods of a base class".
    /// </summary>
    public abstract class Vehicle
    {
        public abstract void Drive();
    }
    public class Car : Vehicle
    {
        public override void Drive()
        {
            Console.WriteLine("Lets drive a car");
        }
    }

    public class Truck : Vehicle
    {
        public override void Drive()
        {
            Console.WriteLine("Lets drive a truck");
        }
    }

    public class Aircraft : Vehicle
    {
        public override void Drive()
        {
            throw new NotImplementedException();
        }
    }

    public class TestDrive
    {
        // Here we have parameter as base class Vehicle
        // But it can accept instances of Car/Truck in substitute of Vehicle
        // it, however, can't accept instances of Aircraft in substitute of Vehicle
        // as that causes side-effect to behvaior of caller function
        public static void Drive(Vehicle _vehicle)
        {
            _vehicle.Drive();
        }
    }
}