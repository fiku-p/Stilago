using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models.Task1
{
    public static class GenerateRandomNumbers
    {
        public static List<int> Generate(int length)
        {
            var result = new List<int>();

            var random = new Random();

            for (int i = 0; i < length; i++)
            {
                result.Add(random.Next(1, 1000));
            }

            result = result.OrderBy(x => x).ToList();

            return result;
        }
    }
}