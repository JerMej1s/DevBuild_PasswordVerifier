using System;

namespace PasswordVerifier
{
    public class PasswordVerifier
    {
        public static bool Verify(string userInputPassword)
        {
            if (!ContainsNullOrWhiteSpace(userInputPassword) && IsMinLength(userInputPassword) && IsMinUppercase(userInputPassword) && IsMinLowercase(userInputPassword) && IsMinDigits(userInputPassword))
            {
                Console.WriteLine("\nYour password has been accepted.");
                return true;
            }
            else
            {
                Console.WriteLine("\nYour password is invalid because:");
                if (ContainsNullOrWhiteSpace(userInputPassword)) Console.WriteLine("\t- Your password may not contain white space.");
                if (!IsMinLength(userInputPassword)) Console.WriteLine("\t- Your password must be at least nine characters long.");
                if (!IsMinUppercase(userInputPassword)) Console.WriteLine("\t- Your password must contain at least one uppercase letter.");
                if (!IsMinLowercase(userInputPassword)) Console.WriteLine("\t- Your password must contain at least one lowercase letter.");
                if (!IsMinDigits(userInputPassword)) Console.WriteLine("\t- Your password must contain at least one digit.");
                Console.WriteLine("Please try again.");
                return false;
            }
        }
        public static bool ContainsNullOrWhiteSpace(string userInputPassword)
        {
            if (String.IsNullOrWhiteSpace(userInputPassword)) return true;
            else
            {
                for (int i = 0; i < userInputPassword.Length; i++)
                {
                    if (char.IsWhiteSpace(userInputPassword, i)) return true;
                }
            }
            return false;
        }
        public static bool IsMinLength(string userInputPassword)
        {
            int minLength = 9;
            if (userInputPassword.Length >= minLength) return true;
            return false;
        }
        public static bool IsMinUppercase(string userInputPassword)
        {
            int minUppercase = 1, countOfUppercase = 0;
            for (int i = 0; i < userInputPassword.Length; i++)
            {
                if (char.IsUpper(userInputPassword, i))
                {
                    countOfUppercase++;
                    if (countOfUppercase == minUppercase) return true;
                }
            }
            return false;
        }
        public static bool IsMinLowercase(string userInputPassword)
        {
            int minLowercase = 1, countOfLowercase = 0;
            for (int i = 0; i < userInputPassword.Length; i++)
            {
                if (char.IsLower(userInputPassword, i))
                {
                    countOfLowercase++;
                    if (countOfLowercase == minLowercase) return true;
                }
            }
            return false;
        }
        public static bool IsMinDigits(string userInputPassword)
        {
            int minDigits = 1, countOfDigits = 0;
            for (int i = 0; i < userInputPassword.Length; i++)
            {
                if (char.IsDigit(userInputPassword, i))
                {
                    countOfDigits++;
                    if (countOfDigits == minDigits) return true;
                }
            }
            return false;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Password Verifier!");
            bool tryAgain = true;
            do
            {
                Console.WriteLine("\nYour password must contain the following:" +
                    "\n\t- No white space characters" +
                    "\n\t- At least 9 characters" +
                    "\n\t- At least one uppercase letter" +
                    "\n\t- At least one lowercase letter" +
                    "\n\t- At least one digit");
                Console.Write("\nPlease enter your password: ");
                if (PasswordVerifier.Verify(Console.ReadLine())) tryAgain = false;
            }
            while (tryAgain);
        }
    }
}