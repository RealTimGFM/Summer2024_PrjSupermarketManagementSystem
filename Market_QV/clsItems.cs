using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market_QV
{
    internal class clsItems
    {
        private string vId;
        private string vName;
        private int vQuantity;
        private decimal vPrice;
        private Int32 vBuy;
        private Int32 vSell;
        internal clsItems(string id, string name, int quantity, decimal price, Int32 buy, Int32 sell)
        {
            Id = id;
            Name = name;
            Quantity = quantity;
            Price = price;
            Buy = buy;
            Sell = sell;
        }
        public Int32 Buy
        {
            get { return vBuy; }
            set { vBuy = value; }
        }
        public Int32 Sell
        {
            get { return vSell; }
            set { vSell = value; }
        }
        public string Id
        {
            get { return vId; }
            set { vId = value; }
        }
        public string Name
        {
            get { return vName; }
            set { vName = value; }
        }
        public int Quantity
        {
            get { return vQuantity; }
            set { vQuantity = value; }
        }
        public decimal Price
        {
            get { return vPrice; }
            set { vPrice = value; }
        }
    }
}
