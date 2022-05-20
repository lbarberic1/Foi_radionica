using ConsoleTables;
using DebuggingBeginner.Data;
using DebuggingBeginner.Helpers;
using DebuggingBeginner.Models;
using System;

namespace DebuggingBeginner // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        private static bool execute = true;
        private static Database database = new Database();
        private static List<BankAccount> bankAccounts;

        static void Main(string[] args)
        {

            bankAccounts = database.InitializeData();
            do
            {
                try
                {
                    Menu();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            } while (execute);



        }

        private static void Menu()
        {
            try
            {

                Console.WriteLine("\n1. Create a new account");
                Console.WriteLine("2. View Account(s)");
                Console.WriteLine("3. Get current balance");
                Console.WriteLine("4. Deposit");
                Console.WriteLine("5. Withdrawal");
                Console.WriteLine("6. Delete an account");
                Console.WriteLine("7. Edit username");
                Console.WriteLine("Q Exit");
                ProcessMenuSelection(Console.ReadLine());
            }
            catch (Exception ex)
            {
                throw new SomethingWentWrongException("Something went wrong", ex);
            }
        }

        public static void ProcessMenuSelection(string sel)
        {
            switch (sel)
            {
                case "1":
                    //CreateAccount();
                    break;
                case "2":
                    ListAllAccounts();
                    break;
                case "3":
                    Console.WriteLine("Enter User ID: ");
                    GetCurrentBalance(FindUser(int.Parse(Console.ReadLine())));
                    break;
                case "4":
                    Console.WriteLine("Enter User ID: ");
                    Deposit(FindUser(int.Parse(Console.ReadLine())));
                    break;
                case "5":
                    Console.WriteLine("Enter User ID: ");
                    Withdrawal(FindUser(int.Parse(Console.ReadLine())));
                    break;
                case "6":
                    Console.WriteLine("Enter User ID: ");
                    RemoveAccount(FindUser(int.Parse(Console.ReadLine())));
                    break;
                case "7":
                    EditUserName();
                    break;
                case "q":
                case "Q":
                    execute = false;
                    break;
                default:
                    Console.WriteLine("Invalid selection\n");
                    break;
            }
        }

        private static void RemoveAccount(IOperations bankAccount)
        {
            bankAccounts.Remove((BankAccount)bankAccount);
        }

        private static void Withdrawal(IOperations bankAccount)
        {
            Console.WriteLine("Enter the deposit amount");
            var depositAmount = int.Parse(Console.ReadLine());
            bankAccount.Withdraw(depositAmount);
        }

        private static void Deposit(IOperations bankAccount)
        {
            Console.WriteLine("Enter the deposit amount");
            var depositAmount = int.Parse(Console.ReadLine());
            bankAccount.Deposit(depositAmount);
        }

        private static void EditUserName()
        {
            Console.WriteLine("Enter user id: ");
            var id = int.Parse(Console.ReadLine());
            var user = FindUser(id);

            Console.WriteLine("Enter new username: ");
            var newUsername = Console.ReadLine();
            user.FirstName = newUsername;
        }

        private static void GetCurrentBalance(IOperations bankAccount)
        {
            bankAccount.GetCurrentBalance();
        }

        private static void ListAllAccounts()
        {
            try
            {
                for (int i = 0; i <= bankAccounts.Count; i++)
                {
                    Console.WriteLine(bankAccounts[i].FirstName);
                    Console.WriteLine(bankAccounts[i].LastName);
                    Console.WriteLine(bankAccounts[i]);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private static BankAccount FindUser(int id)
        {
            return bankAccounts.FirstOrDefault(x => x.id == id);
        }
    }
}