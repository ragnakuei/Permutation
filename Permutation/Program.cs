using System;
using System.Collections.Generic;

namespace Permutation
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> source = new List<string>{ "1","2","3","4"};
            Permutation target = new Permutation();
            List<List<string>> result = target.GetResult(source);

            foreach (var item in result)
            {
                foreach (var element in item)
                {
                    Console.Write(element+" ");
                }
                Console.WriteLine();
            }
            Console.ReadLine();
        }
    }
}
