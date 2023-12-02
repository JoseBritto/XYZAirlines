using System.Runtime.Serialization;

namespace XYZAirlines.Models;

public class CustomerManager : Saveable
{
    private Customer[] customers;
    private int numCustomers;
    
    private static int nextCustomerId = 1;
    
    public CustomerManager(int maxCustomers)
    {
        this.customers = new Customer[maxCustomers];
        this.numCustomers = 0;
    }

    public bool addCustomer(string fName, string lName, string phone)
    {
        if (this.numCustomers == this.customers.Length)
        {
            return false;
        }
        
        if(customerExists(fName, lName, phone))
        {
            return false;
        }
        Customer customer = new Customer(nextCustomerId, fName, lName, phone);
        this.customers[this.numCustomers] = customer;
        this.numCustomers++;
        nextCustomerId++;
        return true;
    }

    public bool customerExists(string fName, string lName, string phone)
    {
        for (var i = 0; i < this.numCustomers; i++)
        {
            var existingCustomer = this.customers[i];
            if (existingCustomer.getFirstName() == fName && existingCustomer.getLastName() == lName && existingCustomer.getPhone() == phone)
            {
                return true;
            }
        }
        return false;
    }
    
    public bool customerExists(int customerId)
    {
        return getCustomer(customerId) != null;
    }

    public Customer[] getCustomers()
    {
        Customer[] result = new Customer[this.numCustomers];
        for (var i = 0; i < this.numCustomers; i++)
        {
            result[i] = this.customers[i];
        }

        return result;
    }
    
    public int getNumCustomers()
    {
        return this.numCustomers;
    }
    
    public Customer getCustomer(int customerId)
    {
        for (var i = 0; i < this.numCustomers; i++)
        {
            var customer = this.customers[i];
            if (customer.getCustomerId() == customerId)
            {
                return customer;
            }
        }
        return null;
    }

    public bool canAddMoreCustomers()
    {
        return this.numCustomers < this.customers.Length;
    }

    public bool removeCustomer(int id)
    {
        for (var i = 0; i < this.numCustomers; i++)
        {
            var customer = this.customers[i];
            if (customer.getCustomerId() == id)
            {
                if(customer.getNumBookings() > 0)
                    return false;
                this.customers[i] = this.customers[this.numCustomers - 1];
                this.numCustomers--;
                return true;
            }
        }
        return false;
    }

    public bool updateCustomer(int customerId, string fName, string lName, string phone)
    {
        Customer customer = getCustomer(customerId);
        if (customer == null)
            return false;
        customer.setFirstName(fName);
        customer.setLastName(lName);
        customer.setPhone(phone);
        return true;
    }

    public string getSaveString()
    {
        string result = $"{nextCustomerId}\n";
        for (var i = 0; i < this.numCustomers; i++)
        {
            var customer = this.customers[i];
            result += customer.getSaveString() + "\n";
        }
        return result;
    }

    public bool loadSaveString(string saveString, Flight[] existingFlights, Customer[] existingCustomers)
    {
        string[] lines = saveString.Split("\n");
        nextCustomerId = int.Parse(lines[0]);
        foreach (var line in lines.Skip(1))
        {
            if (line == "")
                continue;
            string[] parts = line.Split(",");
            int customerId = int.Parse(parts[0]);
            string fName = parts[1];
            string lName = parts[2];
            string phone = parts[3];
            int numBookings = int.Parse(parts[4]);
            Customer customer = new Customer(customerId, fName, lName, phone, numBookings);
            this.customers[numCustomers] = customer;
            this.numCustomers++;
        }
        return true;
    }

    public string getSaveIdentifier()
    {
        return "customers";
    }
}