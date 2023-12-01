namespace XYZAirlines.UI.AddFlightScreens;

public class AddFlightScreen4 : AddFlightScreen
{
    private int flightNum;
    private string origin;
    private string destination;
    
    public AddFlightScreen4(Screen previous,int flightNum, string origin, string destination, string title) : base(title)
    {
        previousScreen = previous;
        this.flightNum = flightNum;
        this.origin = origin;
        this.destination = destination;
    }

    public override void displayBody()
    {
        Console.WriteLine($"Create a new flight");
        Console.WriteLine($"Flight Number: {flightNum}");
        Console.WriteLine($"Origin: {origin}");
        Console.WriteLine($"Destination: {destination}");
    }

    public override void displayInputPrompt()
    {
        Console.Write("Enter seat capacity: ");
    }

    public override string getInput()
    {
        var input = Console.ReadLine();
        if (string.IsNullOrEmpty(input))
        {
            return INVALID;
        }
        if(input.ToLower() == "cancel")
        {
            return BACK;
        }
        input = input.Trim();
        return int.TryParse(input, out var capacity) && capacity > 0 ? input : INVALID;
    }

    public override Screen handleInput(string input)
    {
        if(input == INVALID)
        {
            setErrorMessage("Invalid capacity. Please enter a positive integer.");
            return this;
        }
        if(base.handleInput(input) != null)
        {
            return base.handleInput(input);
        }
        var capacity = int.Parse(input);
        return new AddFlightScreen5(previousScreen, flightNum, origin, destination, capacity, "Add Flight");
    }
}