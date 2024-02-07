using System;

namespace Meth
{
    public class Car
    {
        public static void Plugingkey()
        {
            Thread.Sleep(5000);
            Console.WriteLine("Key is insterted");
        }
        public static void Ignitationstarts()
        {
            Thread.Sleep(6000);
            Console.WriteLine("Ignitation Starts");
        }
        public static void EngineStarts()
        {
            Thread.Sleep(8000);
            Console.WriteLine("Engine is started Ready to go");
        }
        public static void EngineStopped()
        {
            Thread.Sleep(4000);
            Console.WriteLine("Engine is stopped");
        }
    }

    public class city : Car
    {
        public static async void Tvl()
        {
            await Task.Run(() =>
            {
                Thread.Sleep(4000);
                Console.WriteLine("Welcome to Thirunelveli");
            });
        }
        public static async void Tuty()
        {
            await Task.Run(() =>
            { 
               Thread.Sleep(6000);
               Console.WriteLine("Welcome to Tuticorin");
            });
        }
        public static async void Chennai()
        {
            await Task.Run(() =>
            {
                Thread.Sleep(3000);
                Console.WriteLine("Welcome to Chennai");
            });
        }

    }

    class AA1 :city
    {
        public static void Main(string[] args)
        {
            Car.Plugingkey();
            Car.Ignitationstarts();
            Car.EngineStarts();
            Car.EngineStopped();
            Console.WriteLine("----------Async Function------------");
            city.Tvl();
            city.Tuty();
            city.Chennai();
            Console.ReadKey();

        }
    }
}