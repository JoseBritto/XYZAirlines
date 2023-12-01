namespace XYZAirlines.Models;

public class Booking
{
    /*
     * +----------------------------------------+
       |              Booking                   |
       +----------------------------------------+
       | - bookingNumber: int                   |
       | - date: String                         |
       | - flight: Flight                       |
       | - customer: Customer                   |
       +----------------------------------------+
       | + Booking(date: String, flight: Flight, customer: Customer) |
       | + getBookingNumber(): int              |
       | + getDate(): String                    |
       | + getFlight(): Flight                  |
       | + getCustomer(): Customer              |
       | + toString(): String                   |
       +----------------------------------------+
     */
    
    private int bookingNumber;
    private string date;
    private Flight flight;
    private Customer customer;
    
    public Booking(int bookingNumber, string date, Flight flight, Customer customer)
    {
        this.bookingNumber = bookingNumber;
        this.date = date;
        this.flight = flight;
        this.customer = customer;
    }
    
    public int getBookingNumber()
    {
        return this.bookingNumber;
    }
    
    public string getDate()
    {
        return this.date;
    }
    
    public Flight getFlight()
    {
        return this.flight;
    }
    
    public Customer getCustomer()
    {
        return this.customer;
    }
    
    public override string ToString()
    {
        return $"Booking Number: {this.bookingNumber}\n" +
               $"Date: {this.date}\n" +
               $"Flight: {this.flight.getFlightNumber()}\n" +
               $"Customer: {this.customer.getCustomerId()}";
    }
}