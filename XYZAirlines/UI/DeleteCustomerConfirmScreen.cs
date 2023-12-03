using XYZAirlines.Models;

namespace XYZAirlines.UI;

public class DeleteCustomerConfirmScreen : Screen
{
    private Customer customer;

    public DeleteCustomerConfirmScreen(Customer customer, Screen previousScreen) : base("Delete Customer?")
    {
        this.customer = customer;
        this.previousScreen = previousScreen;
    }
    
    public override void displayBody()
    {
        Console.WriteLine("Are you sure you want to delete this customer?");
        Console.WriteLine("---------------------------------------------");
        Console.WriteLine(customer);
        Console.WriteLine("---------------------------------------------");
    }
    
    public override void displayInputPrompt()
    {
        Console.WriteLine("Press [Enter] to confirm or any other key to cancel");
    }
    
    public override string getInput()
    {
        var input = Console.ReadKey(true);
        return input.Key == ConsoleKey.Enter ? ENTER : INVALID;
    }
    
    public override Screen handleInput(string input)
    {
        if (input == ENTER)
        {
            if(!Program.coordinator.getCustomerManager().removeCustomer(customer.getCustomerId()))
            {
                previousScreen.setErrorMessage($"Failed to delete Customer with id {customer.getCustomerId()}");
                return previousScreen;
            }
            Program.coordinator.save();
            previousScreen.setNotificationMessage($"Customer {customer.getCustomerId()} deleted successfully.");
            return previousScreen;
        }
        
        previousScreen.setNotificationMessage($"Delete customer operation cancelled.");
        return previousScreen;
    }
}