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

        public void DisplayInfo()
        {
            Console.WriteLine("im displaying");
        }
    }

    public class Race
    {
        public void Begin()
        {
            Car sportCar = new SportCar();
            Car truck = new Truck();

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

        public void Casting()
        {
            Car sportCar = new SportCar();
            Car truck = new Truck();

            /*realSportCar.DisplayInfo(); nie da sie 

            SportCar realSportCar = (SportCar) sportCar;
            realSportCar.DisplayInfo();po rzutowaniu, mozna normalnie uzywac --- downcasting

            Car realCar = (Car) realSportCar;  upcasting --- brak zgodnosci typow albo null i sie posypie apka
            

            bool isSportCar = sportCar is SportCar;
            if (isSportCar)
            {
                ((SportCar)sportCar).DisplayInfo();
            }
            */

            SportCar castedSportCar = sportCar as SportCar;
            if (castedSportCar != null)
            {
                castedSportCar.DisplayInfo();
            }
        }
    }
}