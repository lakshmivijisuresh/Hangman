// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
using System;
using System.Collections.Generic;
using static System.Random;
using System.Text;

namespace HangmanGame
{
    internal class Program
    {
        private static void printHangman(int wrong)
        {
            if (wrong == 0)
            {
                Console.WriteLine("\n+---+");
                Console.WriteLine("   |");
                Console.WriteLine("   |");
                Console.WriteLine("   |");
                Console.WriteLine("  ===");

            }
            else if (wrong == 1)
            {
                Console.WriteLine("\n+---+");
                Console.WriteLine("   |");
                Console.WriteLine("   |");
                Console.WriteLine("   |");
                Console.WriteLine("  ===");


            }
            else if (wrong == 2)
            {
                Console.WriteLine("\n+---+");
                Console.WriteLine("   |");
                Console.WriteLine("   |");
                Console.WriteLine("   |");
                Console.WriteLine("  ===");


            }
            else if (wrong == 3)
            {
                Console.WriteLine("\n+---+");
                Console.WriteLine("   |");
                Console.WriteLine("   |");
                Console.WriteLine("   |");
                Console.WriteLine("  ===");


            }
            else if (wrong == 4)
            {
                Console.WriteLine("\n+---+");
                Console.WriteLine(" 0  |");
                Console.WriteLine(" /|\\  |");
                Console.WriteLine(" /  |");
                Console.WriteLine("  ===");


            }
            else if (wrong == 5)
            {
                Console.WriteLine("\n+---+");
                Console.WriteLine(" 0  |");
                Console.WriteLine(" /|\\  |");
                Console.WriteLine("/  |");
                Console.WriteLine("  ===");


            }
            else if (wrong == 6)
            {
                Console.WriteLine("\n+---+");
                Console.WriteLine(" 0  |");
                Console.WriteLine(" /|\\  |");
                Console.WriteLine(" / \\  |");
                Console.WriteLine("  ===");
            }
        }

        private static int printWord(List<char> guessedLetters, String randomWord)
        {
            int counter = 0;
            int rightLetters = 0;
            Console.Write("\r\n");
            foreach (char c in randomWord)
            {
                if (guessedLetters.Contains(c))
                {
                    Console.Write(c + " ");
                    rightLetters++;
                }
                else
                {
                    Console.Write(" ");
                }
                counter++;
            }
            return rightLetters;
        }
        private static void printLines(String randomWord)
        {
            Console.Write("\r");
            foreach (char c in randomWord)
            {
                Console.OutputEncoding = System.Text.Encoding.Unicode;
                Console.Write("\u0305 ");
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to hangman :");
            Console.WriteLine("_________________");

            Random random = new Random();
            List<string> wordDictionary = new List<string> { "sunflower", "house", "rose", "diamond", "pearls", 
                "lotus", "dalia", "jasmine","viji", "ravi", "aswath", "sindhu", "suresh", "harshitha", "apple",
                "orange", "grapes", "guava", "pinepapple", "banana", "strawberry", "melon", "watermelon", 
                "waterapple", "potato", "tomato", "onion", "pears", "beans", "lily", "duck", "cow", "goat",
                "buffalo", "donkey", "giraffee", "elephant", "monkey", "deer", "cheetah", "tiger", "lion" };
            int index = random.Next(wordDictionary.Count);
            String randomWord = wordDictionary[index];

            foreach (char x in randomWord)
            {
                Console.Write("_ ");
            }
            int lengthOfWordToGuess = randomWord.Length;
            int amountOfTimesWrong = 0;
            List<char>currentLetterGuessed = new List<char>();
            int currentLettersRight = 0;

            while (amountOfTimesWrong != 6 && currentLettersRight != lengthOfWordToGuess)
            {
                Console.Write("\nLetters guessed so far: ");
                foreach (char letter in currentLetterGuessed)
                {
                    Console.Write(letter + " ");
                }

                //Prompt user for input
                Console.Write("\nGuess a letter: ");
                char letterGuessed = Console.ReadLine()[0];
                //check if letter has already been guessed
                if (currentLetterGuessed.Contains(letterGuessed))
                {
                    Console.Write("\r\nYou have already guessed this letter");
                    printHangman(amountOfTimesWrong);
                    currentLettersRight = printWord(currentLetterGuessed, randomWord);
                    printLines(randomWord);
                }
                else
                {
                    //check if letter is in the word
                    bool right = false;
                    for (int i = 0; i < randomWord.Length; i++)
                    {
                        if (letterGuessed == randomWord[i])
                            if (right)
                            {
                                printHangman(amountOfTimesWrong);
                                currentLetterGuessed.Add(letterGuessed);
                                currentLettersRight = printWord(currentLetterGuessed, randomWord);
                                Console.Write("\r\n");
                                printLines(randomWord);
                            }
                            else
                            {
                                amountOfTimesWrong++;
                                currentLetterGuessed.Add(letterGuessed);
                                printHangman(amountOfTimesWrong);
                                currentLettersRight = printWord(currentLetterGuessed, randomWord);
                                Console.Write("\r\n");
                                printLines(randomWord);

                            }
                    }
                }
                Console.WriteLine("\r\nGame is over! Thank you for playing:");
            }
        }
    }
}