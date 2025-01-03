using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market_QV
{
    internal class Program
    {
        static int choice;
        static void Main(string[] args)
        {
            Warehouse warehouse = new Warehouse();
            warehouse.addItems();
            warehouse.loadInventory();
            bool program = true;
            while (program)
            {
                Console.Clear();
                getChoice();
                Console.Clear();
                switch (choice)
                {
                    case 1:
                        displayTitle("Buy inventory");
                        warehouse.buyInventory();
                        warehouse.saveInventory();
                        break;
                    case 2:
                        displayTitle("sell inventory");
                        warehouse.sellInventory();
                        warehouse.saveInventory();
                        break;
                    case 3:
                        displayTitle("track stocks");
                        warehouse.trackInventory();
                        break;
                    case 4:
                        displayTitle("pay employees");
                        warehouse.payEmp();
                        break;
                    case 5:
                        displayTitle("Reset inventory");
                        warehouse.reset();
                        break;
                    case 6:
                        goodbye();
                        return;
                }
            }
        }
        public static void goodbye()
        {
            Console.WriteLine("\t _____           _ _            ");
            Console.WriteLine("\t|   __|___ ___ _| | |_ _ _ ___ ");
            Console.WriteLine("\t|  |  | . | . | . | . | | | -_|");
            Console.WriteLine("\t|_____|___|___|___|___|_  |___|");
            Console.WriteLine("\t                      |___|    \n");
        }
        public static void displayTitle(string title)
        {
            Console.WriteLine("\n\t" + title.ToUpper());
            Console.Write("\t");
            for (int i = 0; i < title.Length; i++)
            {
                Console.Write("_");
            }
            Console.WriteLine("\n");
        }
        public static int getChoice()
        {
            Console.WriteLine("\n\tSUPERMARKET MANAGER’S SOFTWARE");
            Console.WriteLine("\t------------------------------\n");
            Console.WriteLine("1 - Buy Inventory");
            Console.WriteLine("2 - Sell Inventory");
            Console.WriteLine("3 - Manage Inventory");
            Console.WriteLine("4 - Pay Employees");
            Console.WriteLine("5 - Reset Inventory");
            Console.WriteLine("6 - Exit");
            choice = Check.validInt32("Enter your choice (1 - 6): ");
            if (choice <1 || choice > 6)
            {
                Console.WriteLine("Enter choice from 1 to 6 only");
                Console.ReadKey();
            }
            return choice;
        }
    }
}
