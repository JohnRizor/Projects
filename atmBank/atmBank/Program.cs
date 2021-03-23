using System;
using System.Linq;

namespace atmBank
{
    class Program
    {
        static void Main(string[] args)
        {
            double startingBalance = 5000;
            
            string[] openingScreenMessages = AtmMessages();

            openingScreenMessages.ToList().ForEach(message => MessageBuilder(message));

            int choice = int.Parse(Console.ReadLine());
            
            {
                
                switch (choice)
                {
                    case 1:
                        MessageBuilder(startingBalance.ToString());
                        break;
                
                    case 2:
                        ToggleAddition(startingBalance);
                        break;
                    case 3:
                        IsWithdrawalGreaterThanStartingBalance(startingBalance);
                        break;
                    case 4:
                        Console.WriteLine("Thank you for visiting the bank of Interstellar, Goodbye.");
                        break;
                }
            }
        }

        public static void IsWithdrawalGreaterThanStartingBalance(double startingBalance)
        {
            Console.WriteLine("How much do you want to withdraw:  ");
            double withdraw = double.Parse(Console.ReadLine());
            double withdrawal = Math.Round(startingBalance - withdraw, 2);
            if (withdrawal < 0)
            {
                MessageBuilder("Insufficent funds");
            }
            else
            {
                MessageBuilder($"You withdrew: ${withdraw}. \n You're new balance is: ${withdrawal}");
            }
        }

        private static void ToggleAddition(double startingBalance)
        {
            Console.WriteLine("How much do you want to add:  ");
            double addition = double.Parse(Console.ReadLine());
            Math.Round(startingBalance += addition, 2);
            Console.WriteLine($"You added: ${addition}. \n You're new balance is: ${startingBalance}");
        }

        /// <summary>
        /// This will return a console method to the user
        /// </summary>
        /// <param name="message"></param>
        public static void MessageBuilder(string message)
        {
            Console.WriteLine(message);
        }

        public static string[] AtmMessages()
        {
            
            return new string[] 
            {
                "Welcome to the bank of Interstellar",
                "This ATM allows your to see your initial balance, add, and withdraw money.",
                "Choose an option for yout bank account",
                "1.     Choose to view your total balance",
                "2.     Choose to add to money to your account",
                "3.     Choose to withdraw money from you account",
                "4.     Choose to exit"
            };
        }

    }
}
