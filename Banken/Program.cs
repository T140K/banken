using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Transactions;

//måste använda array för store user info
//helst constructor med methods för de bilr enklare
//double borde fungera för hålla balance?
//måste ha flera bools o loops
//minst tre funktioner/metoder
//
// LÖPANDE SPARING TILL GIT UNDER ARBETSPROCESS
//
//Kommentera det som inte är självklart, alla metoder

//läs VG kriterier när jage klar!!!

namespace Banken
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //while loop för hela menyn, array som e med constructor

            //while {
            //det ska va 1.Login 2.Register 3.Exit
            //string choice = Console.ReadLine();
            //if (choice == 1) Login
            //else if (choice == 2) Register
            //else if (choice == 3) {
            //break; }

            // skapar en array som är baserad på constructorn jag har
            User[] users = new User[3];
            users[0] = new User("admin", "12", 50000);
            users[1] = new User("user1", "123", 350.5);
            users[2] = new User("user2", "1234", 0);

            Console.WriteLine(users[0].showBalance());
            Console.WriteLine(users[0].getUsername());

            //while loop för att appen inte ska stängas tills man skriver in "3"
            while (true)
            {
                Console.WriteLine("Welcome to the bank app, what would you like to do?");
                Console.WriteLine("1. Login");
                Console.WriteLine("2. Register");
                Console.WriteLine("3. exit");

                string? choice = Console.ReadLine();

                if (choice == "1")
                {
                    Console.Write("Enter your username: ");
                    string inputUser = Console.ReadLine();
                    Console.Write("Enter your password: ");
                    string inputPass = Console.ReadLine();

                    /*bool login = false; //dethär var rarted, borde göra det som en function som jag kommenterade om nere
                    User loggedInUser;
                    foreach (User user in users)
                    {
                        if (user.Username == inputUser && user.Password == inputPass)
                        {
                            
                            login = true;
                            break;
                        }
                    }
                    if (login)
                    {
                        Console.WriteLine("Welcome " + ", what would you like to do?");

                        Console.WriteLine("1. Check your balance");
                        Console.WriteLine("2. Withdraw money");
                        Console.WriteLine("3. Deposit money to other accounts");
                        Console.WriteLine("4. Logout"); 

                        string subOption = Console.ReadLine();

                        if (subOption == "1")
                        {
                            Console.WriteLine("You have " +  "$ in your account");
                        }
                        if (subOption == "2")
                        {

                        }
                        if (subOption == "3")
                        {

                        }
                        if (subOption == "4")
                        {

                        }
                    }
                    else
                    {
                        Console.WriteLine("The username or password you gave is incorrect, try again.");
                    }*/
                }
                if (choice == "3")
                {
                    break;
                }
            }
        }

        public class User
        {
            /*public string Username { get; set; }
            public string Password { get; set; }
            public double Balance { get; set; }*/

            public string Username;
            public string Password;
            public double Balance;

            /*private string _username;
            private string _password;
            private double _balance;*/

            //constructor för att kunna skapa nya element till arrayen senare
            public User(string username, string password, double balance)
            {
                Username = username;
                Password = password;
                Balance = balance;

                /*this._username = username;
                this._password = password;
                this._balance = balance;*/
            }
            
            //metod som kollar double i arrayen
            public string showBalance()
            {
                return "You have: " + Balance + "$";
            }

            public string getUsername()
            {
                return Username;
            }
        }
        //varje user ska ha flera kontos, minst 2
        //nested array
        // transfers ska vara från t.ex user1 konto2 => user3 konto2 
        //ha login som en function som har submenu och den ska ta in user som ska ha en objekt loggedin user
    }
}