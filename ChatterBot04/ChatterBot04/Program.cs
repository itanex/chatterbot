using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChatterBot04
{
    public class Chatterbot4
    {
        const string ListOfPunc = "?!.;";

        const int NumOfInput = 1;
        const int NumOfResp = 3;

        static string[,] KnowledgeBase = 
        {
			{
                "WHAT IS YOUR NAME", 
                "MY NAME IS CHATTERBOT4.",
                "YOU CAN CALL ME CHATTERBOT4.",
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

        static string preProcessInput()
        {
            return cleanString(Console.ReadLine().ToUpperInvariant());
        }

        static List<string> findMatch(string str)
        {
            List<string> result = new List<string>(NumOfResp);

            for (int i = 0; i < KnowledgeBase.GetUpperBound(0); ++i)
            {
                // there has been some improvements made in
                // here in order to make the matching process
                // a little bit more flexible
                if (str.IndexOf(KnowledgeBase[i, 0]) != -1)
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
            Console.Title = "Chatterbot4";

            string sResponse = "";
            string sInput = "";

            while (true)
            {
                Console.Write(">");
                string sPrevInput = sInput;
                string sPrevResponse = sResponse;

                //sInput = Console.ReadLine().ToUpperInvariant();
                //preProcessInput(ref sInput);
                sInput = preProcessInput();

                List<string> responses = new List<string>(NumOfResp);
                responses = findMatch(sInput);

                if (sPrevInput.Equals(sInput) && sPrevInput.Length > 0)
                {
                    // controlling repetitions made by the user
                    Console.WriteLine("YOU ARE REPEATING YOURSELF.");
                }
                else if (sInput.IndexOf("BYE") != -1)
                {
                    Console.WriteLine("IT WAS NICE TALKING TO YOU USER, SEE YOU NEXT TIME!");
                    Console.In.Read();
                    break;
                }
                else if (responses.Count == 0)
                {
                    // handles the case when the program doesn't understand what the user is talking about	
                    Console.WriteLine("I'M NOT SURE IF I UNDERSTAND WHAT YOU ARE TALKING ABOUT.");
                }
                else
                {
                    Random generator = new Random();
                    int nSelection = generator.Next(0, NumOfResp);
                    sResponse = responses[nSelection];

                    // avoids repeating the same response
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
