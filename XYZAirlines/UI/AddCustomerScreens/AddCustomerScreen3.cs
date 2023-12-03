using System.Text.RegularExpressions;

namespace XYZAirlines.UI.AddCustomerScreens;

public class AddCustomerScreen3 : AddCustomerScreen
{
    private string firstName;
    private string lastName;
    public AddCustomerScreen3(string firstName, string lastName, Screen previousScreen) : base()
    {
        this.firstName = firstName;
        this.lastName = lastName;
        this.previousScreen = previousScreen;
    }

    public override void displayBody()
    {
        Console.WriteLine("Add a new customer");
        Console.WriteLine($"First Name: {firstName}");
        Console.WriteLine($"Last Name: {lastName}");
    }

    public override void displayInputPrompt()
    {
        Console.Write("Enter customer phone number: ");
    }

    public override string getInput()
    {
        var input = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(input))
        {
            return INVALID;
        }
        input = input.Trim();
        
        if(base.handleNavigationInput(input) != null)
        {
            return base.handleNavigationInput(input);
        }
        
        var regex = new Regex(@"^(\+)?(\d{1,2})?(\s)?((\(\d{3}\))|(\d{3}))(\s|-)?(\d{3})(\s|-)?(\d{4})$");
        if (!regex.IsMatch(input))
        {
            return INVALID;
        }
        input = normalizePhoneNumber(input);
        return input;
    }

    private string normalizePhoneNumber(string input)
    {
        var regex = new Regex(@"^(\+)?(\d{1,2})?(\s)?((\(\d{3}\))|(\d{3}))(\s|-)?(\d{3})(\s|-)?(\d{4})$");
        var match = regex.Match(input);
        var countryCode = match.Groups[2].Value;
        var areaCode = match.Groups[4].Value;
        var three = match.Groups[8].Value;
        var four = match.Groups[10].Value;
        if(countryCode == "")
        {
            countryCode = "1"; // Assume customer is canadian or american
        }
        var normalized = $"+{countryCode} {areaCode} {three} {four}";
        return normalized;
    }

    public override Screen handleInput(string input)
    {
        if(input == INVALID)
        {
            setErrorMessage("Invalid phone number");
            return this;
        }
        if(base.handleInput(input) != null)
        {
            return base.handleInput(input);
        }
        var phoneNumber = input;
        return new AddCustomerScreen4(firstName, lastName, phoneNumber, previousScreen);
    }
}