using Mission3;
FoodItem fi = new FoodItem();

string action = "";

do
{
    Console.WriteLine("Enter 'Add', 'Print', 'Delete', or 'Exit'");
    action = Console.ReadLine().ToLower();

    switch (action)
    {
        case "add":
            string foodName = "";
            string foodType = "";
            int foodQuantity = 0;
            string foodExpire = "";

            Console.WriteLine("Enter the new food item name: ");
            foodName = Console.ReadLine().ToLower();

            Console.WriteLine("Enter the food's type: ");
            foodType = Console.ReadLine().ToLower();

            Console.WriteLine("Enter the new food quantity: ");
            while (!int.TryParse(Console.ReadLine(), out foodQuantity) || foodQuantity < 0)
            {
                Console.WriteLine("Please enter a non-negative number: ");
            }

            Console.WriteLine("Enter the food's expiration date: (DD/MM/YYYY)");
            foodExpire = Console.ReadLine().ToLower();

            fi.AddFood(foodName, foodType, foodQuantity, foodExpire);
            break;

        case "print":
            fi.ListFood();
            break;

        case "delete":
            string deleteFood = "";
            Console.WriteLine("Enter the food item name to be deleted: ");
            deleteFood = Console.ReadLine().ToLower();
            fi.DeleteFood(deleteFood);
            break;

        default:
            Console.WriteLine("Please enter 'Add', 'Print', 'Delete', or 'Exit'.");
            break;
    }
} while (action != "exit");

fi.Exit();