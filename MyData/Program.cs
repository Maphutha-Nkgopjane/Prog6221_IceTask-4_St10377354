using System;
using System.Collections.Generic;
using System.Linq; // Not strictly needed for this Main, but good practice for C# projects

// The Customer class would typically be in Customer.cs
// public class Customer
// {
//     // ... (Your Customer class code here) ...
// }

// The CustomerRecord class would typically be in CustomerRecord.cs
// public class CustomerRecord
// {
//     // ... (Your CustomerRecord class code here) ...
// }

public class Program
{
    public static void Main(string[] args)
    {
        // Question 3: Main Method Implementation

        // Create an object of CustomerRecord which will be used throughout the main method
        CustomerRecord bankRecords = new CustomerRecord();

        // Using the CustomerRecord object, read from the file and display the number of
        // records stored in the file.
        Console.WriteLine("Reading data from MyData.csv...");
        bankRecords.readFromFile("MyData.csv"); // Ensure MyData.csv is in the project's output directory
        Console.WriteLine($"\nRecords have been read");
        Console.WriteLine($"Number of records : {bankRecords.getNoOfCustomers()}");

        // Determine defaulted accounts and get the array of defaulted customers
        Customer[] defaultedCustomers = bankRecords.defaultAccounts();

        // Display all customer’s ages that have defaulted as shown Figure 1
        Console.WriteLine("\nDefaulted Members ages :");
        if (defaultedCustomers.Length > 0)
        {
            for (int i = 0; i < defaultedCustomers.Length; i++)
            {
                Console.WriteLine($"No {i + 1} : {defaultedCustomers[i].Age}");
            }
        }
        else
        {
            Console.WriteLine("No defaulted customers found.");
        }

        // Display all records founds as shown Figure 2
        // This will use the display() method from the CustomerRecord class
        bankRecords.display();

        Console.WriteLine("\nPress any key to exit.");
        Console.ReadKey(); // Keep the console window open until a key is pressed
    }
}
