using System;

namespace DiceRollingSimulator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the dice throwing simulator!");

            Console.Write("How many dice rolls would you like to simulate? ");
            int numberOfRolls = int.Parse(Console.ReadLine());

            var simulator = new DiceSimulator();
            int[] results = simulator.SimulateDiceRolls(numberOfRolls);

            Console.WriteLine("DICE ROLLING SIMULATION RESULTS");
            Console.WriteLine("Each \"*\" represents 1% of the total number of rolls.");
            Console.WriteLine($"Total number of rolls = {numberOfRolls}.");

            for (int i = 2; i <= 12; i++)
            {
                int percentage = results[i] * 100 / numberOfRolls;
                Console.Write($"{i}: ");
                Console.WriteLine(new String('*', percentage));
            }

            Console.WriteLine("Thank you for using the dice throwing simulator. Goodbye!");
        } 
    }

    class DiceSimulator
    {
        private Random random = new Random();

        public int[] SimulateDiceRolls(int numberOfRolls)
        {
            int[] results = new int[13]; // Indices 0 and 1 are unused

            for (int i = 0; i < numberOfRolls; i++)
            {
                int roll1 = random.Next(1, 7);
                int roll2 = random.Next(1, 7);
                results[roll1 + roll2]++;
            }

            return results;
        }
    }
}
