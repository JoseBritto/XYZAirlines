namespace XYZAirlines.UI.AddCustomerScreens;

public abstract class AddCustomerScreen : TextInputScreen
{
    protected AddCustomerScreen() : base("Add Customer")
    {
    }

    protected override string getCancelMessage()
    {
        return "Customer creation cancelled";
    }
}