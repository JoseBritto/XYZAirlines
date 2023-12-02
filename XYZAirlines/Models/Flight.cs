namespace XYZAirlines.Models;

public class Flight
{
    private int flightNumber;
    private string origin;
    private string destination;
    private int maxSeats;
    private int numPassengers;
    
    public Flight(int flightNumber, string origin, string destination, int maxSeats)
    {
        this.flightNumber = flightNumber;
        this.origin = origin;
        this.destination = destination;
        this.maxSeats = maxSeats;
        this.numPassengers = 0;
    }
    
    public Flight(int flightNumber, string origin, string destination, int maxSeats, int numPassengers)
    {
        this.flightNumber = flightNumber;
        this.origin = origin;
        this.destination = destination;
        this.maxSeats = maxSeats;
        this.numPassengers = numPassengers;
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
    
    public void incrementNumPassengers()
    {
        this.numPassengers++;
    }
    public void decrementNumPassengers()
    {
        this.numPassengers--;
    }
    
    public int getNumPassengers()
    {
        return this.numPassengers;
    }
    
    public override string ToString()
    {
        return $"Flight {this.flightNumber} from {this.origin} to {this.destination} ({this.numPassengers}/{this.maxSeats} passengers)";
    }

    public void setOrigin(string origin)
    {
        this.origin = origin;
    }

    public void setDestination(string destination)
    {
        this.destination = destination;
    }

    public void setMaxSeats(int seats)
    {
        this.maxSeats = seats;
    }

    public string getSaveString()
    {
        return $"{this.flightNumber},{this.origin},{this.destination},{this.maxSeats},{this.numPassengers}";
    }
}