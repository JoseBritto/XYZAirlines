namespace XYZAirlines.UI;

public abstract class Screen
{
    protected const string BACK = "back";
    protected const string ENTER = "enter";
    protected const string UP = "up";
    protected const string DOWN = "down";
    protected const string INVALID = "invalid";
    
    protected Screen previousScreen;
    protected string title;
    private string errorMessage;
    private string notificationMessage;

    public Screen(string title)
    {
        previousScreen = null;
        this.title = title;
    }
    public virtual void displayHeader()
    {
        Console.WriteLine("========================");
        Console.WriteLine(title != null ? $"XYZ Airlines - {title}" : "XYZ Airlines");
        Console.WriteLine("========================");
    }
    public abstract void displayBody();
    public abstract void displayInputPrompt();
    public abstract string getInput();
    public abstract Screen handleInput(string input);
    
    public Screen show()
    {
        displayHeader();
        displayBody();
        displayMessages();
        errorMessage = null;
        notificationMessage = null;
        displayInputPrompt();
        var input = getInput();
        var result = handleInput(input);
        if (result == null)
        {
            Console.Beep();
            return this;
        }
        return result;
    }

    protected virtual void displayMessages()
    {
        if(!string.IsNullOrEmpty(errorMessage))
        {
            var color = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(errorMessage);
            Console.ForegroundColor = color;
            return;
        }
        if(!string.IsNullOrEmpty(notificationMessage))
        {
            var color = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(notificationMessage);
            Console.ForegroundColor = color;
            return;
        }

        Console.WriteLine();
        
    }

    public Screen goBack()
    {
        return previousScreen;
    }
    
    public void setPreviousScreen(Screen previousScreen)
    {
        this.previousScreen = previousScreen;
    }
    
    public void setErrorMessage(string errorMessage)
    {
        this.errorMessage = errorMessage;
    }
    
    public void setNotificationMessage(string notificationMessage)
    {
        this.notificationMessage = notificationMessage;
    }

}