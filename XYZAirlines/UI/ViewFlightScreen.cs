namespace XYZAirlines.UI;

public class ViewFlightScreen : Screen
{
    public ViewFlightScreen() : base("View Flights")
    {
    }

    public override void displayBody()
    {
        Console.WriteLine(Program.coordinator.displayAllFlights());
    }

    public override void displayInputPrompt()
    {
        Console.Write("Enter flight number to view more details. [Enter] to go back: ");
    }

    public override string getInput()
    {
        var input = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(input))
            return ENTER;
        
        if (!int.TryParse(input, out var flightNumber) || !Program.coordinator.flightNumberExists(flightNumber))
        {
            return INVALID;
        }
        
        return input;
    }

    public override Screen handleInput(string input)
    {
        if(input == INVALID)
        {
            setErrorMessage("Invalid flight number.");
            return this;
        }
        if (input == ENTER)
            return this.goBack();
        
        var flightNumber = int.Parse(input);
        var flight = Program.coordinator.getFlightManager().getFlight(flightNumber);
        return new ViewFlightDetailsScreen(flight, previousScreen);
    }
}