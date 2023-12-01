namespace XYZAirlines.Models;

public class Customer
{
    /*
     * +----------------------------------------+
       |              Customer                  |
       +----------------------------------------+
       | - customerID: int                      |
       | - firstName: String                    |
       | - lastName: String                     |
       | - phone: String                        |
       | - numBookings: int                     |
       +----------------------------------------+
       | + Customer(firstName: String, lastName: String, phone: String) |
       | + getCustomerID(): int                 |
       | + getFirstName(): String               |
       | + getLastName(): String                |
       | + getPhone(): String                   |
       | + incrementNumBookings(): void         |
       | + toString(): String                   |
       +----------------------------------------+
     */
    
    private int customerId;
    private string firstName;
    private string lastName;
    private string phone;
    private int numBookings;
    
    public Customer(int id, string firstName, string lastName, string phone)
    {
        this.customerId = id;
        this.firstName = firstName;
        this.lastName = lastName;
        this.phone = phone;
        this.numBookings = 0;
    }
    
    public int getCustomerId()
    {
        return this.customerId;
    }
    
    public string getFirstName()
    {
        return this.firstName;
    }
    
    public string getLastName()
    {
        return this.lastName;
    }
    
    public string getPhone()
    {
        return this.phone;
    }
    
    public void incrementNumBookings()
    {
        this.numBookings++;
    }
    
    public void decrementNumBookings()
    {
        this.numBookings--;
    }
    
    public int getNumBookings()
    {
        return this.numBookings;
    }
    
    public override string ToString()
    {
        return $"Customer ID: {this.customerId}\n" +
               $"First Name: {this.firstName}\n" +
               $"Last Name: {this.lastName}\n" +
               $"Phone: {this.phone}\n" +
               $"Number of Bookings: {this.numBookings}";
    }
    
    public string getshortString()
    {
        return $"{customerId}. {firstName} {lastName} ({phone})";
    }
}