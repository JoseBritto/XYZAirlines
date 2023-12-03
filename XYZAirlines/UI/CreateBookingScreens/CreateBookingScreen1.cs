namespace XYZAirlines.UI.CreateBookingScreens;

public class CreateBookingScreen1 : TextInputScreen
{
    public CreateBookingScreen1() : base("Create Booking")
    {
    }

    public override void displayBody()
    {
        Program.coordinator.displayAllFlights();
    }

    public override void displayInputPrompt()
    {
        Console.WriteLine("Enter flight number or [cancel] to go discard booking: ");
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
        return int.TryParse(input, out var flightNumber) && Program.coordinator.flightNumberExists(flightNumber) ? input : INVALID;
    }

    protected override string getCancelMessage()
    {
        return "Booking cancelled.";
    }
    
    public override Screen handleInput(string input)
    {
        if(input == INVALID)
        {
            setErrorMessage("Please enter a valid flight number.");
            return this;
        }
        if(base.handleInput(input) != null)
        {
            return base.handleInput(input);
        }
        var flightNumber = int.Parse(input);
        return new CreateBookingScreen2(previousScreen, flightNumber, title);
    }
}