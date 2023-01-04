using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
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
            users[0] = new User("admin", "admin", 50000);
            users[1] = new User("user1", "password1", 350.5);
            users[2] = new User("user1", "password1", 0);

            //while loop för att appen inte ska stängas tills man skriver in "3"
            while (true)
            {
                Console.WriteLine("Welcome to the bank app, what would you like to do?");
                Console.WriteLine("1. Login");
                Console.WriteLine("2. Register");
                Console.WriteLine("3. exit");

                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    Console.Write("Enter your username: ");
                    string inputUser = Console.ReadLine();
                    Console.Write("Enter your password: ");
                    string inputPass = Console.ReadLine();
                    
                   
                }
                if (choice == "3")
                {
                    break;
                }
            }
        }

        public class User
        {
            private string _username;
            private string _password;
            private double _balance;

            //constructor för att kunna skapa nya element till arrayen senare
            public User(string username, string password, double balance)
            {
                this._username = username;
                this._password = password;
                this._balance = balance;
            }
            
            //metod som kollar double i arrayen
            public string showBalance()
            {
                return "You have: " + this._balance + "$";
            }
        }
    }
}