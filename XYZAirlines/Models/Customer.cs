namespace XYZAirlines.Models;

public class Customer
{
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
    public Customer(int id, string firstName, string lastName, string phone, int numBookings)
    {
        this.customerId = id;
        this.firstName = firstName;
        this.lastName = lastName;
        this.phone = phone;
        this.numBookings = numBookings;
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
    
    public string getShortString()
    {
        return $"{customerId}. {firstName} {lastName} ({phone})";
    }
    
    public string getshortString()
    {
        return $"{customerId}. {firstName} {lastName} ({phone})";
    }

    public void setFirstName(string fName)
    {
        this.firstName = fName;
    }
    
    public void setLastName(string lName)
    {
        this.lastName = lName;
    }
    
    public void setPhone(string phone)
    {
        this.phone = phone;
    }

    public string getSaveString()
    {
        return $"{this.customerId},{this.firstName},{this.lastName},{this.phone},{this.numBookings}";
    }
}