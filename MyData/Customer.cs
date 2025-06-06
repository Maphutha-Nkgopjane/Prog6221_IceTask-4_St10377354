using System;

// Defines the Customer class to hold attributes for each record in MyData.csv
public class Customer
{
    // Private fields to store the customer's data.
    // These align with the columns in your CSV file.
    private int age;
    private string defaults; // "yes" or "no" for defaulted status
    private int balance;
    private string housing;  // "yes" or "no" for housing loan
    private string loan;     // "yes" or "no" for personal loan

    // Public properties to expose the customer's attributes.
    // 'get' allows reading the value, 'set' allows writing the value.

    /// <summary>
    /// Gets or sets the age of the customer.
    /// </summary>
    public int Age
    {
        get { return age; }
        set { age = value; }
    }

    /// <summary>
    /// Gets or sets the default status of the customer ("yes" or "no").
    /// </summary>
    public string Defaults
    {
        get { return defaults; }
        set { defaults = value; }
    }

    /// <summary>
    /// Gets or sets the balance of the customer's account.
    /// </summary>
    public int Balance
    {
        get { return balance; }
        set { balance = value; }
    }

    /// <summary>
    /// Gets or sets the housing loan status of the customer ("yes" or "no").
    /// </summary>
    public string Housing
    {
        get { return housing; }
        set { housing = value; }
    }

    /// <summary>
    /// Gets or sets the personal loan status of the customer ("yes" or "no").
    /// Note: This property was part of the CSV format description,
    /// but not explicitly listed in your UML diagram for properties.
    /// I've included it here to match the CSV file format provided.
    /// </summary>
    public string Loan
    {
        get { return loan; }
        set { loan = value; }
    }

    // You could also add a constructor here if you wanted to initialize
    // Customer objects directly with values, e.g.:
    // public Customer(int age, string defaults, int balance, string housing, string loan)
    // {
    //     Age = age;
    //     Defaults = defaults;
    //     Balance = balance;
    //     Housing = housing;
    //     Loan = loan;
    // }

    // It's also good practice to override ToString() for easy debugging and display:
    public override string ToString()
    {
        return $"Age: {Age}, Default: {Defaults}, Balance: {Balance}, Housing: {Housing}, Loan: {Loan}";
    }
}
