// <copyright file="Program.cs" company="NuvoLetta">
// Copyright (c) 2017 All Rights Reserved
// </copyright>
// <author>Julia Hrytsyk</author>

using System;

/// <summary>
/// Abstract Factory patterns acts a super-factory which creates other
/// factories. This pattern is also called as Factory of factories.
/// In Abstract Factory pattern an interface is responsible for creating
/// a set of related objects, or dependent objects without specifying
/// their concrete classes.
/// </summary>
namespace _2.Abstract_Factory
{
    /// <summary>
    /// The 'AbstractProductA' interface
    /// </summary>
    interface IBike
    {
        string Name();
    }

    /// <summary>
    /// The 'AbstractProductB' interface
    /// </summary>
    interface IScooter
    {
        string Name();
    }

    class RegularBike : IBike
    {
        public string Name()
        {
            return "Regular Bike- Name";
        }
    }

    /// <summary>
    /// The 'ProductA2' class
    /// </summary>
    class SportsBike : IBike
    {
        public string Name()
        {
            return "Sports Bike- Name";
        }
    }

    /// <summary>
    /// The 'ProductB1' class
    /// </summary>
    class RegularScooter : IScooter
    {
        public string Name()
        {
            return "Regular Scooter- Name";
        }
    }

    /// <summary>
    /// The 'ProductB2' class
    /// </summary>
    class Scooty : IScooter
    {
        public string Name()
        {
            return "Scooty- Name";
        }
    }

    /// <summary>
    /// The 'AbstractFactory' interface. 
    /// </summary>
    interface IVehicleFactory
    {
        IBike GetBike(string Bike);
        IScooter GetScooter(string Scooter);
    }

    /// <summary>
    /// The 'ConcreteFactory1' class.
    /// </summary>
    class HondaFactory : IVehicleFactory
    {
        public IBike GetBike(string Bike)
        {
            switch (Bike)
            {
                case "Sports":
                    return new SportsBike();
                case "Regular":
                    return new RegularBike();
                default:
                    throw new ApplicationException(string.Format("Vehicle '{0}' cannot be created", Bike));
            }

        }

        public IScooter GetScooter(string Scooter)
        {
            switch (Scooter)
            {
                case "Sports":
                    return new Scooty();
                case "Regular":
                    return new RegularScooter();
                default:
                    throw new ApplicationException(string.Format("Vehicle '{0}' cannot be created", Scooter));
            }

        }
    }

    /// <summary>
    /// The 'ConcreteFactory2' class.
    /// </summary>
    class HeroFactory : IVehicleFactory
    {
        public IBike GetBike(string Bike)
        {
            switch (Bike)
            {
                case "Sports":
                    return new SportsBike();
                case "Regular":
                    return new RegularBike();
                default:
                    throw new ApplicationException(string.Format("Vehicle '{0}' cannot be created", Bike));
            }

        }

        public IScooter GetScooter(string Scooter)
        {
            switch (Scooter)
            {
                case "Sports":
                    return new Scooty();
                case "Regular":
                    return new RegularScooter();
                default:
                    throw new ApplicationException(string.Format("Vehicle '{0}' cannot be created", Scooter));
            }

        }
    }

    /// <summary>
    /// The 'Client' class 
    /// </summary>
    class VehicleClient
    {
        IBike bike;
        IScooter scooter;

        public VehicleClient(IVehicleFactory factory, string type)
        {
            bike = factory.GetBike(type);
            scooter = factory.GetScooter(type);
        }

        public string GetBikeName()
        {
            return bike.Name();
        }

        public string GetScooterName()
        {
            return scooter.Name();
        }

    }

    /// <summary>
    /// Factory Pattern Demo
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Entry point
        /// </summary>
        /// <param name="args">command line arguments</param>
        static void Main(string[] args)
        {
            IVehicleFactory honda = new HondaFactory();
            VehicleClient hondaclient = new VehicleClient(honda, "Regular");

            Console.WriteLine("******* Honda **********");
            Console.WriteLine(hondaclient.GetBikeName());
            Console.WriteLine(hondaclient.GetScooterName());

            hondaclient = new VehicleClient(honda, "Sports");
            Console.WriteLine(hondaclient.GetBikeName());
            Console.WriteLine(hondaclient.GetScooterName());

            IVehicleFactory hero = new HeroFactory();
            VehicleClient heroclient = new VehicleClient(hero, "Regular");

            Console.WriteLine("******* Hero **********");
            Console.WriteLine(heroclient.GetBikeName());
            Console.WriteLine(heroclient.GetScooterName());

            heroclient = new VehicleClient(hero, "Sports");
            Console.WriteLine(heroclient.GetBikeName());
            Console.WriteLine(heroclient.GetScooterName());

            Console.ReadKey();
        }
    }
}
