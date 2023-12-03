using XYZAirlines.Models;

namespace XYZAirlines.UI;

public class DeleteBookingConfirmScreen : Screen
{
    private Booking booking;
    public DeleteBookingConfirmScreen(Booking booking) : base("Confirm Delete")
    {
        this.booking = booking;
    }

    public override void displayBody()
    {
        Console.WriteLine("Are you sure you want to delete this booking?");
        Console.WriteLine(booking);
    }

    public override void displayInputPrompt()
    {
        Console.Write("Enter 'yes' to confirm, 'no' to cancel: ");
    }

    public override string getInput()
    {
        var input = Console.ReadLine();
        if (string.IsNullOrEmpty(input))
        {
            return INVALID;
        }
        input = input.Trim();
        return input == "yes" || input == "no" ? input : INVALID;
    }

    public override Screen handleInput(string input)
    {
        if (input == INVALID)
        {
            setErrorMessage("Invalid input.");
            return this;
        }
        if (input == "no")
        {
            return this.goBack();
        }
        Program.coordinator.cancelBooking(booking.getBookingNumber());
        setNotificationMessage($"Booking {booking.getBookingNumber()} deleted.");
        previousScreen.setNotificationMessage($"Booking {booking.getBookingNumber()} deleted.");
        return this.goBack();
    }
}