using XYZAirlines.Models;

namespace XYZAirlines.UI;

public class DeleteBookingScreen : TextInputScreen
{
    public DeleteBookingScreen() : base("Delete Booking")
    {
    }

    public override void displayBody()
    {
        Console.WriteLine(Program.coordinator.displayAllBookings());
    }

    public override void displayInputPrompt()
    {
        Console.Write("Enter booking number to delete ('cancel' to discard): ");
    }

    public override string getInput()
    {
        var input = Console.ReadLine();
        if (string.IsNullOrEmpty(input))
        {
            return INVALID;
        }
        input = input.Trim();
        if(handleNavigationInput(input) != null)
        {
            return handleNavigationInput(input);
        }
        return int.TryParse(input, out var bookingNumber) ? input : INVALID;
    }
    
    public override Screen handleInput(string input)
    {
        if(base.handleInput(input) != null)
        {
            return base.handleInput(input);
        }
        if(input == INVALID)
        {
            setErrorMessage("Invalid booking number.");
            return this;
        }
        var bookingNumber = int.Parse(input);
        if(Program.coordinator.getBookingManager().bookingExists(bookingNumber) == false)
        {
            setErrorMessage($"Booking {bookingNumber} not found");
            return this;
        }
        var booking = Program.coordinator.getBookingManager().getBooking(bookingNumber);
        var confirm = new DeleteBookingConfirmScreen(booking);
        confirm.setPreviousScreen(previousScreen);
        return confirm;
    }

    protected override string getCancelMessage()
    {
        return "Delete booking operation cancelled.";
    }
}