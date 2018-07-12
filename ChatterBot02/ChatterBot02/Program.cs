using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChatterBot02
{
    class Program
    {
        static string[,] KnowledgeBase = 
        {
            {
                "WHAT IS YOUR NAME", 
		        "MY NAME IS CHATTERBOT2."
		    },
		    {
                "HI", 
		        "HI THERE!",
		    },
		    {
                "HOW ARE YOU", 
		        "I'M DOING FINE!"
		    },
		    {
                "WHO ARE YOU", 
		        "I'M AN A.I PROGRAM."
		    },
		    {
                "ARE YOU INTELLIGENT", 
		        "YES, OF COURSE."
		    },
		   
		    {
                "ARE YOU REAL", 
		        "DOES THAT QUESTION REALLY MATTER TO YOU?"
		    },
        };

        static string FindMatch(string str)
        {
            string result = "";
            for (int i = 0; i <= KnowledgeBase.GetUpperBound(0); ++i)
            {
                if (KnowledgeBase[i, 0].Equals(str))
                {
                    result = KnowledgeBase[i, 1];
                    break;
                }
            }
            return result;
        }

        static void Main(string[] args)
        {
            Console.Title = "Chatterbot2";

            while (true)
            {
                Console.Write(">");
                string sInput = Console.ReadLine().ToUpperInvariant();
                string sResponse = FindMatch(sInput);

                if (sInput.Contains("BYE"))
                {
                    Console.WriteLine("IT WAS NICE TALKING TO YOU USER, SEE YOU NEXT TIME!");
                    Console.In.Read();
                    break;
                }
                else if (sResponse.Length == 0)
                {
                    Console.WriteLine("I'M NOT SURE IF I UNDERSTAND WHAT YOU  ARE TALKING ABOUT.");
                }
                else
                {
                    Console.WriteLine(sResponse);
                }
            }

        }
    }
}
