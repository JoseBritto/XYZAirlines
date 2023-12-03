namespace XYZAirlines.UI.CreateBookingScreens;

public class CreateBookingScreen3 : Screen
{
    private int flightNum;
    private int customerId;
    
    public CreateBookingScreen3(Screen previousScreen, int flightNum, int customerId, string title) : base(title)
    {
        this.previousScreen = previousScreen;
        this.flightNum = flightNum;
        this.customerId = customerId;
    }

    public override void displayBody()
    {
        var flight = Program.coordinator.getFlight(flightNum);
        Console.WriteLine($"Flight: {flight}");
        var customer = Program.coordinator.getCustomer(customerId);
        Console.WriteLine($"Customer: {customer.getshortString()}");
    }

    public override void displayInputPrompt()
    {
        Console.WriteLine("Press [enter] to confirm booking or any other key to cancel: ");
    }

    public override string getInput()
    {
        ConsoleKeyInfo keyInfo = Console.ReadKey(true);
        if (keyInfo.Key == ConsoleKey.Enter)
        {
            return ENTER;
        }
        return INVALID;
    }

    public override Screen handleInput(string input)
    {
        if(input == ENTER)
        {
            if(Program.coordinator.createBoooking(customerId, flightNum))
            {
                Program.coordinator.save();
                previousScreen.setNotificationMessage("Booking created.");
                return previousScreen;
            }
            previousScreen.setErrorMessage("Booking could not be created.");
            return previousScreen;
        }

        previousScreen.setNotificationMessage("Create Booking operation cancelled.");
        return previousScreen;

    }

}