Console.Clear();
Console.WriteLine("Developed by Rui Dias");

int menuOption = 0;

while(true)
{
    Console.WriteLine("--------------------------------\n\nWelcome to Euromillions.");
    

    menuOption = Menu();

    switch(menuOption)
    {
        case 1:
            Console.WriteLine("Ticket Registration");
            break;
        case 0:
            break;
        default:
            Console.WriteLine("Unknow menu option");
            break;
    }

    Console.WriteLine("\n\nPress any key to go back to the menu...");
    Console.Read();

}

int Menu()
{
    Console.Clear();
    int counter = 0;

    Console.WriteLine("\nSelect an option:");
    Console.WriteLine(++counter + " - Register ticket");
    Console.WriteLine("0 - Exit");
    int menuOption = ReadInt(0, counter);

    return menuOption;
}

int ReadInt(int min, int max)
{
    string userInput = string.Empty;
    while(true)
    {
        Console.WriteLine("Enter a number equal or bigger than " + min + " and equal or smaller than " + max);
        int.TryParse(Console.ReadLine(), out int number);
        if(number >= min && number <= max)
        {
            return number;
        }
        Console.Clear();
    }
}
