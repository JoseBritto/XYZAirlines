namespace XYZAirlines.UI;

public class ViewCustomerScreen : Screen
{
    public ViewCustomerScreen() : base("View Customers")
    {
    }

    public override void displayBody()
    {
        Console.WriteLine(Program.Coordinator.displayAllCustomers());
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