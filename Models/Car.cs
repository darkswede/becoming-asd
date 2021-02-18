using System;
using System.Collections.Generic;

namespace becoming_asd.Models
{
    public abstract class Car
    {
        public double Speed { get; protected set; } = 100;
        public double Acceleration { get; protected set; } = 10;

        public void Start()
        {
            Console.WriteLine("Turning on the engine..");
            Console.WriteLine($"Running at: {Speed} km/h ");
        }

        public void Stop()
        {
            Console.WriteLine("Stopping the car..");
        }

        public virtual void Accelerate()
        {
            Speed += Acceleration;
            Console.WriteLine($"Running at: {Speed} km/h ");
        }

        public abstract void Boost();
    }

    public class Truck : Car
    {
        public override void Accelerate()
        {
            Console.WriteLine("Accelerating a Truck..");
            base.Accelerate();
        }

        public override void Boost()
        {
            Console.WriteLine("Boosting a Truck..");
            Speed += 30;
            Console.WriteLine($"Running at: {Speed} km/h ");
        }
    }

    public class SportCar : Car
    {
        public override void Accelerate()
        {
            Console.WriteLine("Accelerating a SportCar..");
            base.Accelerate();
        }

        public override void Boost()
        {
            Console.WriteLine("Boosting a SportCar..");
            Speed += 80;
            Console.WriteLine($"Running at: {Speed} km/h ");
        }
    }

    public class Race
    {
        public void Begin()
        {
            SportCar sportCar = new SportCar();
            Truck truck = new Truck();

            List<Car> cars = new List<Car>
            {
                sportCar, truck   //przypisanie obiektow do listy w tym miejscu
            };

            foreach (Car car in cars)
            {
                car.Start();
                car.Accelerate();
                car.Boost();
            }
        }
    }
}