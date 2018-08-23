using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uri1611
{
    class Program
    {
        static void Main(string[] args)
        {
            int testCase = Convert.ToInt32(Console.ReadLine());

            for (int y = 0; y < testCase; y++)
            {
                string firstLine = Console.ReadLine();
                string[] variables = firstLine.Split(' ');
                int totalFloors = Convert.ToInt32(variables[0]);
                int capacity = Convert.ToInt32(variables[1]);
                int group = Convert.ToInt32(variables[2]);

                string floors = Console.ReadLine();
                string[] visitFloors = floors.Split(' ');
                List<string> floorsList = new List<string>();
                floorsList.AddRange(visitFloors);
                //List<int> numberFloor = floorsList.ConvertAll(new Converter<string, int>(StringToInt));
                List<int> numberFloor = floorsList.Select(s => Convert.ToInt32(s)).ToList();
                numberFloor.Sort();
                numberFloor.Reverse();

                bool pass = true;

                int maxFloor = 0;
                for (int i = 0; i < group; i++) //OK
                {
                    if (numberFloor[i] > maxFloor)
                    {
                        maxFloor = numberFloor[i];
                    }
                    if (maxFloor > totalFloors)
                    {
                        Console.WriteLine("Invalid Floor, out of range");
                        Console.ReadLine();
                        pass = false;
                        break;
                    }
                }

                //DisplayListFloor(floorsList);
                //DisplayNumberFloor(numberFloor);

                int energy = 0;
                if (pass == true)
                {
                    int remove = 0;
                    while (numberFloor.Count != 0)
                    {
                        int energyBase = numberFloor[0];
                        if (numberFloor.Count >= capacity)
                        {
                            numberFloor.RemoveRange(remove, capacity);
                        }
                        else
                        {
                            numberFloor.RemoveRange(remove, numberFloor.Count);
                        }
                        energy += (energyBase * 2);
                    }
                    DisplayEnergy(energy);
                }
            }
        }

        private static void DisplayEnergy(int show)
        {
            Console.WriteLine(show);
        }
        private static void DisplayListFloor(List<string> floorsList)
        {
            Console.WriteLine();
            foreach (string floor in floorsList)
            {
                Console.WriteLine(floor);
            }
        }
        private static void DisplayNumberFloor(List<int> numberFloor)
        {
            Console.WriteLine();
            foreach (int floor in numberFloor)
            {
                Console.WriteLine(floor);
            }
        }
    }
}
