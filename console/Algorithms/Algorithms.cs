using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace DeveloperSample.Algorithms
{
    public static class Algorithms
    {
        public static int GetFactorial(int input)
        {
            if (input < 0)
            {
                throw new ArgumentException("Input arg must be whole number 0 or greater.");
            }

            if(input == 0) { return 1; }

            int product = input;
            while (input > 1)
            {
                input--;
                product *= input;
                if (product > int.MaxValue || product < 0)
                {
                    throw new ArgumentException($"You entered {input}.  Product is too big for return datatype int.  Try something less than 13.");
                }
            }
            return product;
        }



        public static string FormatSeparators(params string[] items)
        {
            if (items.Length < 1) { return string.Empty; }
            if (items.Length == 1) { return items[0]; }
            if (items.Length == 2) { return $"{items[0]} and {items[1]}"; }
            if (items.Length == 3) { return $"{items[0]}, {items[1]} and {items[2]}"; }

            string[] allButLast = items.Take(items.Length - 3).ToArray();
            var csv = string.Join(", ", allButLast);
            csv += $", {items[items.Length - 3]}, {items[items.Length - 2]} and {items[items.Length - 1]}";

            return csv;
        }
    }
}