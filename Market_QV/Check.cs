using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market_QV
{
    internal class Check
    {
        public static Int32 validInt32(string question)
        {
            Int32 resultInt;
            bool isIntValid;
            Console.Write(question);
            string input = Console.ReadLine();
            isIntValid = Int32.TryParse(input, out resultInt);
            if (isIntValid == false)
            {
                Console.WriteLine("Invalid input. Please enter a valid number.\nClick anywhere to continue.");
                Console.ReadKey();
            }
            else if (resultInt < 0)
            {
                Console.WriteLine("Invalid input. Number must be bigger or equal to 0.\nClick anywhere to continue.");
                Console.ReadKey();
                return 0;
            }
            return resultInt;
        }
        public static decimal roundMoney(decimal value, Int16 dec)
        {
            return Math.Round(value, dec);
        }
    }
}
