using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace ConsoleApp1
{
    interface Info
    {
        bool WannaBuy();
    }
    interface VehicleDoes
    {
        void Sailing(bool a);
    }
    abstract class Vehicle : VehicleDoes
    {
        public abstract bool WannaBuy();
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
    class Ship : Vehicle, Info
    {
        public bool battle_ship;
        public int length;
        public Ship(bool a = false, int b = 0)
        {
            battle_ship = a;
            length = b;
        }
        public override void Display()
        {
            Console.WriteLine($"Is this ship battle? {battle_ship}. Its length is {length}m.");
        }
        public override void Sailing(bool a)
        {
            if (a) Console.WriteLine("В пути.");
            else Console.WriteLine("Дома.");
        }
        bool Info.WannaBuy()
        {
            return true;
        }
        public override bool WannaBuy()
        {
            return false;
        }        
        public override string ToString()
        {
            return ($"Тип объекта = {this.GetType()}; Имя капитана = {captain}; Скорость судна = {speed}; Судно сейчас находится в плавании? {sailing}; " +
                        $"\nЭто боевое судно? {battle_ship}; Длина судна = {length}м.");
        }
    }
    sealed class Steamer : Vehicle
    {
        public int year_of_creation;
        public Steamer (int a)
        {
            year_of_creation = a;
        }
        class Steam_engine
        {
            public string type;
        }
        public override bool WannaBuy()
        {
            return false;
        }
        public override string ToString()
        {
            return ($"Тип объекта = {this.GetType()}; Имя капитана = {captain}; Скорость судна = {speed}; Судно сейчас находится в плавании? {sailing}; " +
                        $"\nГод создания -  {year_of_creation}.");
        }
    }
    class Boat : Vehicle
    {
        public bool engine;
        public byte capacity;
        public Boat(bool a = false, byte b = 0)
        {
            engine = a;
            capacity = b;
        }
        public override string ToString()
        {
            return ($"Тип объекта = {this.GetType()}; Имя капитана = {captain}; Скорость судна = {speed}; Судно сейчас находится в плавании? {sailing}; " +
                        $"Эта лодка имеет двигатель? {engine}. Вместимоть это лодки равна {capacity} людей.");
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
        public override bool WannaBuy()
        {
            return false;
        }
    }
    class Sailboat : Ship
    {
        public string sail_color;
        public string sail_material;
        public Sailboat(string a = "", string b = "")
        {
            sail_color = a;
            sail_material = b;
        }
        public override string ToString()
        {
            return ($"Тип объекта = {this.GetType()}; Имя капитана = {captain}; Скорость судна = {speed}; Судно сейчас находится в плавании? {sailing}; " +
                         $"\nЭто боевое судно? {battle_ship}; Длина судна = {length}м. Цвет парусов - {sail_color}; Материал парусов - {sail_material}.");
        }
    }
    class Corvette : Ship
    {
        public string type;
        public Corvette (string s)
        {
            type = s;
        }
        public override string ToString()
        {
            return ($"Тип объекта = {this.GetType()}; Имя капитана = {captain}; Скорость судна = {speed}; Судно сейчас находится в плавании? {sailing}; " +
                        $"\nЭто боевое судно? {battle_ship}; Длина судна = {length}м. Тип корвета - {type}.");
        }
    }
    class Printer
    {
        public void IAmPrinting (Vehicle obj)
        {
            Console.WriteLine(obj.GetType());
            Console.WriteLine(obj.ToString());
        }
    }
}
