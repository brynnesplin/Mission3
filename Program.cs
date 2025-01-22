
using Mission3;

List<FoodItem> inventory = new();

bool cont = true;
bool valid = false;
int next = 0;
string name = "";
string quantInput = "";
int quantity = 0;
string category = "";
string expDate = "";
DateTime parsedDate;


// Until the user exits the program, let them choose an option from the system menu
while (cont) {
    Console.WriteLine("\nWelcome to the Food Bank Inventory System! Please choose an option from the menu below:\n(1) Add Food Items\n(2) Delete Food Items\n(3) Print List of Current Food Items\n(4) Exit the Program");

    // Take the user input and convert it to an integer, if it cannot be converted to integer throw an error
    if (int.TryParse(Console.ReadLine(), out next)){
        // User selects to add food items 
        if (next == 1)
        {
            // Take and store the user inputs for name, category, quantity, and expiration date
            Console.WriteLine("\nYou have selected to add a food item!\nEnter the food item name (e.g. Canned Beans):");
            name = Console.ReadLine();
            Console.WriteLine("Enter the food item Category (e.g. Canned Goods, Dairy, Produce)");
            category = Console.ReadLine();
            Console.WriteLine("Enter the food item quantity:");

            // Input validation for quantity
            // Only allow non-negative integers

            do
            {
                quantInput = Console.ReadLine();
                if ((int.TryParse(quantInput, out quantity) && quantity >= 0))
                {
                    valid = true;
                }
                else
                {
                    Console.WriteLine("Invalid input. Enter a non-negative integer");
                    valid = false;
                }
            }
            while (!valid);

            Console.WriteLine("Enter the expiration date in the form YYYY-MM-DD:");

            // Input validation for expiration date
            // Only allow date in form YYYY-MM-DD

            do
            {
                expDate = Console.ReadLine();
                if (DateTime.TryParse(expDate, out parsedDate))
                {
                    valid = true;
                }
                else
                {
                    Console.WriteLine("Invalid input. Enter the expriation date in the form YYYY-MM-DD");
                    valid = false;
                }
            }
            while (!valid);

            // Create a new FoodItem object named item using the properties gathered above
            FoodItem item = new FoodItem(name, category, quantity, parsedDate);

            // Add the FoodItem object to the inventory list and give confirmation to the user
            inventory.Add(item);
            Console.WriteLine($"{item.GetName()} successfully added to inventory!");

        }
        // User selects to delete a food item
        else if (next == 2)
        {
            // Get the name of the item the user wants to delete
            Console.WriteLine("\nYou have selected to delete a food item!\nWhich item do you want to delete?");
            string itemName = Console.ReadLine();
            bool delete = false;

            // Loop through the inventory until the name of the item the user wants to delete matches the name of the item in the inventory
            // Delete that item and give confirmation to the user
            // Update the boolean to delete to indicate that an item was deleted
            for (int i = 0; i < inventory.Count; i++)
            {
                if (itemName == inventory[i].GetName())
                {
                    inventory.RemoveAt(i);
                    Console.WriteLine($"\nSuccessfully removed {itemName} from Inventory");
                    delete = true;
                }
                // If the item was not found and deleted tell the user it does not exist in the inventory
                if (delete == false)
                {
                    Console.WriteLine($"\n {itemName} does not exist in Inventory.");
                }
            }
        }
        // User selects to print the inventory
        else if (next == 3)
        {
            Console.WriteLine("Inventory:\n");
            // Loop through FoodItems in inventory and access the string that returns from the Inventory() method
            foreach (FoodItem item in inventory)
                Console.WriteLine($"{item.Inventory()}\n");
        }
        // User selects to exit
        else if (next == 4)
        {
            cont = false;
        }
        // User does not enter a valid input
        else
        {
            Console.WriteLine("Please enter a number 1 through 4");
        }
    }
    else
    {
        Console.WriteLine("Invalid input");
    }
}

Console.WriteLine("Thanks for using the inventory tracker!");

