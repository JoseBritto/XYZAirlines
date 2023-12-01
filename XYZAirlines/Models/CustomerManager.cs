using System.Runtime.Serialization;

namespace XYZAirlines.Models;

public class CustomerManager
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

    public bool deleteCustomer(int id)
    {
        for (var i = 0; i < this.numCustomers; i++)
        {
            var customer = this.customers[i];
            if (customer.getCustomerId() == id)
            {
                this.customers[i] = this.customers[this.numCustomers - 1];
                this.numCustomers--;
                return true;
            }
        }
        return false;
    }
}