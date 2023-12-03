using XYZAirlines.Models;

namespace XYZAirlines.UI;

public class ViewFlightDetailsScreen : Screen
{
    private Flight flight;
    public ViewFlightDetailsScreen(Flight flight, Screen previous) : base("Flight Details")
    {
        this.flight = flight;
        this.previousScreen = previous;
    }

    public override void displayBody()
    {
        Console.WriteLine(flight);
        Console.WriteLine("Booked Passengers: ");
        Console.WriteLine(Program.coordinator.displayAllBookingsForFlight(flight));
    }

    public override void displayInputPrompt()
    {
        Console.Write("Press any key to go continue: ");
    }

    public override string getInput()
    {
        Console.ReadKey();
        return ENTER;
    }

    public override Screen handleInput(string input)
    {
        return this.goBack();
    }
}