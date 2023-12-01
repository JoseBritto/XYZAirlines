namespace XYZAirlines.Models;

public class Coordinator
{
    private FlightManager flightManager;
    private CustomerManager customerManager;
    /*
    private BookingManager bookingManager;
    */
    
    public Coordinator(int maxFlights, int maxCustomers, int maxBookings)
    {
        this.flightManager = new FlightManager(maxFlights);
        this.customerManager = new CustomerManager(maxCustomers);
        /*
        this.bookingManager = new BookingManager(maxBookings);
    */
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
}