namespace APBD2;

using Transports;
using Containers;
using Containers.Abstract;
using Enums;
using System;

class Program
{
    static void Main(string[] _)
    {
        Console.WriteLine("Container Ship Management");

        ContainerShip ship1 = new ContainerShip(30, 10, 500);
        ContainerShip ship2 = new ContainerShip(25, 15, 700);

        Console.WriteLine("Two ships were created:");
        Console.WriteLine(ship1);
        Console.WriteLine(ship2);

        Container container1 = new RefrigeratedContainer(2.5, 6, 2, 10, ProductType.Fish, 2.0);
        Container container2 = new GasContainer(3, 6, 3, 12, 15);
        Container container3 = new LiquidContainer(2.8, 6, 2.5, 11, true);

        Console.WriteLine("Three containers were created:");
        Console.WriteLine(container1);
        Console.WriteLine(container2);
        Console.WriteLine(container3);

        try
        {
            ship1.LoadContainer(container1);
            ship1.LoadContainer(container2);
            Console.WriteLine("Containers successfully loaded.");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error: {e.Message}");
        }

        Console.WriteLine("\nShip details after loading:");
        Console.WriteLine(ship1);

        try
        {
            //ship1.TransferContainer(ship2, container1.SerialNumber);
            Container unloadContainer = ship1.UnloadContainer(container1.SerialNumber);
            ship2.LoadContainer(unloadContainer);
            Console.WriteLine($"Container {unloadContainer.SerialNumber} transferred.");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error: {e.Message}");
        }

        Console.WriteLine("\nFinal ship statuses:");
        Console.WriteLine(ship1);
        Console.WriteLine(ship2);

        try
        {
            Container container4 = new GasContainer(2.5, 6, 2, 10, 12);
            ship1.ReplaceContainer(container2.SerialNumber, container4);
            Console.WriteLine($"Container {container2.SerialNumber} replaced with {container4.SerialNumber}.");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error: {e.Message}");
        }

        Console.WriteLine("\nShip details after container replacement:");
        Console.WriteLine(ship1);
    }
}