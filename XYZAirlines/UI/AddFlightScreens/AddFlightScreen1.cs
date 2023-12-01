namespace XYZAirlines.UI.AddFlightScreens;

public class AddFlightScreen1 : AddFlightScreen
{
    public AddFlightScreen1() : base("Add Flight")
    {
        setNotificationMessage("Enter \"cancel\" anytime to discard the operation.");
    }

    public override void displayBody()
    {
        Console.WriteLine("Create a new flight");
    }

    public override void displayInputPrompt()
    {
        Console.Write("Enter flight Number: ");
    }

    public override string getInput()
    {
        var input = Console.ReadLine();
        if (string.IsNullOrEmpty(input))
        {
            return INVALID;
        }
        input = input.Trim();
        if(input.ToLower() == "cancel")
        {
            return BACK;
        }
        return int.TryParse(input, out var flightNumber) && flightNumber > 0 ? input : INVALID;
    }

    public override Screen handleInput(string input)
    {
        if(Program.Coordinator.getFlightManager().canAddMoreFlights())
        {
            previousScreen.setErrorMessage("Cannot add more flights. Maximum number of flights reached.");
            return previousScreen;
        }
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
        if(Program.Coordinator.flightNumberExists(flightNumber))
        {
            setErrorMessage("Flight number already exists. Please enter a different flight number.");
            return this;
        }
        return new AddFlightScreen2(previousScreen, flightNumber, "Add Flight");
    }
}