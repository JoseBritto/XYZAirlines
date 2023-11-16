namespace XYZAirlines.UI;

public class ExitingScreen : Screen
{
    public ExitingScreen() : base("Goodbye...")
    {
        
    }

    public override void displayBody()
    {
        Console.WriteLine("Exiting...");
        Environment.Exit(0);
    }

    public override void displayInputPrompt()
    {
        Console.WriteLine();
    }

    public override string getInput()
    {
        return null;
    }

    public override Screen handleInput(string input)
    {
        return null;
    }
}