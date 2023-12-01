namespace XYZAirlines.UI;

public class DeleteFlightScreen : TextInputScreen
{
    public DeleteFlightScreen() : base("Delete Flight")
    {
        setNotificationMessage("Enter \"cancel\" to return to discard operation.");
    }

    public override void displayBody()
    {
        Console.WriteLine(Program.Coordinator.displayAllFlights());
    }

    public override void displayInputPrompt()
    {
        Console.Write("Enter flight number to delete: ");
    }

    public override string getInput()
    {
        var input = Console.ReadLine();
        if (string.IsNullOrEmpty(input))
        {
            return INVALID;
        }
        input = input.Trim();
        return int.TryParse(input, out var flightNumber) ? input : INVALID;
    }

    public override Screen handleInput(string input)
    {
        if(base.handleInput(input) != null)
        {
            return base.handleInput(input);
        }
        if(input == INVALID)
        {
            return this;
        }
        var flightNumber = int.Parse(input);
        if(Program.Coordinator.flightNumberExists(flightNumber) == false)
        {
            setErrorMessage($"Flight {flightNumber} not found");
            return this;
        }
        if(Program.Coordinator.getFlightManager().flightHasPassengers(flightNumber))
        {
            setErrorMessage($"Flight {flightNumber} has passengers. Please remove all passengers before deleting the flight.");
            return this;
        }
        
        var flight = Program.Coordinator.getFlightManager().getFlight(flightNumber);
        var confirm = new DeleteFlightConfirmScreen(flight);
        confirm.setPreviousScreen(previousScreen);
        return confirm;
    }

    protected override string getCancelMessage()
    {
        return "Delete flight operation cancelled.";
    }
}