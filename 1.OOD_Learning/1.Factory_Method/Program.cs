// <copyright file="Program.cs" company="NuvoLetta">
// Copyright (c) 2017 All Rights Reserved
// </copyright>
// <author>Julia Hrytsyk</author>

using System;

/// <summary>
/// In Factory pattern, we create object without exposing the creation
/// logic. In this pattern, an interface is used for creating an object, 
/// but let subclass decide which class to instantiate. The creation of 
/// object is done when it is required. The Factory method allows a class 
/// later instantiation to subclasses.
/// </summary>
namespace _1.Factory_Method
{
    /// <summary>
    /// The 'Product' interface
    /// </summary>
    public interface IFactory
    {
        /// <summary>
        /// Driving implementation
        /// </summary>
        /// <param name="miles">Driving distance</param>
        void Drive(int miles);
    }

    /// <summary>
    /// A 'ConcreteProduct' class
    /// </summary>
    public class Scooter : IFactory
    {
        /// <inheritdoc />
        public void Drive(int miles)
        {
            Console.WriteLine("Drive the Scooter : " + miles.ToString() + "km");
        }
    }

    /// <summary>
    /// A 'ConcreteProduct' class
    /// </summary>
    public class Bike : IFactory
    {
        /// <inheritdoc />
        public void Drive(int miles)
        {
            Console.WriteLine("Drive the Bike : " + miles.ToString() + "km");
        }
    }

    /// <summary>
    /// The Creator Abstract Class
    /// </summary>
    public abstract class VehicleFactory
    {
        /// <summary>
        /// Provide instance of Vehicle object
        /// </summary>
        /// <param name="vehicle">vehicle identifier to be instanced</param>
        /// <returns>Vehicle instance</returns>
        public abstract IFactory GetVehicle(string vehicle);

    }

    /// <summary>
    /// A 'ConcreteCreator' class
    /// </summary>
    public class ConcreteVehicleFactory : VehicleFactory
    {
        /// <inheritdoc />
        public override IFactory GetVehicle(string vehicle)
        {
            switch (vehicle)
            {
                case "Scooter":
                    return new Scooter();
                case "Bike":
                    return new Bike();
                default:
                    throw new ApplicationException(string.Format("Vehicle '{0}' cannot be created", vehicle));
            }
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
        public static void Main(string[] args)
        {
            VehicleFactory factory = new ConcreteVehicleFactory();

            IFactory scooter = factory.GetVehicle("Scooter");
            scooter.Drive(10);

            IFactory bike = factory.GetVehicle("Bike");
            bike.Drive(20);

            Console.ReadKey();

        }
    }
}
