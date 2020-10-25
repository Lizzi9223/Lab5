using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    interface VehicleDoes
    {
        void Sailing(bool a);
    }
    abstract class Vehicle : VehicleDoes
    {
        public string captain { get; set; }
        public sbyte speed { get; set; } 
        public virtual void Display ()
        {
            Console.WriteLine($"This vehicle captain's name is {captain}, speed is {speed} km/h.");
        }
        public bool sailing;
        public virtual void Sailing(bool a)
        {
            if (a) Console.WriteLine("Сейчас судно находится в плавании.");
            else Console.WriteLine("Сейчас судно НЕ находится в плавании.");
        }
    }
    class Ship : Vehicle
    {
        public bool battle_ship;
        public int length;
        public override void Display()
        {
            Console.WriteLine($"Is this ship battle? {battle_ship}. Its length is {length}m.");
        }
        public override void Sailing(bool a)
        {
            if (a) Console.WriteLine("В пути.");
            else Console.WriteLine("Дома.");
        }
    }
    sealed class Steamer : Vehicle
    {
        public int year_of_creation;
        class Steam_engine
        {
            public string type;
        }
    }
    class Boat : Vehicle
    {
        public bool engine;
        public byte capacity;

        public override string ToString()
        {
           return ($"Эта лодка имеет двигатель? {engine}. Вместимоть это лодки равна {capacity} людей.");
        }
        public override bool Equals(object obj)
        {
            if (this.GetType() != obj.GetType())
                return false;
            Boat boat = (Boat)obj;
            if ((this.engine == boat.engine) && (this.capacity == boat.capacity))
                return true;
            else return false;
        }
        public override int GetHashCode()
        {
            return engine.GetHashCode();
        }
    }
    class Sailboat : Ship
    {
        public string sail_color;
        public string sail_material;
    }
    class Corvette : Ship
    {
        public string type;
    }
}
