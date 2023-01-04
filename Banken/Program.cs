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

            //while loop för att appen inte ska stängas tills man skriver in "3"
            while (true)
            {
                Console.WriteLine("Welcome, what would you like to do?");
                Console.WriteLine("1. Login");
                Console.WriteLine("2. Register");
                Console.WriteLine("3. exit");

                string? choice = Console.ReadLine();

                if (choice == "1")
                {
                    Console.Clear();
                    Console.Write("Enter your username: ");
                    string? inputUser = Console.ReadLine();
                    Console.Write("Enter your password: ");
                    string? inputPass = Console.ReadLine();

                    
                    credentialsValidation(users, inputUser, inputPass);
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
                            break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("The username or password you gave is incorrect, try again.");
                    }*/
                }
                if (choice == "3")
                {
                    Console.Clear();
                    break;
                }
            }
            //denna funktion kollar om de info man gav ovan är korrekt med inputuser och inputpass som checkas 
            //tillasmmans med det som finns i array"databasen" då om det finns sådan kombination kommer man
            //logga in med den och denna kombinationen kommer spara som user och skickas vidare till userloggedin functionen
            void credentialsValidation(User[] allUsers, string inputUser, string inputPass)
            {
                foreach (User user in allUsers)
                {
                    if (user.Username == inputUser && user.Password == inputPass)
                    {
                        userLoggedIn(user);
                        break;
                    }
                }
            }
            //i denna metoden får man validerad kombination av en login som skickas in i denna parameter och blir till loggedinuser 
            //man får även access till andra arrayer så att man kan transfer pengar till andra konto, allt är i en while
            //loop så att man inte stänger ner applikationen när man loggar ut för att byta användare
            void userLoggedIn (User loggedInUser) 
            {
                while (true)
                {
                    Console.Clear();
                    Console.WriteLine($"Hello {loggedInUser.Username}! What would you like to do?\n");
                    Console.WriteLine("1. Check your balance");
                    Console.WriteLine("2. Deposit money");
                    Console.WriteLine("3. Withdraw money");
                    Console.WriteLine("4. Transfer money");
                    Console.WriteLine("5. Logout");

                    string? option = Console.ReadLine();
                    if (option == "1")
                    {
                        Console.Clear();
                        Console.WriteLine("Your balance is " + loggedInUser.Balance);
                        Console.ReadLine();
                    }
                    if (option == "2")
                    {
                        //+= gör att loggedinuser.Balance först adderas och sedan uppdateras till nya värdet
                        Console.Clear();
                        Console.Write("You have " + loggedInUser.Balance + "$, how much would you like to deposit: ");
                        double ammount = double.Parse(Console.ReadLine());
                        loggedInUser.Balance += ammount;
                        Console.Clear();
                        Console.WriteLine("You now have " + loggedInUser.Balance + "$");
                        Console.ReadLine();
                    }
                    if (option == "3")
                    {
                        //+= gör att loggedinuser.Balance först subtraheras och sedan uppdateras till nya värdet
                        Console.Clear();
                        Console.Write("You have " + loggedInUser.Balance + "$, how much would you like to withdraw: ");
                        double ammount = double.Parse(Console.ReadLine());
                        loggedInUser.Balance -= ammount;
                        Console.Clear();
                        Console.WriteLine("You now have " + loggedInUser.Balance + "$");
                        Console.ReadLine();
                    }
                    if (option == "4")
                    {
                        Console.Clear();
                        Console.WriteLine("What account do you want to transfer money to?");
                        string account = Console.ReadLine();
                        Console.Clear();
                        Console.WriteLine("How much money would you like to transfer?");
                        double ammount = double.Parse(Console.ReadLine());
                        loggedInUser.Balance -= ammount;
                        //an kollar Users array och skapar newUser variabel som kommer sättas till den user man hittar i 
                        //account == newUser.Username, man söker genom hela listen och gemför den med inputen
                        foreach (User newUser in users)
                        {
                            if (account == newUser.Username) 
                            {
                                if (ammount > loggedInUser.Balance)
                                {
                                    //om man inte har pengar i kontot kommer denna meddelande visas
                                    Console.WriteLine("You dont have enought money");
                                    Console.ReadLine();
                                }
                                else
                                {
                                    //annars är allt bra och det kommer gå igenom så att newUser balance adderas och 
                                    //uppdateras med summan gav 
                                    newUser.Balance += ammount;
                                }
                            }
                            else
                            {
                                //om man inte lyvkas kommer man gå tillbaka
                                Console.WriteLine("Something went wrong, try again.");
                            }
                        }

                    }
                    if (option == "5")
                    {
                        Console.Clear();
                        break;
                    }
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
            //metoderna var retardeD?
        }
        //varje user ska ha flera kontos, minst 2
        //nested array
        // transfers ska vara från t.ex user1 konto2 => user3 konto2 
        //ha login som en function som har submenu och den ska ta in user som ska ha en objekt loggedin user
    }
}