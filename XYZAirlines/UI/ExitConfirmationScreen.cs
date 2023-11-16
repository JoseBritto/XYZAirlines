namespace XYZAirlines.UI;

public class ExitConfirmationScreen : MenuScreen
{
    
    public ExitConfirmationScreen(Screen mainMenu) : base("Goodbye",new []
    {
        new Option("Yes", null),
        new Option("No", mainMenu)
    } )
    {}

    public override void displayHeader()
    {
        base.displayHeader();
        Console.WriteLine("Are you sure you want to exit?");
    }
}