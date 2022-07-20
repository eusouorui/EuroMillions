using System;

Console.Clear();
Console.WriteLine("Developed by:\nRui Dias");

int menuOption = 0;
bool confirmExit;

while(true)
{
    #region Initialize variables

    confirmExit = false;

    #endregion 
    
    Console.WriteLine("--------------------------------\n\nWelcome to Euromillions.");

    menuOption = Menu();

    switch(menuOption)
    {
        case 1:
            Euromillions.Ticket euromillionsTicket = CreateEuroMillions();
            euromillionsTicket.PrintTicket();
            break;
        case 0:
            confirmExit = ConfirmExit();
            break;
        default:
            Console.WriteLine("Unknow menu option");
            break;
    }

    if(confirmExit)
    {
        break;
    }
    else
    {
        Console.WriteLine("\n\nPress any key to go back to the menu...");
        Console.Read();
        Console.Clear();
    }
}

Console.Clear();
Console.WriteLine("--------------------------------------------------------");
Console.WriteLine("Thank you for using Euromillions, Developed by Rui Dias.\nPress any key to leave.");
Console.ReadKey();
Console.Clear();

int Menu()
{
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

bool ConfirmExit()
{
    Console.Clear();
    Console.WriteLine("Do you really want to exit?\nWrite exit to confirm. Write any other thing to go back to menu.");
    string userInput = Console.ReadLine();
    if(string.Equals(userInput, "exit", StringComparison.OrdinalIgnoreCase))
    {
        return true;
    }
    else
    {
        return false;
    }

}

Euromillions.Ticket CreateEuroMillions()
{
    dynamic euromillionsTicket = null;

    while(true)
    {
        List<int> numbers = new List<int>();
        List<int> stars = new List<int>();
        string numberString;
        int number;
        
        while(numbers.Count < Euromillions.Ticket.NUMBERS_ALLOWED)
        {
            Console.Clear();
            Console.WriteLine("Creating new ticket\n\n");

            while(true)
            {
                Console.WriteLine("You have entered " + numbers.Count  + " out of " + Euromillions.Ticket.NUMBERS_ALLOWED +" numbers.\n\n");

                number = 0;
                numberString = string.Empty;
                Console.WriteLine("Insert a number between  " + Euromillions.Ticket.SMALLEST_NUMBER_ALLOWED + " and " + Euromillions.Ticket.HIGHEST_NUMBER_ALLOWED);
                numberString = Console.ReadLine();
                int.TryParse(numberString, out number);
                if(number <= Euromillions.Ticket.HIGHEST_NUMBER_ALLOWED && number >= Euromillions.Ticket.SMALLEST_NUMBER_ALLOWED)
                {
                    if(numbers.Contains(number))
                    {
                        Console.WriteLine("\n\nThe number " + number + " is already registered.");
                        Console.WriteLine("\nPress any key to continue...");
                        Console.ReadKey();
                    }
                    else
                    {
                        numbers.Add(number);
                        break;
                    }  
                }
            }
        }

        while(stars.Count < Euromillions.Ticket.STARS_ALLOWED)
        {
            Console.Clear();
            Console.WriteLine("Creating new ticket\n\n");
            Console.WriteLine("You have entered " + stars.Count+ " out of " + Euromillions.Ticket.STARS_ALLOWED + " numbers.\n\n");

            while(true)
            {
                number = 0;
                numberString = string.Empty;

                Console.WriteLine("Insert a star between  " + Euromillions.Ticket.SMALLEST_STARS_ALLOWED + " and " + Euromillions.Ticket.HIGHEST_STAR_ALLOWED);
                numberString = Console.ReadLine();
                int.TryParse(numberString, out number);
                if(number <= Euromillions.Ticket.HIGHEST_STAR_ALLOWED && number >= Euromillions.Ticket.SMALLEST_STARS_ALLOWED)
                {
                    if(stars.Contains(number))
                    {
                        Console.WriteLine("\n\nThe star " + number + " is already registered.");
                        Console.WriteLine("\nPress any key to continue...");
                        Console.ReadKey();
                    }
                    else
                    {
                        stars.Add(number);
                        break;
                    }          
                }
            }
        }

        if(Euromillions.Ticket.Validate(numbers, stars))
        {
            euromillionsTicket = new Euromillions.Ticket(numbers, stars);
            break;
        }

    }

    return euromillionsTicket;
}