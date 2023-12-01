namespace XYZAirlines.UI;

public abstract class DynamicMenuScreen : MenuScreen
{
    public DynamicMenuScreen(string title) : base(title, null)
    {
    }
    
    public override void displayBody()
    {
        options = createMenuOptions();
        base.displayBody();
        options = null;
    }

    protected abstract Option[] createMenuOptions();
}