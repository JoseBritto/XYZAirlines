namespace XYZAirlines.Models;

public class Flight
{
    private int flightNumber;
    private string origin;
    private string destination;
    private int maxSeats;
    private Booking[] bookings;
    private int numPassengers;
    
    public Flight(int flightNumber, string origin, string destination, int maxSeats)
    {
        this.flightNumber = flightNumber;
        this.origin = origin;
        this.destination = destination;
        this.maxSeats = maxSeats;
        this.bookings = new Booking[maxSeats];
        this.numPassengers = 0;
    }
    
    public int getFlightNumber()
    {
        return this.flightNumber;
    }
    
    public string getOrigin()
    {
        return this.origin;
    }
    
    public string getDestination()
    {
        return this.destination;
    }
    
    public int getMaxSeats()
    {
        return this.maxSeats;
    }
    
    public Booking[] getBookings()
    {
        return this.bookings;
    }
    
    public bool addBooking(Booking booking)
    {
        if (this.numPassengers >= this.maxSeats)
        {
            return false;
        }
        this.bookings[this.numPassengers] = booking;
        this.numPassengers++;
        return true;
    }
    
    public bool removeBooking(int bookingNumber)
    {
        for (int i = 0; i < this.numPassengers; i++)
        {
            if (this.bookings[i].getBookingNumber() == bookingNumber)
            {
                this.bookings[i] = this.bookings[this.numPassengers - 1];
                this.bookings[this.numPassengers - 1] = null;
                this.numPassengers--;
                return true;
            }
        }
        return false;
    }
    
    public bool removePassenger(int customerID)
    {
        for (int i = 0; i < this.numPassengers; i++)
        {
            if (this.bookings[i].getCustomer().getCustomerId() == customerID)
            {
                this.bookings[i] = this.bookings[this.numPassengers - 1];
                this.bookings[this.numPassengers - 1] = null;
                this.numPassengers--;
                return true;
            }
        }
        return false;
    }
    
    public int getNumPassengers()
    {
        return this.numPassengers;
    }
    
    public override string ToString()
    {
        return $"Flight {this.flightNumber} from {this.origin} to {this.destination} ({this.numPassengers}/{this.maxSeats} passengers)";
    }

}