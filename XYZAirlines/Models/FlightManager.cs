namespace XYZAirlines.Models;

public class FlightManager : Saveable
{
    
    private Flight[] flights;
    private int numFlights;
    
    public FlightManager(int maxFlights)
    {
        this.flights = new Flight[maxFlights];
        this.numFlights = 0;
    }
    
    public bool flightExists(int flightNumber)
    {
        for (var i = 0; i < this.numFlights; i++)
        {
            var flight = this.flights[i];
            if (flight.getFlightNumber() == flightNumber)
            {
                return true;
            }
        }
        return false;
    }
    
    public bool createFlight(int flightNum, string origin, string destination, int maxSeats)
    {
        if (numFlights == flights.Length)
        {
            return false;
        }
        
        if(flightExists(flightNum))
        {
            return false;
        }
        
        Flight flight = new Flight(flightNum, origin, destination, maxSeats);
        this.flights[this.numFlights] = flight;
        this.numFlights++;
        return true;
    }
    
    public Flight[] getFlights()
    {
        var result = new Flight[this.numFlights];
        for (var i = 0; i < this.numFlights; i++)
        {
            result[i] = this.flights[i];
        }

        return result;
    }
    
    public Flight getFlight(int flightNumber)
    {
        for (var i = 0; i < this.numFlights; i++)
        {
            var flight = this.flights[i];
            if (flight.getFlightNumber() == flightNumber)
            {
                return flight;
            }
        }
        return null;
    }
    
    public bool removeFlight(int flightNumber)
    {
        for (var i = 0; i < this.numFlights; i++)
        {
            var flight = this.flights[i];
            if(flight.getNumPassengers() > 0)
                return false;
            if (flight.getFlightNumber() == flightNumber)
            {
                if(flight.getNumPassengers() != 0)
                {
                    return false;
                }
                this.flights[i] = this.flights[this.numFlights - 1];
                this.flights[this.numFlights - 1] = null;
                this.numFlights--;
                return true;
            }
        }
        return false;
    }
    
    public override string ToString()
    {
        string result = "";
        for (var i = 0; i < this.numFlights; i++)
        {
            var flight = this.flights[i];
            result += $"{flight}\n";
        }
        return result;
    }

    public bool hasPassengers(int flightNumber)
    {
        var flight = getFlight(flightNumber);
        return flight.getNumPassengers() != 0;
    }

    public bool flightHasPassengers(int flightNumber)
    {
        var flight = getFlight(flightNumber);
        return flight.getNumPassengers() != 0;
    }
    
    public bool flightHasAvailableSeats(int flightNumber)
    {
        var flight = getFlight(flightNumber);
        return flight.getNumPassengers() < flight.getMaxSeats();
    }
    
    public bool canAddMoreFlights()
    {
        return this.numFlights < this.flights.Length;
    }

    public bool updateFlight(int flightNumber, string origin, string destination, int maxSeats)
    {
        var flight = getFlight(flightNumber);
        if(flight == null)
            return false;
        flight.setOrigin(origin);
        flight.setDestination(destination);
        flight.setMaxSeats(maxSeats);
        return true;
    }

    public string getSaveString()
    {
        string result = "";
        for (var i = 0; i < this.numFlights; i++)
        {
            var flight = this.flights[i];
            result += flight.getSaveString() + "\n";
        }
        return result;
    }
    
    public bool loadSaveString(string saveString, Flight[] existingFlights, Customer[] existingCustomers)
    {
        var lines = saveString.Split("\n");
        foreach (var line in lines)
        {
            if (line == "")
                continue;
            var values = line.Split(",");
            var flightNumber = int.Parse(values[0]);
            var origin = values[1];
            var destination = values[2];
            var maxSeats = int.Parse(values[3]);
            var numPassengers = int.Parse(values[4]);
            var flight = new Flight(flightNumber, origin, destination, maxSeats, numPassengers);
            this.flights[this.numFlights] = flight;
            this.numFlights++;
        }
        return true;
    }

    public string getSaveIdentifier()
    {
        return "flights";
    }
}