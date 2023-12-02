namespace XYZAirlines.Models;

public class Booking
{
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
               $"Flight: {flight}\n" +
               $"Customer: {this.customer.getFirstName()} {this.customer.getLastName()}";
    }

    public void setDate(string date)
    {
        this.date = date;
    }

    public string getSaveString()
    {
        return $"{this.bookingNumber},{this.date},{this.flight.getFlightNumber()},{this.customer.getCustomerId()}";
    }
    
    
}