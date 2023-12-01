namespace XYZAirlines.UI.AddCustomerScreens;

public class AddCustomerScreen1 : AddCustomerScreen
{
    public override void displayBody()
    {
        Console.WriteLine("Add a new customer");
    }

    public override void displayInputPrompt()
    {
        Console.Write("Enter customer first name (optional): ");
    }

    public override string getInput()
    {
        var input = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(input))
        {
            input = "N/A";
        }
        input = input.Trim();
        return input;
    }
    
    public override Screen handleInput(string input)
    {
        if (!Program.Coordinator.getCustomerManager().canAddMoreCustomers())
        {
            previousScreen.setErrorMessage("Cannot add more customers. Maximum number of customers reached.");
            return previousScreen;
        }
        var firstName = input;
        if(base.handleInput(input) != null)
        {
            return base.handleInput(input);
        }
        return new AddCustomerScreen2(firstName, previousScreen);
    }
}