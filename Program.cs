//Program: Mastermind like 
//Used Hit(s) vs Misses(s) not ---- or ++++ 
//Commented throughout the code. 
using System;
using System.Linq;

namespace DemoApplication
{
    class Program
    {
        static void Main(string[] args)
        {

            //Let the user know the rules of the game. 
            //Valid numbers between 1 and 6 

            Console.WriteLine("Welcome to my mastermind guessing game");
            Console.WriteLine("\nThe computer will generate a random 4 digit number:");
            Console.WriteLine("\nYou have up to 10 tries to guess my secret code.");

            Console.WriteLine("After each guess, I will give you a the number of hits and misses response:");
            Console.WriteLine("\nPlease enter your first guess now.");

             //Max number of user guesses
            const int iMaxGuesses = 10;
            
            //Max size of generated random number 
            const int iListSize = 4;

            //Instantiate Random function
            Random myRandom = new Random();

            //User number of guesses
            int guesses = 0;

            // Value where we will rebuild the number entered by the user. 
            string result = string.Empty;

            // Placeholder for user's actual guess
            string strGuess;

            // Converted guess
            int guess;

            // Instant random number generator
            Random r = new Random();
            int num1 = r.Next(1000, 9999);

             // Prompt user
            Console.WriteLine("Guess the {0} Digit code, Under {1} tries!", iListSize, iMaxGuesses);

            // Open the game loop
            do
            {
                // Check if we have exceeded the max amount of times we get to guess
                if (guesses > iMaxGuesses)
                    Console.WriteLine("You went over the number of tries! Better luck next time");
                {
                    // Prompt user
                    Console.WriteLine("Guess a four digit number between 1000 and 9999");

                    // Get User input
                    strGuess = Console.ReadLine();

                    // Check if input is in fact an integer, if so - put the value in our variable 'guess'
                    if (int.TryParse(strGuess, out guess))
                    {
                       // We have a correct guess, add one to number of guesses
                        guesses++;

                        // Checks if the number is the next in our list
                        //guess=Users guess 
                        
                        //for testing purposes
                        // Console.WriteLine("UsersGuess:" + guess);
                        //Console.WriteLine("num1Random:" + num1);

                        string strNum1 = Convert.ToString(num1);       //RandomNumber
                        string strUserGuess = Convert.ToString(guess); //UserGuess

                        string sCompare = strUserGuess;
                        //char a = sCompare[0];
                        //char b = sCompare[1];
                        //char c = sCompare[2];
                        //char d = sCompare[3];

                     
                      //Determine hits and misses; 
                        int hit = 0;
                        int miss = 0;
                        int hits = 0;

                        for (int i = 0; i < sCompare.Length; i++)
                        {
                          
                            //Errors if more than 4 digits......
                            if (strNum1[i] == strUserGuess[i])
                            {
                                hit = hit + 1;
                                hits = hit;
                             }
                            else
                            {
                                miss = miss + 1;
                             }
                        }
                        Console.WriteLine("Results: {0} Hit(s), {1} Miss(es)", hit, miss);

                        //Loop through characters in guess 
                        if (strUserGuess == strNum1)
                        {
                            Console.WriteLine("Congratulations, {0} was a match!", strUserGuess);
                            break;
                        }
                        else if (strNum1.Contains(strUserGuess))
                        {
                            Console.WriteLine("Right number, wrong spot!");
                       }else
                       {
                            Console.WriteLine("Incorrect, please try again!");
                        }
                    }
                    else // Inform user we will only accept numbered input
                        Console.WriteLine("That was not a number.  Please try again!");
                }


            } while (guesses <= iMaxGuesses);

            if (guesses < iMaxGuesses)
                Console.WriteLine("Correct! It took {0} guesses to come up with the pattern {1}", guesses, result);
            else
                Console.WriteLine("You took to many tries! Better luck next time! Total Guesses: {0}", guesses);

            Console.ReadLine();
        }
    }
}


