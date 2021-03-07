//Group 3: Stephen, Kevin, Chrissie
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
    class Program
    {
        static void Main(string[] args)
        {
            int winStreak = 0;
            bool keepPlaying = true;
            string[] words = {"hello","water","sheep","sleep","zombie","syntax","high","tall","short","happy","hangman","town","city","computer","oxygen",
            "programming","keyboard","mouse"};

            Random rand = new Random();
            int lives = 0;
            char input;

            while (keepPlaying)
            {
                Console.WriteLine("Please select a difficulty: easy, hard");
                string dif = Console.ReadLine();

                switch (dif)
                {
                    case "easy":
                        lives = 11;
                        break;
                    case "hard":
                        lives = 5;
                        break;
                    default:
                        lives = 11;
                        break;
                }

                if(Hangman(words[rand.Next(words.Length)], lives))
                {
                    winStreak++;
                }
                else
                {
                    winStreak = 0;
                }
                Console.WriteLine("You have won {0} times in a row", winStreak);
                Console.WriteLine("Would you like to play again (y/n)?");

                try
                {
                    input = Convert.ToChar(Console.ReadLine());
                }
                catch
                {
                    continue;
                }

                if (input != 'y')
                {
                    keepPlaying = false;
                }
                
            }
        }

        public static bool Hangman(string word, int lives)
        {
            StringBuilder visibleWord = new StringBuilder();
            char input;
            bool gameOver = false;
            bool correct;

            // Generate initial representation
            for(int i = 0; i < word.Length; i++)
            {
                visibleWord.Append("_");
            }

            //Play the game
            while (!gameOver)
            {
                Console.WriteLine("");
                //Console.WriteLine("{0}",visibleWord);
                foreach(char c in visibleWord.ToString())
                {
                    Console.Write("{0} ", c);
                }

                Console.WriteLine("");
                Console.WriteLine("You have {0} lives remaining", lives);
                Console.Write("Please enter a letter: ");
                try
                {
                    input = Convert.ToChar(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Invalid input detected, please enter a single character");
                    continue;
                }

                correct = false;

                for (int i = word.IndexOf(input); i > -1; i = word.IndexOf(input, i+1))
                 {
                    visibleWord[i] = input;
                    correct = true;
                 }

                if (!correct)
                {
                    lives -= 1;
                }

                if (visibleWord.ToString().Equals(word) || lives == 0)
                {
                    gameOver = true;
                }
            }
           
            Console.WriteLine("");
            Console.WriteLine("The word was {0}", word);
            if (lives > 0)
            {
                Console.WriteLine("You Win!");
                return true;
            }
            else
            {
                Console.WriteLine("You Lose!");
                return false;
            }
        }
    }
}
