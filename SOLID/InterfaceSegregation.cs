namespace SOLID.ISP
{
    /// <summary>
    ///  Clients should not be forced to implement any methods they don’t use.
    ///  Rather than one fat interface, numerous little interfaces are preferred.
    ///  based on groups of methods, with each interface serving one submodule
    /// </summary>
    #region Violation Sample
    public interface IMutiFunctionVehicle         // FAT INTERFACE
    {
        void Dashboard();
        void Fly();
        void Drive();
    }

    public class MultifunctionVehicle : IMutiFunctionVehicle      // OK FOR CLASSES NEEDING ALL BEHAVIORS
    {
        public void Dashboard()
        {
            Console.WriteLine("Details of vehicle");
        }
        public void Drive()
        {
            Console.WriteLine("Lets drive");
        }

        public void Fly()
        {
            Console.WriteLine("Lets fly");
        }
    }

    public class Car : IMutiFunctionVehicle
    {
        public void Dashboard()
        {
            Console.WriteLine("Details of vehicle");
        }
        public void Drive()
        {
            Console.WriteLine("Lets drive car");
        }

        public void Fly()
        {
            throw new NotImplementedException();    // FORCED TO WRITE CODE SPECIFYING IMPLEMENTATION NOT DONE AND ITS NOT REQUIRED
        }
    }

    public class Aircraft : IMutiFunctionVehicle
    {
        public void Dashboard()
        {
            Console.WriteLine("Details of vehicle");
        }
        public void Drive()
        {
            throw new NotImplementedException();
        }

        public void Fly()
        {
            Console.WriteLine("Lets fly aircraft");     // FORCED TO WRITE CODE SPECIFYING IMPLEMENTATION NOT DONE AND ITS NOT REQUIRED
        }
    }

    #endregion
    #region Abiding Sample
    public interface IVehicle     // THIN COMMON INTERFACES
    {
        void Dashboard();
    }
    public interface ICar : IVehicle         // THIN INTERFACES
    {
        void Drive();
    }
    public interface IAircraft : IVehicle    // THIN INTERFACES
    {
        void Fly();
    }
    public interface IMutiFunctionsVehicle : ICar, IAircraft      // AN INTERFACE WHICH CAN BE USED IF ALL BEHAVIOTS OF INDIVIDUAL THIN INTERFACES ARE REQUIRED
    {
    }

    public class Cars : ICar      // NO FORCED IMPLEMENTATION
    {
        public void Dashboard()
        {
            Console.WriteLine("Details of vehicle");
        }
        public void Drive()
        {
            Console.WriteLine("Lets drive car");
        }
    }

    public class Aircrafts : IAircraft    // NO FORCED IMPLEMENTATION
    {
        public void Dashboard()
        {
            Console.WriteLine("Details of vehicle");
        }
        public void Fly()
        {
            Console.WriteLine("Lets fly aircraft");
        }
    }

    // NOTE - instead of having separate IMutiFunctionsVehicle, in below class we can inherit multiple interfaces to achive same result
    public class MultifunctionVehicles : IMutiFunctionsVehicle    // NO FORCED IMPLEMENTATION
    {
        public void Dashboard()
        {
            Console.WriteLine("Details of vehicle");
        }
        public void Drive()
        {
            Console.WriteLine("Lets drive");
        }

        public void Fly()
        {
            Console.WriteLine("Lets fly");
        }
    }
    #endregion
}
