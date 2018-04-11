using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChatterBot01
{
    class Program
    {
        static string[] Response = {
		                    "I HEARD YOU!",
		                    "SO,YOU ARE TALKING TO ME.",
		                    "CONTINUE,I'M LISTENING.",
		                    "VERY INTERESTING CONVERSATION.",
		                    "TELL ME MORE..."
	                    };

        static string sInput = "";
        static string sResponse = "";

        static void Main(string[] args)
        {
            Console.Title = "Chatterbot1";

            while (true)
            {
                Console.Write(">");
                sInput = Console.ReadLine();

                Random generator = new Random();
                int nSelection = generator.Next(0, 5);
                sResponse = Response[nSelection];

                if (sInput.ToUpperInvariant().Equals("BYE"))
                {
                    Console.WriteLine("IT WAS NICE TALKING TO YOU USER, SEE YOU NEXT TIME!");
                    Console.In.Read();
                    break;
                }

                Console.WriteLine(sResponse);
            }
        }
    }
}
