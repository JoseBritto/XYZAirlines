namespace XYZAirlines.UI;

public class Option
{
    private string displayText;
    private Screen linkedScreen;
    public Option(string displayText, Screen linkedScreen)
    {
        this.displayText = displayText; 
        this.linkedScreen = linkedScreen;
    }
    
    public string getDisplayText()
    {
        return this.displayText;
    }
    
    public Screen getScreen()
    {
        return this.linkedScreen;
    }
}