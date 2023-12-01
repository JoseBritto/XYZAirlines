namespace XYZAirlines.UI.AddFlightScreens;

public class AddFlightScreen3 : AddFlightScreen
{

    private int flightNum;
    private string origin;
    
    public AddFlightScreen3(Screen previous, int flightNum, string origin, string title) : base(title)
    {
        previousScreen = previous;
        this.flightNum = flightNum;
        this.origin = origin;
    }

    public override void displayBody()
    {
        Console.WriteLine($"Create a new flight");
        Console.WriteLine($"Flight Number: {flightNum}");
        Console.WriteLine($"Origin: {origin}");
    }

    public override void displayInputPrompt()
    {
        Console.Write("Enter flight Destination: ");
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
        return input;
    }

    public override Screen handleInput(string input)
    {
        if(input == INVALID)
            return this;
        if(base.handleInput(input) != null)
        {
            return base.handleInput(input);
        }
        var destination = input;
        return new AddFlightScreen4(previousScreen, flightNum, origin, destination, "Add Flight");
    }

}