namespace XYZAirlines.UI.AddFlightScreens;

public class AddFlightScreen5 : AddFlightScreen
{
    private int flightNum;
    private string origin;
    private string destination;
    private int capacity;

    public AddFlightScreen5(Screen previous, int flightNum, string origin, string destination, int capacity, string title) : base(title)
    {
        previousScreen = previous;
        this.flightNum = flightNum;
        this.origin = origin;
        this.destination = destination;
        this.capacity = capacity;
    }
    
    public override void displayBody()
    {
        Console.WriteLine($"Create a new flight");
        Console.WriteLine($"Flight Number: {flightNum}");
        Console.WriteLine($"Origin: {origin}");
        Console.WriteLine($"Destination: {destination}");
        Console.WriteLine($"Seat Capacity: {capacity}");
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
                bool result = Program.Coordinator.addFlight(flightNum, origin, destination, capacity);
                if (!result)
                {
                    previousScreen.setErrorMessage("Failed to add flight.");
                    return previousScreen;
                }
                previousScreen.setNotificationMessage("Added successfully: " + Program.Coordinator.getFlightManager().getFlight(flightNum));
                return previousScreen;
            case BACK:
                return previousScreen;
            default:
                return this;
        }
    }
}