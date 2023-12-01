namespace XYZAirlines.UI.AddCustomerScreens;

public class AddCustomerScreen2 : AddCustomerScreen
{
    private string firstName;
    public AddCustomerScreen2(string firstName, Screen previousScreen) : base()
    {
        this.firstName = firstName;
        this.previousScreen = previousScreen;
    }
    public override void displayBody()
    {
        Console.WriteLine("Add a new customer");
        Console.WriteLine($"First Name: {firstName}");
    }

    public override void displayInputPrompt()
    {
        if(firstName == "N/A")
            Console.Write("Enter customer last name: ");
        else
            Console.Write("Enter customer last name: ");
        
    }

    public override string getInput()
    {
        var input = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(input) && firstName == "N/A")
        {
            return INVALID;
        }
        if(string.IsNullOrWhiteSpace(input))
            input = "N/A";
        input = input.Trim();
        return input;
    }

    public override Screen handleInput(string input)
    {
        if(base.handleInput(input) != null)
        {
            return base.handleInput(input);
        }
        if (input == INVALID)
        {
            setErrorMessage("Both first and last name cannot be empty");
            return this;
        }
        var lastName = input;
        return new AddCustomerScreen3(firstName, lastName, previousScreen);
    }
}