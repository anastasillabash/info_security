using System;

public class Random_Generator
{
    public static void Main()
    {
        Console.WriteLine("The amount of numbers: ");
        int amount = Convert.ToInt32(Console.ReadLine()); //кількість чисел для генерації

        Console.WriteLine("Minimum of range: ");
        int min = Convert.ToInt32(Console.ReadLine()); //мінімум

        Console.WriteLine("Maximum of range: ");
        int max = Convert.ToInt32(Console.ReadLine()); //максимум

        Console.WriteLine(" ");

        if (max > min) //перевірка на правильність вводу чисел
        {
            Random rnd = new Random();
            for (int i = 0; i < amount; i++)
            {
                Console.WriteLine(rnd.Next(min, max) + " ");
            }
        }
        else
        {
            Console.WriteLine("Wrong minimum/maximum");
        }
        Console.ReadLine();
    }

};
