/*
 * Generate a password, yo
 * DankerooDuck 2023
 * Darin Roberts
 */

using System.Data;
using System.Text;

namespace PasswordGenerator
{
    class Program
    {
        static void Main()
        {
            printInstructions();
            continuePrompt();

            bool cont = true;
            while(cont == true)
            {
                askSpecifications();
                cont = loopPrompt();
            }
            
        }

        static void printInstructions()
        {
            Console.WriteLine("\tThis program will generate a random complex password to your specification.");
        }

        static bool loopPrompt()
        {
            Console.WriteLine("\nPress any key to continue or input 0 to quit...\n");
            string inValue = Console.ReadLine();
            Console.Clear();
            if(inValue.Equals("0"))
            {
                return false;
            }
            else
            {
                return true;
            }
            
        }

        static void continuePrompt()
        {
            
            Console.WriteLine("\nPress any key to continue...\n");
            Console.ReadKey();
            Console.Clear();
        }

        static void askSpecifications()
        {
            //variables
            string inValue;
            int length = -1; //default -1
            bool uppercaseAZ = false; //default false
            bool lowercaseAZ = false; //default false
            bool numbers = false; //default false
            bool specChars = false; //default false

            //title
            Console.WriteLine("\tGenerator\n");

            //get length
            Console.Write("Length: ");
            inValue = Console.ReadLine();
            length = int.Parse(inValue);

            //A-Z
            Console.Write("A-Z? (Y/N): ");
            inValue = Console.ReadLine();
            uppercaseAZ = parseYN(inValue);

            //a-z
            Console.Write("a-z? (Y/N): ");
            inValue = Console.ReadLine();
            lowercaseAZ = parseYN(inValue);

            //0-9
            Console.Write("0-9? (Y/N): ");
            inValue = Console.ReadLine();
            numbers = parseYN(inValue);

            //!@#$%^&*
            Console.Write("!@#$%^&* (Y/N): ");
            inValue = Console.ReadLine();
            specChars = parseYN(inValue);

            //gen
            generate(length, uppercaseAZ, lowercaseAZ, numbers, specChars);


        }

        static void generate(int length, bool uppercaseAZ, bool lowercaseAZ, bool numbers, bool specChars)
        {
            Generator pw = new Generator(length, uppercaseAZ, lowercaseAZ, numbers, specChars);
        }

        static bool parseYN(string inValue)
        {
            //input string inValue should be a Y or N
            //if not Y or N, ask again
            //if Y return true
            //if N return false
            if(inValue.ToUpper().Equals("Y"))
            {
                return true;
            }
            else if (inValue.ToUpper().Equals("N"))
            {
                return false;
            }
            else
            {
                return false;
            }
        }
    }
}