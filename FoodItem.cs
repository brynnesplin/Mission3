using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mission3
{
    internal class FoodItem
    {
        private string name;
        private string category;
        private int quantity;
        private DateTime expDate;

        // Constructor to assign name, category, quantity, and expiration date
        public FoodItem(string name, string category, int quantity, DateTime expDate)
        {
            this.name = name;
            this.category = category;
            this.quantity = quantity;
            this.expDate = expDate;
        }
        // Method to return the name of a food item
        public string GetName()
        {
            return name;
        }
        // Method to return a string with the information about a food item
        public string Inventory()
        {
            string inv = $"Item: {this.name}\nCategory: {this.category}\nQuantity: {this.quantity}\nExpiration Date: {this.expDate}";
            return inv;
            
        }
        

    }
}
