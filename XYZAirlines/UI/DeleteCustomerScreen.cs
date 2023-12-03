namespace XYZAirlines.UI;

public class DeleteCustomerScreen : Screen
{
    public DeleteCustomerScreen() : base("Delete Customer")
    {
    }
    public override void displayBody()
    {
        Console.WriteLine("Select a customer to delete:");
        foreach (var customer in Program.coordinator.getCustomerManager().getCustomers())
        {
            Console.WriteLine(customer.getshortString());
        }
    }

    public override void displayInputPrompt()
    {
        Console.Write("Enter the ID of the customer to delete: ");
    }

    public override string getInput()
    {
        var input = Console.ReadLine();
        if (string.IsNullOrEmpty(input))
        {
            return INVALID;
        }
        input = input.Trim();
        return int.TryParse(input, out var customerID) ? input : INVALID;
    }

    public override Screen handleInput(string input)
    {
        if (input == INVALID)
        {
            return this;
        }
        var customerID = int.Parse(input);
        var customer = Program.coordinator.getCustomerManager().getCustomer(customerID);
        if (customer == null)
        {
            setErrorMessage("Invalid customer ID");
            return this;
        }
        return new DeleteCustomerConfirmScreen(customer, previousScreen);
    }
}