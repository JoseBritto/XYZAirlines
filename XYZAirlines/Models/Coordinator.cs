using XYZAirlines.Helpers;

namespace XYZAirlines.Models;

public class Coordinator
{
    private FlightManager flightManager;
    private CustomerManager customerManager;
    private BookingManager bookingManager;
    
    public Coordinator(int maxFlights, int maxCustomers, int maxBookings)
    {
        this.flightManager = new FlightManager(maxFlights);
        this.customerManager = new CustomerManager(maxCustomers);
        this.bookingManager = new BookingManager(maxBookings);
    }

    public bool load()
    {
        if (!FileUtility.loadData(flightManager, null, null))
            return false;
        
        if(!FileUtility.loadData(customerManager, null, null))
            return false;
        return FileUtility.loadData(bookingManager, flightManager.getFlights(), customerManager.getCustomers());
    }
    
    public void save()
    {
        FileUtility.save(flightManager);
        FileUtility.save(customerManager);
        FileUtility.save(bookingManager);
    }
    
    public bool flightNumberExists(int flightNumber)
    {
        return this.flightManager.flightExists(flightNumber);
    }
    
    public bool addFlight(int flightNumber, string origin, string destination, int maxSeats)
    {
        return flightManager.createFlight(flightNumber, origin, destination, maxSeats);
    }
    
    public string displayAllFlights()
    {
        var flights = this.flightManager.getFlights();
        var result = "*--------- All Flights ---------------*\n";
        foreach (var flight in flights)
        {
            result += flight + "\n";
        }
        result += "*-------------------------------------*";
        return result;
    }
    
    public FlightManager getFlightManager()
    {
        return this.flightManager;
    }
    
    public CustomerManager getCustomerManager()
    {
        return this.customerManager;
    }

    public bool addCustomer(string fName, string lName, string phone)
    {
        return this.customerManager.addCustomer(fName, lName, phone);
    }

    public string displayAllCustomers()
    {
        var customers = this.customerManager.getCustomers();
        var result = "*--------- All Customers ---------------*\n";
        foreach (var customer in customers)
        {
            result += customer + "\n";
            result += "*-------------------------------------*\n";
        }
        result += "*-------------------------------------*";
        return result;
    }
    
    public bool createBoooking(int customerId, int flightNumber)
    {
        var customer = this.customerManager.getCustomer(customerId);
        if(customer == null)
        {
            return false;
        }
        var flight = this.flightManager.getFlight(flightNumber);
        if(flight == null)
        {
            return false;
        }
        return this.bookingManager.bookFlight(customer, flight, DateTime.Now.ToString("yyyy-MM-dd h:mm tt"));
    }
    
    public string displayAllBookings()
    {
        var bookings = this.bookingManager.getBookings();
        var result = "*--------- All Bookings ---------------*\n";
        foreach (var booking in bookings)
        {
            result += booking + "\n";
            result += "*-------------------------------------*\n";
        }
        result += "*-------------------------------------*";
        return result;
    }
    
    public string displayAllBookingsForCustomer(Customer customer)
    {
        var bookings = this.bookingManager.getBookingsForCustomer(customer);
        var result = "*--------- All Bookings ---------------*\n";
        foreach (var booking in bookings)
        {
            result += booking + "\n";
            result += "*-------------------------------------*\n";
        }
        result += "*-------------------------------------*";
        return result;
    }
    
    public string displayAllBookingsForFlight(Flight flight)
    {
        var bookings = this.bookingManager.getBookingsForFlight(flight);
        var result = "*--------- All Bookings ---------------*\n";
        foreach (var booking in bookings)
        {
            result += booking + "\n";
            result += "*-------------------------------------*\n";
        }
        result += "*-------------------------------------*";
        return result;
    }
    
    public BookingManager getBookingManager()
    {
        return this.bookingManager;
    }
    
    public bool removeFlight(int flightNumber)
    {
        return this.flightManager.removeFlight(flightNumber);
    }
    
    public bool removeCustomer(int customerId)
    {
        return this.customerManager.removeCustomer(customerId);
    }
    
    public bool cancelBooking(int bookingNumber)
    {
        return this.bookingManager.cancelBooking(bookingNumber);
    }
    
    public bool updateFlight(int flightNumber, string origin, string destination, int maxSeats)
    {
        return this.flightManager.updateFlight(flightNumber, origin, destination, maxSeats);
    }
    
    public bool updateCustomer(int customerId, string fName, string lName, string phone)
    {
        return this.customerManager.updateCustomer(customerId, fName, lName, phone);
    }
    
    public bool updateBooking(int bookingNumber, string date)
    {
        return this.bookingManager.updateBooking(bookingNumber, date);
    }
    
    public Flight[] getFlights()
    {
        return this.flightManager.getFlights();
    }
    
    public Customer[] getCustomers()
    {
        return this.customerManager.getCustomers();
    }
    
    public Booking[] getBookings()
    {
        return this.bookingManager.getBookings();
    }
    
    public Flight getFlight(int flightNumber)
    {
        return this.flightManager.getFlight(flightNumber);
    }
    
    
    public Customer getCustomer(int customerId)
    {
        return this.customerManager.getCustomer(customerId);
    }
    
    public Booking getBooking(int bookingNumber)
    {
        return this.bookingManager.getBooking(bookingNumber);
    }
    
    public bool customerExists(string fName, string lName, string phone)
    {
        return this.customerManager.customerExists(fName, lName, phone);
    }
    
    public bool customerExists(int customerId)
    {
        return this.customerManager.customerExists(customerId);
    }
    
    public bool flightExists(int flightNumber)
    {
        return this.flightManager.flightExists(flightNumber);
    }
    
    public bool bookingExists(int bookingNumber)
    {
        return this.bookingManager.bookingExists(bookingNumber);
    }
    
    public bool flightHasBookings(int flightNumber)
    {
        return this.flightManager.getFlight(flightNumber).getNumPassengers() > 0;
    }
    
    public bool customerHasBookings(int customerId)
    {
        return this.customerManager.getCustomer(customerId).getNumBookings() > 0;
    }
    
    public bool flightHasAvailableSeats(int flightNumber)
    {
        return this.flightManager.flightHasAvailableSeats(flightNumber);
    }
    
    public bool customerHasBookingsOnFlight(int customerId, int flightNumber)
    {
        return this.bookingManager.customerHasBookingsOnFlight(customerId, flightNumber);
    }
   
}