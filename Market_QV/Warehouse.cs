using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Market_QV
{
    internal class Warehouse
    {
        Employees employees = new Employees();
        static List<clsItems> items;
        public Int32 itemBuy { get; private set; }
        public Int32 itemSell { get; private set; }
        static decimal totalCost;
        static decimal totalSale;
        static decimal totalExp;
        const string FILE_PATH = "warehouse.txt";
        const decimal APPLE_PRICE = 0.30M;
        const decimal BANANA_PRICE = 0.50M;
        const decimal MILK_PRICE = 1.50M;
        const decimal EGGS_PRICE = 2.00M;
        const decimal BREAD_PRICE = 1.50M;
        const decimal CHICKEN_BREAST_PRICE = 3.50M;
        const decimal SELL_PROFIT = 2.00M;
        internal Warehouse()
        {

        }
        public void addItems() 
        {
            items = new List<clsItems>
            {
                new clsItems("1", "Apple", 0, APPLE_PRICE, 0, 0),
                new clsItems("2", "Banana", 0, BANANA_PRICE, 0, 0),
                new clsItems("3", "Milk", 0, MILK_PRICE, 0, 0),
                new clsItems("4", "Eggs", 0, EGGS_PRICE, 0, 0),
                new clsItems("5", "Bread", 0, BREAD_PRICE, 0, 0),
                new clsItems("6", "Chicken Breast", 0, CHICKEN_BREAST_PRICE, 0, 0)
            };
        }
        internal void reset()
        {
            char ans;
            Console.Write("Do you want to reset ( Y / N ) : ");

            if (!char.TryParse(Console.ReadLine(), out ans))
            {
                Console.WriteLine("Invalid input. Please enter Y or N.");
                Console.ReadKey();
            }
            else
            {
                ans = char.ToUpper(ans); 
                if (ans == 'Y')
                {
                    Console.WriteLine("Resetting inventory...");
                    Console.WriteLine("COMPLETED");

                    using (StreamWriter myfile2 = new StreamWriter(FILE_PATH))
                    {
                        foreach (clsItems item in items)
                        {
                            myfile2.WriteLine(item.Id + ',' + item.Name + ',' + 0 + ',' + item.Price + ',' + 0 + ',' + 0);
                        }
                        myfile2.Close();
                    }
                    loadInventory();
                    Console.ReadKey();
                }
                else if (ans == 'N')
                {
                    Console.WriteLine("You chose not to reset.");
                    Console.ReadKey();
                    return;
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please enter Y or N.");
                    Console.ReadKey();
                }
            }
        }
        internal void payEmp()
        {
            employees.payEmp();
        }
        internal void calculateTotalExpenses()
        {
            totalExp = Math.Abs(totalExp - totalCost - employees.salaryTotal);
            totalExp = Math.Round(totalExp, 2);
            Console.WriteLine("Total expenses: -$" + totalExp);
        }
        internal void showItemDetail()
        {
            string itemInput;
            bool found = false;
            Console.Write("\nEnter ID ( 1 - 6 ) or Name to see product's info: ");
            itemInput = Console.ReadLine().ToUpper().Trim();
            foreach (clsItems item in items)
            {
                if (itemInput == item.Id.ToUpper() || itemInput == item.Name.ToUpper())
                {
                    Console.WriteLine("\tYou bought total of " + item.Buy + " " + item.Name);
                    Console.WriteLine("\tYou sold total of " + item.Sell + " " + item.Name);
                    found = true;
                    Console.Write("Click anywhere to continue");
                    Console.ReadKey();
                }
            }
            if (!found)
            {
                Console.WriteLine("Invalid Input");
                Console.ReadKey();
                return;
            }

        }
        internal void trackInventory()
        {
            Console.WriteLine("Current time: " + DateTime.Now);
            Console.WriteLine("---");
            Console.WriteLine("Item bought: " + itemBuy);
            Console.WriteLine("Item sold: " + itemSell);
            Console.WriteLine("Total cost of items purchased: -$" + totalCost);
            Console.WriteLine("Employee salary: -$" + employees.salaryTotal);
            calculateTotalExpenses();
            Console.WriteLine("Total sales: +$" + totalSale);
            Console.WriteLine("Total profit: " + (totalSale - totalExp) + "$");
            Console.WriteLine("------");
            Console.WriteLine("Warehouse supply: ");
            foreach (clsItems item in items)
            {
                Console.WriteLine("\t" + item.Id + " __ " + item.Name + " - Qty: " + item.Quantity);
            }
            showItemDetail();
        }
        internal void buyInventory()
        {
            bool found = false;
            string choice;
            foreach (clsItems item in items)
            {
                Console.WriteLine(item.Id + "  - " + item.Price + "$" + " - " + item.Name);
            }
            Console.Write("\nEnter your choice (Item ID or Name) : ");
            choice = Console.ReadLine().ToUpper().Trim();
            foreach (clsItems item in items)
            {
                if (choice == item.Id.ToUpper() || choice == item.Name.ToUpper())
                {
                    itemBuy = Check.validInt32("Enter the quantity: ");
                    Console.WriteLine("Buy " + itemBuy + " " + item.Name);
                    item.Quantity = item.Quantity + itemBuy;
                    item.Buy = itemBuy + item.Buy;
                    totalCost = totalCost + (itemBuy * item.Price);
                    Console.WriteLine("Current stock: " + item.Quantity);
                    found = true;
                    Console.ReadKey();
                }
            }
            if (!found)
            {
                Console.WriteLine("Invalid Input");
                Console.ReadKey();
                return;
            }
        }
        internal void sellInventory()
        {
            bool found = false;
            string choice;
            Int32 tempItemSell;
            foreach (clsItems prod in items)
            {
                Console.WriteLine(prod.Id + "  - " + (prod.Price + SELL_PROFIT) + "$" + " - " + prod.Name);
            }
            Console.Write("\nEnter your choice (Item ID or Name) : ");
            choice = Console.ReadLine().ToUpper();
            foreach (clsItems item in items)
            {
                if (choice == item.Id.ToUpper() || choice == item.Name.ToUpper())
                {
                    tempItemSell = Check.validInt32("Enter the quantity: ");
                    if (tempItemSell > item.Quantity)
                    {
                        Console.WriteLine("You dont have enough of this item.");
                        Console.ReadKey();
                        return;
                    }
                    else
                    {
                        itemSell = tempItemSell;
                        Console.WriteLine("Sell " + itemSell + " " + item.Name);
                        item.Quantity = item.Quantity - itemSell;
                        item.Sell = itemSell + item.Sell;
                        totalSale = totalSale + (itemSell * (item.Price + SELL_PROFIT));
                        Console.WriteLine("Current stock: " + item.Quantity);
                        found = true;
                        Console.ReadKey();
                    }
                }
            }
            if (!found)
            {
                Console.WriteLine("Invalid Input");
                Console.ReadKey();
                return;
            }
        }
        public void saveInventory()
        {
            using (StreamWriter myfile = new StreamWriter(FILE_PATH))
            {
                foreach (clsItems item in items)
                {
                    myfile.WriteLine(item.Id + ',' + item.Name + ',' + item.Quantity + ',' + item.Price + ',' + item.Buy + ',' + item.Sell);
                }
                myfile.Close();
            }
        }
        public void loadInventory()
        {
            items = new List<clsItems>();
            List<string> lines = File.ReadAllLines(FILE_PATH).ToList();
            foreach (var line in lines)
            {
                string[] entries = line.Split(',');
                clsItems newItem = new clsItems(entries[0], entries[1], Convert.ToInt32(entries[2]), Convert.ToDecimal(entries[3]), Convert.ToInt32(entries[4]), Convert.ToInt32(entries[5]));
                items.Add(newItem);
            }
        }
    }
}