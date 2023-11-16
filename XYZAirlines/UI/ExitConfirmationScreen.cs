namespace XYZAirlines.UI;

public class ExitConfirmationScreen : MenuScreen
{
    
    public ExitConfirmationScreen() : base("Exit?",new []
    {
        new Option("Yes", new ExitingScreen()),
        new Option("No", null)
    } )
    {}

    public override void displayBody()
    {
        Console.WriteLine("Are you sure you want to exit?");
        base.displayBody();
    }

    protected override Screen executeOption(Option option)
    {
        return option.getScreen() == null ? previousScreen : option.getScreen();
    }
}