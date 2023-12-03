namespace XYZAirlines.UI.CreateBookingScreens;

public class CreateBookingScreen2 : TextInputScreen
{
    private int flightNum;
    
    public CreateBookingScreen2(Screen previous, int flightNum, string title) : base(title)
    {
        previousScreen = previous;
        this.flightNum = flightNum;
    }
    
    
    public override void displayBody()
    {
        Program.coordinator.displayAllCustomers();
    }

    public override void displayInputPrompt()
    {
        Console.WriteLine("Enter customer ID or [cancel] to go discard: ");
    }

    public override string getInput()
    {
        var input = Console.ReadLine()?.Trim();
        if(handleNavigationInput(input) != null)
        {
            return handleNavigationInput(input);
        }
        if (string.IsNullOrEmpty(input))
        {
            return INVALID;
        }
        return int.TryParse(input, out var customerId) && Program.coordinator.customerExists(customerId) ? input : INVALID;
    }

    public override Screen handleInput(string input)
    {
        if(input == INVALID)
        {
            setErrorMessage("Please enter a valid customer ID.");
            return this;
        }
        if(base.handleInput(input) != null)
        {
            return base.handleInput(input);
        }
        var customerId = int.Parse(input);
        return new CreateBookingScreen3(previousScreen, flightNum, customerId, title);
    }

    protected override string getCancelMessage()
    {
        return "Booking operation cancelled.";
    }
}