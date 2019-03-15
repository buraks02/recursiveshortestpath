using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace consoleShortestPath
{
    class Program
    {
        static int choice = 0;

        static void Main(string[] args)
        {
            Walker walker = new Walker();
            string startingPoint, endingPoint, targetPoint, sDistance;
            double distance;

            while (choice != 3)
            {
                DisplayMenu();
                switch (choice)
                {
                    case 1 :
                        Console.WriteLine("Enter starting point : ");
                        startingPoint = Console.ReadLine();
                        Console.WriteLine("Enter ending point : ");
                        endingPoint = Console.ReadLine();
                        Console.WriteLine("Enter distance : ");
                        sDistance = Console.ReadLine();
                        double.TryParse(sDistance,out distance);
                        walker.AddPath(startingPoint, endingPoint, distance);
                        break;
                    case 2:
                        Console.WriteLine("Enter starting point of walker");
                        startingPoint  = Console.ReadLine();
                        walker.StartingPoint = startingPoint;
                        Console.WriteLine("Enter target point of walker");
                        targetPoint  = Console.ReadLine();
                        walker.TargetPoint = targetPoint;
                        walker.ExperiencePaths();
                        walker.DisplayShortestPath();
                        break;
                    default:
                        break;
                }
            }
        }

        static void DisplayMenu()
        {
            Console.WriteLine("1. Add Path");
            Console.WriteLine("2. Calculate Shortest Path");
            Console.WriteLine("3. Exit");
            int.TryParse(Console.ReadLine(),out  choice );
        }
    }
}
