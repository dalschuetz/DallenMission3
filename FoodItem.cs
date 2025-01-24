using System.Runtime.InteropServices;

namespace Mission3;

public class FoodItem
{
    //2 dimensional array with 4 slots to put info
    public string[,] allFood = new string[0, 4];
    //keeps track of which slot in the array to put info into
    public int foodCount = 0;

    
    public void AddFood(string foodName, string foodCategory, int foodQuantity, string foodExpire)
    {
        //needs to add the 3 things to an array
        //add a new array to the current array?
        // need to make sure they can't add a negative number
        Console.WriteLine($"Adding food: {foodName}");
        Console.WriteLine($"Adding food category: {foodCategory}");
        Console.WriteLine($"Adding food quantity: {foodQuantity}");
        Console.WriteLine($"Adding food expiration date: {foodExpire}");
        
        string[,] newFood = new string[foodCount + 1, 4];
        
        for (int i = 0; i < foodCount; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                newFood[i, j] = allFood[i, j];
            }
        }
        
        newFood[foodCount, 0] = foodName;
        newFood[foodCount, 1] = foodCategory;
        newFood[foodCount, 2] = foodQuantity.ToString();
        newFood[foodCount, 3] = foodExpire;
        
        allFood = newFood;
        foodCount++;
    }

    public void ListFood()
    {
        //print allFood array
        Console.WriteLine("Current Food:");
        for (int i = 0; i < foodCount; i++)
        {
            Console.WriteLine($"{i + 1} Food Name: {allFood[i, 0]}; Food Category: {allFood[i, 1]}; Quantity of Food: {allFood[i, 2]}; Expiration Date: {allFood[i, 3]}");
        }
    }

    public void DeleteFood(string foodName)
    {
        //needs to search the names
        //needs to delete the row with that name
        //how to search the array in the name slot?
        //replace current array like in AddFood?
        bool found = false;
        int notEmptyRows = 0;

        for (int i = 0; i < foodCount; i++)
        {
            if (allFood[i, 0] == foodName)
            {
                found = true;
                Console.WriteLine($"Removing food: {foodName}");
                
                for (int j = 0; j < 4; j++)
                {
                    allFood[i, j] = null;
                }
            }
        }

        if (!found)
        {
            Console.WriteLine($"Could not find food: {foodName}");
            return; 
        }
        
        for (int i = 0; i < foodCount; i++)
        {
            if (!string.IsNullOrEmpty(allFood[i, 0])) 
            {
                notEmptyRows++;
            }
        }
        
        string[,] newNewArray = new string[notEmptyRows, 4];
        int n = 0;

        for (int i = 0; i < foodCount; i++)
        {
            if (!string.IsNullOrWhiteSpace(allFood[i, 0])) 
            {
                for (int j = 0; j < 4; j++)
                {
                    newNewArray[n, j] = allFood[i, j];
                }
                n++;
            }
        }
        
        allFood = newNewArray;
        foodCount = notEmptyRows;
    }


    public void Exit()
    {
        //close the program... how?
        Console.WriteLine("Goodbye!");
        Environment.Exit(0);
    }
}