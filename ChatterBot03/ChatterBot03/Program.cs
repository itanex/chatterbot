using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChatterBot03
{
    public class Chatterbot3
    {
        const string ListOfPunc = "?!.;,";

        const int NumOfInput = 1;
        const int NumOfResp = 3;

        static string[,] KnowledgeBase = 
        {
            {
                "WHAT IS YOUR NAME", 
                "MY NAME IS CHATTERBOT2.",
                "YOU CAN CALL ME CHATTERBOT2.",
                "WHY DO YOU WANT TO KNOW MY NAME?"
            },
            {
                "HI", 
                "HI THERE!",
                "HOW ARE YOU?",
                "HI!"
            },
            {
                "HOW ARE YOU",
                "I'M DOING FINE!",
                "I'M DOING WELL AND YOU?",
                "WHY DO YOU WANT TO KNOW HOW AM I DOING?"
            },
            {
                "WHO ARE YOU",
                "I'M AN A.I PROGRAM.",
                "I THINK THAT YOU KNOW WHO I'M.",
                "WHY ARE YOU ASKING?"
            },
            {
                "ARE YOU INTELLIGENT",
                "YES,OFCORSE.",
                "WHAT DO YOU THINK?",
                "ACTUALY,I'M VERY INTELLIGENT!"
            },
            {
                "ARE YOU REAL",
                "DOES THAT QUESTION REALLY MATERS TO YOU?",
                "WHAT DO YOU MEAN BY THAT?",
                "I'M AS REAL AS I CAN BE."
            }
        };

        static bool isPunc(char ch)
        {
            return ListOfPunc.IndexOf(ch) != -1;
        }
		
        // removes punctuation and redundant
        // spaces from the user's input
        static string cleanString(string str)
        {
            string temp = "";
            char prevChar = '#';

            for (int i = 0; i < str.Length; ++i)
            {
                if (str[i] == ' ' && prevChar == ' ')
                {
                    continue;
                }
                else if (!isPunc(str[i]))
                {
                    temp = String.Concat(temp, str[i]);
                }

                prevChar = str[i];
            } 
			
			return temp;
        }


        static List<string> findMatch(string str)
        {
            List<string> result = new List<string>(NumOfResp);
			
            for (int i = 0; i < KnowledgeBase.GetUpperBound(0); ++i)
            {
                if (KnowledgeBase[i, 0].Equals(str))
                {
                    for (int j = NumOfInput; j <= NumOfResp; ++j)
                    {
                        result.Add(KnowledgeBase[i, j]);
                    }
                    break;
                }
            }
            return result;
        }

        /**
         * @param args
         */
        public static void Main()
        {
            Console.Title = "Chatterbot3";
			
            string sResponse = "";
			
            while (true)
            {
                Console.Write(">");
                string sInput = Console.ReadLine().ToUpperInvariant();
                sInput = cleanString(sInput);

                List<string> responses = new List<string>(NumOfResp);
                responses = findMatch(sInput);

                if (sInput.Equals("BYE"))
                {
                    Console.WriteLine("IT WAS NICE TALKING TO YOU USER, SEE YOU NEXT TIME!");
                    Console.In.Read();
                    break;
                }
                else if (responses.Count == 0)
                {
                    Console.WriteLine("I'M NOT SURE IF I UNDERSTAND WHAT YOU ARE TALKING ABOUT.");
                }
                else
                {
                    Random generator = new Random();
                    int nSelection = generator.Next(0, NumOfResp);
                    string sPrevResponse = sResponse;
                    sResponse = responses[nSelection];

                    if (sResponse == sPrevResponse)
                    {
                        responses.RemoveAt(nSelection);
                        nSelection = generator.Next(0, NumOfResp - 1);
                        sResponse = responses[nSelection];
                    }

                    Console.WriteLine(sResponse);
                }
            }
        }
    }
}
