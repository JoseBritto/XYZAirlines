using XYZAirlines.Helpers;

namespace XYZAirlines.UI;

public class MenuScreen : Screen
{
    protected Option[] options;
    private int selectedOptionIndex;
    
    public MenuScreen(string title, Option[] options) : base(title)
    {
        this.options = options;
        selectedOptionIndex = 0;
    }
    

    public override void displayBody()
    {
        for (var i = 0; i < this.options.Length; i++)
        {
            var option = this.options[i];
            if (i == selectedOptionIndex)
            {
                Console.Write("> ");
            }
            else
            {
                Console.Write("  ");
            }
            Console.WriteLine($"{i + 1}. {option.getDisplayText()}");
        }

    }

    public override void displayInputPrompt()
    {
        Console.WriteLine();
        Console.WriteLine("[Enter] to select an option");
        Console.WriteLine("[Up] and [Down] or [1-9] to navigate");
        Console.WriteLine("[Esc] or [Backspace] to go back");
    }
    

    public override string getInput()
    {
        var input = Console.ReadKey(true);
        
        switch (input.Key)
        {
            case ConsoleKey.Backspace: 
            case ConsoleKey.Escape: 
                return BACK;
            case ConsoleKey.Enter:
                return ENTER;
            case ConsoleKey.UpArrow:
                return UP;
            case ConsoleKey.DownArrow:
                return DOWN;
        }
        if(input.KeyChar >= '0' && input.KeyChar <= '9')
        {
            return input.KeyChar.ToString();
        }
        return INVALID;
    }
    

    public override Screen handleInput(string input)
    {
        switch (input)
        {
            case ENTER:
                return executeOption(options[selectedOptionIndex]);
            case UP:
                if (selectedOptionIndex > 0)
                {
                    selectedOptionIndex--;
                    return this;
                }
                handleInputError();
                return this;
            case DOWN:
                if (selectedOptionIndex < options.Length - 1)
                {
                    selectedOptionIndex++;
                    return this;
                }
                handleInputError();
                return this;
            case BACK:
                return goBack();
            case INVALID:
                handleInputError();
                return this;
        }

        if (!int.TryParse(input, out int number))
        {
            handleInputError();
            return this;
        }
        if (number <= 0 || number > options.Length)
        {
            handleInputError();
            return this;
        }
        selectedOptionIndex = number - 1;
        return executeOption(options[selectedOptionIndex]);
    }

    protected virtual Screen executeOption(Option option)
    {
        return option.getScreen();
    }

    private void handleInputError()
    {
        Console.Beep();
    }
}