namespace XYZAirlines.Models;

public interface Saveable
{
    public string getSaveString();
    
    public bool loadSaveString(string saveString, Flight[] existingFlights, Customer[] existingCustomers);
    
    public string getSaveIdentifier();
}