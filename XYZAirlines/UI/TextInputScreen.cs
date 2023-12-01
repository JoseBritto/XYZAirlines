namespace XYZAirlines.UI;

public abstract class TextInputScreen : Screen
{
    public TextInputScreen(string title) : base(title)
    {
    }

    
    public virtual string handleNavigationInput(string input)
    {
        if (input.ToLower().Trim() == "cancel" || input.ToLower().Trim() == "back" || input.ToLower().Trim() == "exit")
        {
            return BACK;
        }
        return null;
    }

    public override Screen handleInput(string input)
    {
        var navResult = handleNavigationInput(input);
        if(navResult != null)
        {
            previousScreen.setNotificationMessage(getCancelMessage());
            return goBack();
        }

        return null;
    }

    protected abstract string getCancelMessage();
}