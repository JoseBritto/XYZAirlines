namespace XYZAirlines.UI.AddFlightScreens;

public abstract class AddFlightScreen : TextInputScreen
{
    protected AddFlightScreen(string title) : base(title)
    {
    }
    
    protected override string getCancelMessage()
    {
        return "Flight creation cancelled";
    }
}