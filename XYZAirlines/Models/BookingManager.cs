namespace XYZAirlines.Models;

public class BookingManager : Saveable
{
    private Booking[] bookings;
    private int numBookings;
    
    private static int nextBookingNumber = 1;
    
    public BookingManager(int maxBookings)
    {
        this.bookings = new Booking[maxBookings];
        this.numBookings = 0;
    }
    
    public bool bookFlight(Customer customer, Flight flight, string date)
    {
        if (this.numBookings == this.bookings.Length)
        {
            return false;
        }
        var booking = new Booking(nextBookingNumber, date, flight, customer);
        
        customer.incrementNumBookings();
        flight.incrementNumPassengers(); 
        this.bookings[this.numBookings] = booking;
        this.numBookings++;
        nextBookingNumber++;
        return true;
    }
    
    public Booking[] getBookings()
    {
        var result = new Booking[this.numBookings];
        for (var i = 0; i < this.numBookings; i++)
        {
            result[i] = this.bookings[i];
        }
        return result;
    }
    
    public int getNumBookings()
    {
        return this.numBookings;
    }
    
    public Booking getBooking(int bookingNumber)
    {
        for (var i = 0; i < this.numBookings; i++)
        {
            var booking = this.bookings[i];
            if (booking.getBookingNumber() == bookingNumber)
            {
                return booking;
            }
        }
        return null;
    }
    
    public Booking[] getBookingsForCustomer(Customer customer)
    {
        var result = new Booking[customer.getNumBookings()];
        var index = 0;
        for (var i = 0; i < this.numBookings; i++)
        {
            var booking = this.bookings[i];
            if (booking.getCustomer() == customer)
            {
                result[index] = booking;
                index++;
            }
        }
        return result;
    }
    
    public Booking[] getBookingsForFlight(Flight flight)
    {
        var result = new Booking[flight.getNumPassengers()];
        var index = 0;
        for (var i = 0; i < this.numBookings; i++)
        {
            var booking = this.bookings[i];
            if (booking.getFlight() == flight)
            {
                result[index] = booking;
                index++;
            }
        }
        return result;
    }
    
    public bool cancelBooking(int bookingNumber)
    {
        for (var i = 0; i < this.numBookings; i++)
        {
            var booking = this.bookings[i];
            if (booking.getBookingNumber() != bookingNumber) 
                continue;
            var customer = booking.getCustomer();
            var flight = booking.getFlight();
            customer.decrementNumBookings();
            flight.decrementNumPassengers();
            this.bookings[i] = this.bookings[this.numBookings - 1];
            this.numBookings--;
            return true;
        }
        return false;
    }

    public bool bookingExists(int bookingNumber)
    {
        for (var i = 0; i < this.numBookings; i++)
        {
            var booking = this.bookings[i];
            if (booking.getBookingNumber() == bookingNumber)
            {
                return true;
            }
        }
        return false;
    }

    public bool customerHasBookingsOnFlight(int customerId, int flightNumber)
    {
        for (var i = 0; i < this.numBookings; i++)
        {
            var booking = this.bookings[i];
            if (booking.getCustomer().getCustomerId() == customerId && booking.getFlight().getFlightNumber() == flightNumber)
            {
                return true;
            }
        }
        return false;
    }

    public bool updateBooking(int bookingNumber, string date)
    {
        Booking booking = getBooking(bookingNumber);
        if (booking == null)
            return false;
        booking.setDate(date);
        return true;
    }

    public string getSaveString()
    {
        string saveString = $"{nextBookingNumber}\n";
        for (int i = 0; i < numBookings; i++)
        {
            saveString += bookings[i].getSaveString() + "\n";
        }

        return saveString;
    }

    public bool loadSaveString(string saveString, Flight[] flights, Customer[] customers)
    {
        string[] lines = saveString.Split("\n");
        nextBookingNumber = int.Parse(lines[0]);
        foreach (string line in lines.Skip(1))
        {
            if (line == "")
                continue;
            string[] values = line.Split(",");
            int bookingNumber = int.Parse(values[0]);
            string date = values[1];
            int flightNumber = int.Parse(values[2]);
            int customerId = int.Parse(values[3]);
            Flight flight = flights.Where(x => x.getFlightNumber() == flightNumber).FirstOrDefault();
            Customer customer = customers.Where(x => x.getCustomerId() == customerId).FirstOrDefault();
            if(flight == null || customer == null)
                return false;
            Booking booking = new Booking(bookingNumber, date, flight, customer);
            bookings[numBookings] = booking;
            numBookings++;
        }
        return true;
    }

    public string getSaveIdentifier()
    {
        return "bookings";
    }
}