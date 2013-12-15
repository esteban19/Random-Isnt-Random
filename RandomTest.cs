using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomTestAlg
{
    class RandomTest
    {
        static void Main(string[] args)
        {
            Random r = new Random();
            List<int> container = new List<int>();

            int dice_sides = 6;//obviously, the number of sides your dice has[You can change this]
            int number_of_throws = 100;//obviously, how many times you'll throw the dice[You can change this]
            const int placement = 5;//Just print [placement] results per line in the Console window(readability)

            //There will be [dice_sides] number of possible results (eg. 6 sides, each marked 0-5)
            int[] di = new int[dice_sides];
            
            //Throw the dice [number_of_throws] times and and record the value of each throw in one [container].
            for (int i = 0; i < number_of_throws; i++)
            {
                container.Add(r.Next(dice_sides));
                //container.Add(r.Next(dice_sides));
            }

            //If that dice_side gets rolled, record it.
            foreach (int i in container)
            {
                di[i] = di[i] + 1;
            }

            //Results of throws printed in the format: "di[side_of_dice]=how many it successfully came up"
            int placement_const = 0;
            for (int i = 0; i < dice_sides; i++)
            {
                if (placement_const < placement)
                {
                    Console.Write("di[{0}]={1} ", i, di[i]);
                    placement_const++;
                }
                else
                {
                    Console.WriteLine();
                    Console.Write("di[{0}]={1} ", i, di[i]);
                    placement_const = 1;//0+1 because we wrote a new value.
                }   
            }
            Console.WriteLine();

            //Find the average of all throws, this should be (a little) off, but it ISN'T!
            int sum_of_all_occurrences = 0;
            decimal avg_of_all_occurrences = 0.0m;
            for (int i = 0; i < dice_sides; i++)//remember dice_sides is the divisor
            {
                sum_of_all_occurrences = sum_of_all_occurrences + di[i];
            }
            avg_of_all_occurrences = (decimal)sum_of_all_occurrences / (decimal)dice_sides;
            //Print results
            Console.WriteLine("Of all the {0} dice_sides results,\n the avg of all occurrences is: {1}", dice_sides, avg_of_all_occurrences);
            Console.WriteLine("-----");
            Console.WriteLine("This means random isn't really random because the avg of\n  all occurrences({0}) x dice_sides({1}) is\n   exactly ({2})!", 
                avg_of_all_occurrences, dice_sides, avg_of_all_occurrences*dice_sides);
        }
    }
}
