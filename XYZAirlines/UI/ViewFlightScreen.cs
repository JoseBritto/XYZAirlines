namespace XYZAirlines.UI;

public class ViewFlightScreen : Screen
{
    public ViewFlightScreen() : base("View Flights")
    {
    }

    public override void displayBody()
    {
        Console.WriteLine(Program.Coordinator.displayAllFlights());
    }

    public override void displayInputPrompt()
    {
        Console.Write("Press any key to return to continue: ");
    }

    public override string getInput()
    {
        Console.ReadKey();
        return ENTER;
    }

    public override Screen handleInput(string input)
    {
        return previousScreen;
    }
}