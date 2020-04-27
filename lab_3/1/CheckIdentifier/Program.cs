using System;

namespace CheckIdentifier
{
    public class Program
    {
        public static bool IsLetter(char symbol)
        {
            if ((symbol >= 'A' && symbol <= 'Z') || (symbol >= 'a' && symbol <= 'z'))
            {
                return true;
            }

            else
            {
                return false;
            }
        }

        public static bool IsNumber(char symbol)
        {
            if ('0' <= symbol && symbol <= '9')
            {
                return true;
            }

            else
            {
                return false;
            }
        }
        public static string GetIdentifier(string[] args)
        {
            if (args.Length != 1)
            {
                Console.WriteLine("Incorrect number of arguments");
            }
            return args[0];
        }
        public static bool CheckIdentifierForErrors(string identifier)
        {
            if (identifier == "")
            {
                Console.WriteLine("Identifier must not be an empty");
                return false;
            }

            if (IsNumber(identifier[0]))
            {
                Console.WriteLine("Identifier cannot start with a digit");
                return false;
            }
            if (!IsLetter(identifier[0]))
            {
                Console.WriteLine("Identifier can start only with a letter");
                return false;
            }
            else
            {
                for (int i = 1; i < identifier.Length; i++)
                {
                    if (!IsLetter(identifier[i]) && !IsNumber(identifier[i]))
                    {
                        Console.WriteLine("Identifier must contain only letters or numbers");
                        return false;
                    }
                }
                return true;
            }

        }
        public static void Main(string[] args)
        {
            string identifier = GetIdentifier(args);
            if (CheckIdentifierForErrors(identifier))
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No");
            }

        }
    }
}