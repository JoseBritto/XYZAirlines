namespace XYZAirlines.UI;

public class ViewAllBookingsScreen : Screen
{
    public ViewAllBookingsScreen() : base("View All Bookings")
    {
    }

    public override void displayBody()
    {
        Console.WriteLine(Program.coordinator.displayAllBookings());
    }

    public override void displayInputPrompt()
    {
        Console.Write("Press any key to continue: ");
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