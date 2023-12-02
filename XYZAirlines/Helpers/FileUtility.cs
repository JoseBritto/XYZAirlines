using XYZAirlines.Models;

namespace XYZAirlines.Helpers;

public static class FileUtility
{
    public static void save(Saveable data)
    {
        try
        {
            string fileName = data.getSaveIdentifier() + ".txt";
            string saveString = data.getSaveString();
            File.WriteAllText(fileName, saveString);
        }
        catch
        {
            Console.WriteLine($"Error saving {data.getSaveIdentifier()}");
            Console.Beep();
        }
    }
    
    public static bool loadData(Saveable obj, Flight[] existingFlights, Customer[] existingCustomers)
    {
        try
        {
            string fileName = obj.getSaveIdentifier() + ".txt";
            if (!File.Exists(fileName))
                return true; // No data to load
            string saveString = File.ReadAllText(fileName);
            return obj.loadSaveString(saveString, existingFlights, existingCustomers);

        }
        catch
        {
            Console.WriteLine($"Error loading {obj.getSaveIdentifier()}");
            Console.Beep();
            return false;
        }
    }
}