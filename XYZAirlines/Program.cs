using XYZAirlines.Models;
using XYZAirlines.UI;
using XYZAirlines.UI.AddCustomerScreens;
using XYZAirlines.UI.AddFlightScreens;

internal class Program
{
    public static Coordinator Coordinator;
    public static void Main(string[] args)
    {
        Coordinator = new Coordinator(10, 10, 10);
        Console.WriteLine("==================================");
        Console.WriteLine("XYZ Airlines Flight Booking System");
        Console.WriteLine("==================================");

        MenuScreen menu = BuildMenus();

        Screen screen = menu;
        while (true)
        {
            Console.Clear();
            screen = screen.show();
        }



        MenuScreen BuildMenus()
        {
            Screen addCustomerScreen = new AddCustomerScreen1();
            Screen viewCustomerScreen = new ViewCustomerScreen();
            Screen deleteCustomerScreen = new DeleteCustomerScreen();
            MenuScreen customerMenu = new MenuScreen("Customers Menu",new Option[] {
                new Option("Add Customer", addCustomerScreen),
                new Option("View Customer", viewCustomerScreen),
                new Option("Delete Customer", deleteCustomerScreen),
            });
            addCustomerScreen.setPreviousScreen(customerMenu);
            viewCustomerScreen.setPreviousScreen(customerMenu);
            deleteCustomerScreen.setPreviousScreen(customerMenu);
            
            Screen addFlightScreen = new AddFlightScreen1();
            Screen viewFlightsScreen = new ViewFlightScreen();
            Screen deleteFlightsScreen = new DeleteFlightScreen();
            MenuScreen flightMenu = new MenuScreen("Flights Menu",new Option[] {
                new Option("Add Flight", addFlightScreen),
                new Option("View Flights", viewFlightsScreen),
                new Option("Delete Flights", deleteFlightsScreen),
            });
            addFlightScreen.setPreviousScreen(flightMenu);
            viewFlightsScreen.setPreviousScreen(flightMenu);
            deleteFlightsScreen.setPreviousScreen(flightMenu);
            
            Screen bookFlightScreen = null;
            Screen viewBookingsScreen = null;
            Screen deleteBookingsScreen = null;
            MenuScreen bookingMenu = new MenuScreen("Bookings Menu",new Option[] {
                new Option("Book Flight", bookFlightScreen),
                new Option("View Bookings", viewBookingsScreen),
                new Option("Delete Bookings", deleteBookingsScreen),
            });
    
            Screen exitScreen = new ExitConfirmationScreen();
            MenuScreen mainMenu = new MenuScreen("Main Menu", new Option[] {
                new Option("Customers", customerMenu),
                new Option("Flights", flightMenu),
                new Option("Bookings", bookingMenu),
                new Option("Exit", exitScreen),
            });
    
            bookingMenu.setPreviousScreen(mainMenu);
            flightMenu.setPreviousScreen(mainMenu);
            customerMenu.setPreviousScreen(mainMenu);
            exitScreen.setPreviousScreen(mainMenu);
            mainMenu.setPreviousScreen(exitScreen);
            return mainMenu;
        }
    }
}
