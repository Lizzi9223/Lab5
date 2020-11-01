using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Info ship = new Ship(false, 76);
            Vehicle boat = new Boat(b : 5);
            Vehicle steamer = new Steamer(2001);
            Info corvette = new Corvette("Ususal");
            VehicleDoes sailboat = new Sailboat("red", "silk");

            // IS
            if (sailboat is Vehicle) Console.WriteLine("ship можно привести к классу Vehicle.");
            else Console.WriteLine("ship нельзя привести к классу Vehicle.");
            if (ship is Corvette) Console.WriteLine("ship можно привести к классу Corvette.");
            else Console.WriteLine("ship нельзя привести к классу Corvette.");
            // AS
            Object check = steamer as Vehicle;
            if (check == null) Console.WriteLine("steamer нельзя привести к классу Vehicle");
            else Console.WriteLine("steamer можно привести к классу Vehicle");
            check = boat as Ship;
            if (check == null) Console.WriteLine("boat нельзя привести к классу Ship\n");
            else Console.WriteLine("boat можно привести к классу Ship\n");

           // var list = (steamer, boat, ship, sailboat, corvette);
            Printer printer = new Printer();
            ArrayList list = new ArrayList();
            list.Add(steamer);
            list.Add(boat);
            list.Add(ship);
            list.Add(sailboat);
            list.Add(corvette);
            for (var i = 0; i < list.Count; i++)
                printer.IAmPrinting(list[i] as Vehicle);
        }
    }
}
