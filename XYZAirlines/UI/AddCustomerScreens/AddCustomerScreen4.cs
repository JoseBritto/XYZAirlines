namespace XYZAirlines.UI.AddCustomerScreens;

public class AddCustomerScreen4 : AddCustomerScreen
{
    private string firstName;
    private string lastName;
    private string phoneNumber;
    
    public AddCustomerScreen4(string firstName, string lastName, string phoneNumber, Screen previousScreen) : base()
    {
        this.firstName = firstName;
        this.lastName = lastName;
        this.phoneNumber = phoneNumber;
        this.previousScreen = previousScreen;
    }

    public override void displayBody()
    {
        Console.WriteLine("Confirm customer details");
        Console.WriteLine($"First Name: {firstName}");
        Console.WriteLine($"Last Name: {lastName}");
        Console.WriteLine($"Phone Number: {phoneNumber}");
    }
    
    public override void displayInputPrompt()
    {
        Console.Write("Press [Enter] to confirm or [Esc] or [Backspace] to discard: ");
    }

    public override string getInput()
    {
        var input = Console.ReadKey(true);
        if (input.Key == ConsoleKey.Escape || input.Key == ConsoleKey.Backspace)
        {
            return BACK;
        }
        if(input.Key == ConsoleKey.Enter)
        {
            return ENTER;
        }
        return INVALID;
    }

    public override Screen handleInput(string input)
    {
        switch (input)
        {
            case ENTER:
                if(firstName == "N/A")
                    firstName = "";
                if(lastName == "N/A")
                    lastName = "";
                bool result = Program.coordinator.addCustomer(firstName, lastName, phoneNumber);
                if(result == false)
                {
                    previousScreen.setErrorMessage("Customer already exists!");
                    return previousScreen;
                }
                Program.coordinator.save();
                previousScreen.setNotificationMessage($"Customer {firstName} {lastName} added successfully");
                return previousScreen;
            case BACK:
                return previousScreen;
            default:
                return this;
        }
    }
}