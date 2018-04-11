using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChatterBot05
{
    class Chatterbot5
    {

        private static string sInput = "";
        private static string sResponse = "";
        private static string sPrevInput = "";
        private static string sPrevResponse = "";
        private static string sEvent = "";
        private static string sPrevEvent = "";
        private static string sInputBackup = "";
        static bool bQuitProgram = false;

        const int maxInput = 1;
        const int maxResp = 4;
        const string delim = "?!.;";

        static string[,] KnowledgeBase = 
        {
			{
                "WHAT IS YOUR NAME", 
                "MY NAME IS CHATTERBOT5.",
                "YOU CAN CALL ME CHATTERBOT5.",
                "WHY DO YOU WANT TO KNOW MY NAME?"
			},
			{
                "HELLO",
			    "HI THERE!"
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
                "ACTUALY,I'M VERY INTELLIENT!"
			},
			{
                "ARE YOU REAL",
                "DOES THAT QUESTION REALLY MATERS TO YOU?",
                "WHAT DO YOU MEAN BY THAT?",
                "I'M AS REAL AS I CAN BE."
            },
			{
                "REPETITION T1**",
                "YOU ARE REPEATING YOURSELF.",
                "USER, PLEASE STOP REPEATING YOURSELF.",
                "THIS CONVERSATION IS GETING BORING.",
                "DONT YOU HAVE ANY THING ELSE TO SAY?"
			},
			{
                "REPETITION T2**",
                "YOU'VE ALREADY SAID THAT.",
                "I THINK THAT YOU'VE JUST SAID THE SAME THING BEFORE.",
                "DIDN'T YOU ALREADY SAID THAT?",
                "I'M GETING THE IMPRESSION THAT YOU ARE REPEATING THE SAME THING."
			},

			{
                "BOT DONT UNDERSTAND**",
                "I HAVE NO IDEA OF WHAT YOU ARE TALKING ABOUT.",
                "I'M NOT SURE IF I UNDERSTAND WHAT YOU ARE TALKING ABOUT.",
                "CONTINUE, I'M LISTENING...",
                "VERY GOOD CONVERSATION!"
			},

			{
                "NULL INPUT**",
                "HUH?",
                "WHAT THAT SUPPOSE TO MEAN?",
                "AT LIST TAKE SOME TIME TO ENTER SOMETHING MEANINGFUL.",
                "HOW CAN I SPEAK TO YOU IF YOU DONT WANT TO SAY ANYTHING?"
			},
			{
                "NULL INPUT REPETITION**",
                "WHAT ARE YOU DOING??",
                "PLEASE STOP DOING THIS IT IS VERY ANNOYING.",
                "WHAT'S WRONG WITH YOU?",
                "THIS IS NOT FUNNY."
			},
			{
                "BYE",
                "IT WAS NICE TALKING TO YOU USER, SEE YOU NEXT TIME!",
                "BYE USER!",
                "OK, BYE!"
			},
			{
                "ARE YOU A HUMAN BEING",
                "WHY DO YOU WANT TO KNOW?",
                "IS THIS REALLY RELEVENT?"
			},
			{
                "YOU ARE VERY INTELLIGENT",
                "THANKS FOR THE COMPLIMENT USER, I THINK THAT YOU ARE INTELLIGENT TO!",
                "YOU ARE A VERY GENTLE PERSON!",
                "SO, YOU THINK THAT I'M INTELLIGENT."
			},
			{
                "ARE YOU SURE",
                "OFCORSE I'M.",
                "IS THAT MEAN THAT YOU ARE NOT CONVINCED?",
                "YES,OFCORSE!"
			},
			{
                "WHO IS",
                "I DONT THINK I KNOW WHO.",
                "DID YOU ASK SOMEONE ELSE ABOUT IT?",
                "WOULD THAT CHANGE ANYTHING AT ALL IF I TOLD YOU WHO."
			},
			{
                "WHAT",
                "I DONT KNOW.",
                "I DONT THINK I KNOW.",
                "I HAVE NO IDEA."
			},
			{
                "WHERE",
                "WHERE? WELL,I REALLY DONT KNOW.",
                "DOES THAT MATERS TO YOU TO KNOW WHERE?",
                "PERHAPS,SOMEONE ELSE KNOWS WHERE."
			},
			{
                "WHY",
                "I DONT THINK I KNOW WHY.",
                "WHY ARE YOU ASKING ME THIS?",
                "SHOULD I KNOW WHY.",
                "THIS WOULD BE DIFFICULT TO ANSWER."
			},
			{
                "DO YOU",
                "I DONT THINK I DO",
                "I WOULDN'T THINK SO.",
                "WHY DO YOU WANT TO KNOW?"
			},
			{
                "CAN YOU",
                "I THINK NOT.",
                "I'M NOT SURE.",
                "I DONT THINK THAT I CAN DO THAT."
			},
			{
                "YOU ARE",
                "WHAT MAKES YOU THINK THAT?",
                "IS THIS A COMPLIMENT?",
                "ARE YOU MAKING FUN OF ME?"
			},
			{
                "DID YOU",
                "I DONT THINK SO.",
                "ANYWAY, I WOULDN'T REMEMBER EVEN IF I DID."
			},
			{
                "COULD YOU",
                "ARE YOU ASKING ME FOR A FEVER?",
                "WELL,LET ME THINK ABOUT IT.",
                "SORRY,I DONT THINK THAT I COULD DO THIS."
			},
			{
                "WOULD YOU",
                "IS THAT AN INVITATION?",
                "I WOULD HAVE TO THINK ABOUT IT FIRST."
			},
			{
                "HOW",
                "I DONT THINK I KNOW HOW."
			},
			{
                "WHICH ONE",
                "I DONT THINK THAT I KNOW WICH ONE IT IS.",
                "THIS LOOKS LIKE A TRICKY QUESTION TO ME."
			},
			{
                "PERHAPS",
                "WHY ARE YOU SO UNCERTAIN?",
                "YOU SEEMS UNCERTAIN."
			},
			{
                "YES",
                "SO,IT IS YES.",
                "OH, REALLY?",
                "OK THEN."
			},
			{
                "I DONT KNOW",
                "ARE YOU SURE?",
                "ARE YOU REALLY TELLING ME THE TRUTH?",
                "SO,YOU DONT KNOW?"
			},
			{
                "NOT REALLY",
                "OK I SEE.",
                "YOU DONT SEEM PRETTY CERTAIN.",
                "SO,THAT WOULD BE A \"NO\"."
			},
			{
                "IS THAT TRUE",
                "I CAN'T BE QUIET SURE ABOUT THIS.",
                "CAN'T TELL YOU FOR SURE.",
                "DOES THAT REALLY MATERS TO YOU?"
			},
			{
                "YOU",
                "SO,YOU ARE TALKING ABOUT ME.",
                "WHY DONT WE TALK ABOUT YOU INSTEAD?",
                "ARE YOU TRYING TO MAKING FUN OF ME?"
			},
			{
                "THANKS",
                "YOU ARE WELCOME!",
                "NO PROBLEM!"
			},
			{
                "WHAT ELSE",
                "WELL,I DONT KNOW.",
                "WHAT ELSE SHOULD THERE BE?",
                "THIS LOOKS LIKE A COMPLICATED QUESTION TO ME."
			},
			{
                "SORRY",
                "YOU DONT NEED TO BE SORRY USER.",
                "IT'S OK.",
                "NO NEED TO APOLOGIZE."
			},
			{
                "NOT EXACTLY",
                "WHAT DO YOU MEAN NOT EXACTLY?",
                "ARE YOU SURE?"
			},
			{
                "EXACTLY",
                "SO,I WAS RIGHT.",
                "OK THEN."
			},
			{
                "ALRIGHT",
                "ALRIGHT THEN.",
                "OK THEN."
			},
			{
                "I DONT",
                "WHY NOT?",
                "AND WHAT WOULD BE THE REASON FOR THIS?"
			},
			{
                "REALLY",
                "WELL,I CAN'T TELL YOU FOR SURE.",
                "ARE YOU TRYING TO CONFUSE ME?",
                "PLEASE DONT ASK ME SUCH QUESTION,IT GIVES ME HEADEACHS."
			}                        
        };


        private static List<string> respList = new List<string>(maxResp);

        public static void get_input()
        {
            Console.Write(">");

            // saves the previous input
            save_prev_input();
            sInput = Console.ReadLine();

            preprocess_input();
        }

        public static void respond()
        {
            save_prev_response();
            set_event("BOT UNDERSTAND**");

            if (null_input())
            {
                handle_event("NULL INPUT**");
            }
            else if (null_input_repetition())
            {
                handle_event("NULL INPUT REPETITION**");
            }
            else if (user_repeat())
            {
                handle_user_repetition();
            }
            else
            {
                find_match();
            }

            if (user_want_to_quit())
            {
                bQuitProgram = true;
            }

            if (!bot_understand())
            {
                handle_event("BOT DONT UNDERSTAND**");
            }

            if (respList.Count > 0)
            {
                select_response();

                if (bot_repeat())
                {
                    handle_repetition();
                }

                print_response();
            }
        }

        public static bool quit()
        {
            return bQuitProgram;
        }

        public static void find_match()
        {
            respList.Clear();
            for (int i = 0; i < KnowledgeBase.GetUpperBound(0); ++i)
            {
                // there has been some improvements made in
                // here in order to make the matching process
                // a little bit more flexible
                if (sInput.IndexOf(KnowledgeBase[i, 0]) != -1)
                {
                    int respSize = KnowledgeBase[i].Length - maxInput;
                    for (int j = maxInput; j <= respSize; ++j)
                    {
                        respList.Add(KnowledgeBase[i, j]);
                    }
                    break;
                }
            }
        }

        public static void handle_repetition()
        {
            if (respList.Count > 0)
            {
                respList.RemoveAt(0);
            }
            if (no_response())
            {
                save_input();
                set_input(sEvent);

                find_match();
                restore_input();
            }
            select_response();
        }

        public static void handle_user_repetition()
        {
            if (same_input())
            {
                handle_event("REPETITION T1**");
            }
            else if (similar_input())
            {
                handle_event("REPETITION T2**");
            }
        }

        public static void handle_event(string str)
        {
            save_prev_event();
            set_event(str);

            save_input();
            set_input(str);

            if (!same_event())
            {
                find_match();
            }

            restore_input();
        }

        public static void select_response()
        {
            respList.s
            sResponse = respList[0];
        }

        public static void save_prev_input()
        {
            sPrevInput = sInput;
        }

        public static void save_prev_response()
        {
            sPrevResponse = sResponse;
        }

        public static void save_prev_event()
        {
            sPrevEvent = sEvent;
        }

        public static void set_event(string str)
        {
            sEvent = str;
        }

        public static void save_input()
        {
            sInputBackup = sInput;
        }

        public static void set_input(string str)
        {
            sInput = str;
        }

        public static void restore_input()
        {
            sInput = sInputBackup;
        }

        public static void print_response()
        {
            if (sResponse.Length > 0)
            {
                Console.WriteLine(sResponse);
            }
        }

        public static void preprocess_input()
        {
            cleanString(ref sInput);
            sInput = sInput.ToUpperInvariant();
        }

        public static bool bot_repeat()
        {
            return (sPrevResponse.Length > 0 &&
                sResponse == sPrevResponse);
        }

        public static bool user_repeat()
        {
            return (sPrevInput.Length > 0 &&
                ((sInput == sPrevInput) ||
                (sInput.IndexOf(sPrevInput) != -1) ||
                (sPrevInput.IndexOf(sInput) != -1)));
        }

        public static bool bot_understand()
        {
            return respList.Count > 0;
        }

        public static bool null_input()
        {
            return (sInput.Length == 0 && sPrevInput.Length != 0);
        }

        public static bool null_input_repetition()
        {
            return (sInput.Length == 0 && sPrevInput.Length == 0);
        }

        public static bool user_want_to_quit()
        {
            return sInput.IndexOf("BYE") != -1;
        }

        public static bool same_event()
        {
            return (sEvent.Length > 0 && sEvent == sPrevEvent);
        }

        public static bool no_response()
        {
            return respList.Count == 0;
        }

        public static bool same_input()
        {
            return (sInput.Length > 0 && sInput == sPrevInput);
        }

        public static bool similar_input()
        {
            return (sInput.Length > 0 &&
                (sInput.IndexOf(sPrevInput) != -1 ||
                sPrevInput.IndexOf(sInput) != -1));
        }

        static bool isPunc(char ch)
        {
            return delim.IndexOf(ch) != -1;
        }

        // removes punctuation and redundant
        // spaces from the user's input
        static void cleanString(ref string str)
        {
            string temp = "";
            char prevChar = '#';
            for (int i = 0; i < str.Length; ++i)
            {
                if ((str[i] == ' ' && prevChar == ' ') || !isPunc(str[i]))
                {
                    temp = string.Concat(temp, str[i]);
                    prevChar = str[i];
                }
                else if (prevChar != ' ' && isPunc(str[i]))
                {
                    temp = string.Concat(temp, ' ');
                    prevChar = ' ';
                }

            }
            str = temp;
        }

        /**
         * @param args
         */
        public static void main()
        {
            // TODO Auto-generated method stub
            Console.WriteLine("Chatterbot v5.0 Copyright (C) 2005 - 2009 Gonzales Cenelia\n");

            while (!quit())
            {
                get_input();
                respond();
            }
        }

    }
}
