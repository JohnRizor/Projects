using System;

namespace CashRegister3
{
    class Program
    {
        static void Main(string[] args)
        {
            double purchaseAmount = combinedInput("Please enter your purchase amount:$  ");
            double payAmount = combinedInput("Please enter your payment amount:$  ");
            compareAmounts(payAmount, purchaseAmount);
            double change = Math.Round((payAmount - purchaseAmount), 2);
            compileChange(change, payAmount, purchaseAmount);
        }

        static void compileChange(double change, double payAmount, double purchaseAmount)
        {
            if (payAmount == purchaseAmount)
            {
                Console.WriteLine("you have provided the correct amount ... Change Due is = $0");

            }
            if (payAmount > purchaseAmount)
            {
                Console.WriteLine($"Your change is ${change}");
                double twenties = Math.Round(Calculator(change, 20), 2);
                double tens = Math.Round(Calculator(twenties, 10), 2);
                double fives = Math.Round(Calculator(tens, 5), 2);
                double ones = Math.Round(Calculator(fives, 1), 2);
                double dimes = Math.Round(Calculator(ones, 0.10), 2);
                double nickels = Math.Round(Calculator(dimes, 0.05), 2);
                double pennies = Math.Round(Calculator(nickels, 0.01), 2);
            }
        }

        static double compareAmounts(double amount1, double amount2)
        {
            double compareAmountoutput = 0;
            bool commit = false;
            while (commit == false)
            {
                if (amount1 < amount2)
                {
                    Console.WriteLine("Insuffienct Funds Please re-enter your purchase amount and payment amount:");
                    amount2 = combinedInput("Please enter your purchase amount:$  ");
                    amount1 = combinedInput("Please enter your payment amount:$  ");
                }
                else
                {
                    commit = true;
                }
                    
            }
            return compareAmountoutput;
        }
        static double combinedInput(string userInput)
        {
            double input = 0;
            bool commit = false;
            while (commit == false)
            {
                
                try
                {
                    Console.Write(userInput);
                    input = double.Parse(Console.ReadLine());
                    while (input <= 0)
                    {
                        input = combinedInput("Your input was less than or equal to $0.00. Please re-enter your amount: $  ");
                    }
                    if (input > 0)
                    {
                        commit = true;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("You entered an invalid input.");
                    Console.WriteLine(e.Message);
                }
            }
            return input;
        }
        static double Calculator(double changeDue, double denominator)
        {
            int amountDue = (int)(changeDue / denominator);
            if (amountDue != 0)
            {
                Console.WriteLine($" You will receive ${denominator} : {amountDue}");
            }
            changeDue = changeDue % denominator;

            return changeDue;
        }
    }
}
