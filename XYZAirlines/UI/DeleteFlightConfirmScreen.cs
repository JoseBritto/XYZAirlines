using XYZAirlines.Models;

namespace XYZAirlines.UI;

public class DeleteFlightConfirmScreen : Screen
{
    private Flight flight;

    public DeleteFlightConfirmScreen(Flight flight) : base("Confirm Action")
    {
        this.flight = flight;
    }

    public override void displayBody()
    {
        Console.WriteLine($"Please confirm you want to permanently delete {flight}");
        Console.WriteLine("This action cannot be undone.");
    }

    public override void displayInputPrompt()
    {
        Console.WriteLine("Press [Enter] to confirm or any other key to cancel");
    }

    public override string getInput()
    {
        var input = Console.ReadKey(true);
        return input.Key == ConsoleKey.Enter ? ENTER : INVALID;
    }

    public override Screen handleInput(string input)
    {
        if (input == ENTER)
        {
            if(!Program.Coordinator.getFlightManager().removeFlight(flight.getFlightNumber()))
            {
                previousScreen.setErrorMessage($"Failed to delete Flight {flight.getFlightNumber()}");
                return previousScreen;
            }
            previousScreen.setNotificationMessage($"Flight {flight.getFlightNumber()} deleted successfully.");
            return previousScreen;
        }

        previousScreen.setNotificationMessage($"Delete flight operation cancelled.");
        return previousScreen;
    }
}