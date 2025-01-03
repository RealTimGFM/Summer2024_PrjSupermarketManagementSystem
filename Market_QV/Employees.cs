using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market_QV
{
    internal class Employees
    {
        private const decimal SAL_PER_MIN = 2600M;
        private DateTime lastPay;
        public decimal salaryTotal { get; private set; }
        internal Employees()
        {
            lastPay = DateTime.Now;
        }
        internal void payEmp()
        {
            var workedTime = (DateTime.Now - lastPay).TotalMinutes;
            decimal amountToPay;

            amountToPay = SAL_PER_MIN * Convert.ToDecimal(workedTime);
            //salaryTotal = Math.Round(salaryTotal + amountToPay,2);
            salaryTotal = Check.roundMoney(salaryTotal + amountToPay, 2);
            lastPay = DateTime.Now;
            amountToPay = Check.roundMoney(amountToPay, 2);
            workedTime = Math.Round(workedTime, 2);
            Console.WriteLine("Employees worked for " + workedTime + " minutes and recieved: $" + amountToPay);
            Console.WriteLine("Click anywhere to continue...");
            Console.ReadKey();
        }
    }
}
