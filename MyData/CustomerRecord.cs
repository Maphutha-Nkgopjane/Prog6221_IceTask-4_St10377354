using System;
using System.Collections.Generic;
using System.IO; // Required for file operations (File.ReadAllLines)
using System.Linq; // Required for LINQ extensions like .Count() and .Any()

// The CustomerRecord class is responsible for managing customer data
// including reading from a file, processing, and providing statistics.
public class CustomerRecord
{
    // Data members as per UML diagram and description
    // Using List<Customer> for dynamic array behavior, which is more flexible
    // when the number of records is unknown at compile time.
    private List<Customer> customers; // Stores all customer objects read from the file
    private int noOfCustomers;       // Stores the total count of records
    private int noOfDefaults;        // Stores the count of defaulted accounts

    /// <summary>
    /// Constructor for the CustomerRecord class.
    /// Initializes the customer list and counts.
    /// </summary>
    public CustomerRecord()
    {
        customers = new List<Customer>();
        noOfCustomers = 0;
        noOfDefaults = 0;
    }

    /// <summary>
    /// Reads data from the "MyData.csv" file.
    /// It parses each record, creates Customer objects, and populates the customer list.
    /// Handles file not found and parsing errors gracefully.
    /// </summary>
    /// <param name="filePath">The path to the CSV file (e.g., "MyData.csv").</param>
    public void readFromFile(string filePath = "MyData.csv")
    {
        customers.Clear(); // Clear any existing data before reading
        noOfCustomers = 0;
        noOfDefaults = 0; // Reset default count as well

        try
        {
            // Read all lines from the CSV file.
            // File.ReadAllLines reads all lines into a string array.
            string[] lines = File.ReadAllLines(filePath);

            // Skip the header row (assuming the first line is always a header).
            // Start from index 1.
            for (int i = 1; i < lines.Length; i++)
            {
                string line = lines[i];
                // Split each line by comma to get individual fields.
                string[] fields = line.Split(',');

                // Basic validation for the number of fields.
                // Expecting 5 fields: age, default, balance, housing, loan.
                if (fields.Length == 5)
                {
                    try
                    {
                        // Parse the fields to the appropriate data types.
                        int age = int.Parse(fields[0].Trim()); // Trim whitespace
                        string defaults = fields[1].Trim();
                        int balance = int.Parse(fields[2].Trim());
                        string housing = fields[3].Trim();
                        string loan = fields[4].Trim();

                        // Create a new Customer object and populate its attributes.
                        Customer newCustomer = new Customer
                        {
                            Age = age,
                            Defaults = defaults,
                            Balance = balance,
                            Housing = housing,
                            Loan = loan
                        };

                        // Add the new customer object to the list.
                        customers.Add(newCustomer);
                        noOfCustomers++; // Increment total customer count
                    }
                    catch (FormatException fe)
                    {
                        Console.WriteLine($"Error parsing data in line {i + 1}: {line}. Details: {fe.Message}");
                    }
                    catch (OverflowException oe)
                    {
                        Console.WriteLine($"Data too large for type in line {i + 1}: {line}. Details: {oe.Message}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"An unexpected error occurred processing line {i + 1}: {line}. Details: {ex.Message}");
                    }
                }
                else
                {
                    Console.WriteLine($"Skipping malformed line {i + 1} (incorrect number of fields): {line}");
                }
            }
            Console.WriteLine($"Successfully read {noOfCustomers} records from {filePath}.");
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine($"Error: The file '{filePath}' was not found. Please ensure it's in the correct directory.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An unexpected error occurred while reading the file: {ex.Message}");
        }
    }

    /// <summary>
    /// Determines and returns an array of customers who have defaulted.
    /// A customer has defaulted if their 'defaults' column is "yes".
    /// This method also updates the internal count of defaulted customers (noOfDefaults).
    /// </summary>
    /// <returns>An array of Customer objects who have defaulted.</returns>
    public Customer[] defaultAccounts()
    {
        List<Customer> defaultedCustomersList = new List<Customer>();
        noOfDefaults = 0; // Reset count before re-evaluating

        foreach (var customer in customers)
        {
            // Use StringComparison.OrdinalIgnoreCase for case-insensitive comparison
            if (customer.Defaults != null && customer.Defaults.Equals("yes", StringComparison.OrdinalIgnoreCase))
            {
                defaultedCustomersList.Add(customer);
                noOfDefaults++; // Increment count for each defaulted customer found
            }
        }
        // Convert the list of defaulted customers to an array and return it.
        return defaultedCustomersList.ToArray();
    }

    /// <summary>
    /// Displays all customer records currently stored in the object.
    /// It utilizes the Customer class's ToString() method for formatting.
    /// </summary>
    public void display()
    {
        if (!customers.Any()) // Check if the list is empty using LINQ's Any()
        {
            Console.WriteLine("No customer records to display. Please read from file first.");
            return;
        }

        Console.WriteLine("\n--- All Customer Records ---");
        Console.WriteLine("----------------------------");
        foreach (var customer in customers)
        {
            Console.WriteLine(customer.ToString()); // Use the overridden ToString() for display
        }
        Console.WriteLine("----------------------------");
        Console.WriteLine($"Total Customers Displayed: {noOfCustomers}");
    }

    /// <summary>
    /// Returns the total number of customer records read from the file.
    /// </summary>
    /// <returns>The total count of customers.</returns>
    public int getNoOfCustomers()
    {
        return noOfCustomers;
    }

    /// <summary>
    /// Returns the number of customers who have been identified as defaulted.
    /// This count is updated by the defaultAccounts() method.
    /// </summary>
    /// <returns>The count of defaulted customers.</returns>
    public int getNoOfDeafults() // Note: Typo 'Deafults' as per UML, usually 'Defaults'
    {
        return noOfDefaults;
    }
}
