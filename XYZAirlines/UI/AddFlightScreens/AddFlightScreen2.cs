namespace XYZAirlines.UI.AddFlightScreens;

public class AddFlightScreen2 : AddFlightScreen
{
    private int flightNum;

    public AddFlightScreen2(Screen previous, int flightNum, string title) : base(title)
    {
        previousScreen = previous;
        this.flightNum = flightNum;
    }

    public override void displayBody()
    {
        Console.WriteLine($"Create a new flight");
        Console.WriteLine($"Flight Number: {flightNum}");
    }

    public override void displayInputPrompt()
    {
        Console.Write("Enter flight Origin: ");
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
        if (input == INVALID)
            return this;
        if(base.handleInput(input) != null)
        {
            return base.handleInput(input);
        }
        
        var origin = input;
        return new AddFlightScreen3(previousScreen, flightNum, origin, "Add Flight");
    }
}