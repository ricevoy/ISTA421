using System;
using System.Collections.Generic;
using System.Security.Cryptography;
namespace Exercise09
{
    public class Util
    {
        static Dictionary<string, string> Credentials = new Dictionary<string, string>();

        public static void GetNewUser()
        {
            Console.WriteLine("Input a username: ");
            string userName = Console.ReadLine();

            Console.WriteLine("Input a password:");
            string password = Console.ReadLine();

            string hashedPassword = Hashing.ComputerSha256Hash(password);
            Credentials.Add(userName, hashedPassword);
            Console.WriteLine($"Your username is: {userName}" +
                $"\nYour password is: {password}" +
                $"\nYour hashed password is: {hashedPassword}");

            Console.WriteLine("Enter any key to continue...");
            Console.ReadKey();
        }

        internal static void AuthenticateUser()
        {
            Console.WriteLine("Enter username: ");
            string username = Console.ReadLine();
            string password = "";
            if (Credentials.ContainsKey(username))
            {
                Console.WriteLine("Your username is correct.  Please enter your password.");
                password = Console.ReadLine();
                string hashedPassword = Hashing.ComputerSha256Hash(password);

                if (Credentials.ContainsValue(hashedPassword))
                {
                    Console.WriteLine("Your password is correct!");
                }
                else
                    Console.WriteLine($"{password} does not exist.");
            }
            else
            {
                Console.WriteLine("Incorrect username.");
            }

            Console.WriteLine("Enter any key to continue...");
            Console.ReadKey();
        }

        internal static int printUI()
        {
            int userResponse = 0;
            Console.WriteLine("PASSWORD AUTHENTICATION SYSTEM" +
                "\n" +
                "\nPlease select one option:" +
                "\n" +
                "\n1. Establish an account" +
                "\n2. Authenticate a user" +
                "\n3. View Users" +
                "\n4. Exit System" +
                "\n" +
                "\nEnter selection:");
            userResponse = Convert.ToInt32(Console.ReadLine());

            return userResponse;

        }

        internal static void PrintUsers()
        {
            foreach (KeyValuePair<string, string> kvp in Credentials)
            {
                Console.WriteLine("Username: {0}", kvp.Key);
            }
            Console.WriteLine("Enter any key to continue...");
            Console.ReadKey();
        }
    }
}