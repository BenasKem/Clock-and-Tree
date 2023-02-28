using Clock_Tree;

Clock clock = new Clock();

Console.WriteLine("Enter clock hours: ");
clock.Hours = GetValidNumber(Clock.MIN_HOURS, Clock.MAX_HOURS);
Console.WriteLine("Enter clock minutes: ");
clock.Minutes = GetValidNumber(Clock.MIN_MINUTES, Clock.MAX_MINUTES);

clock.CalculateLesserAngleBetweenArrows();
Console.WriteLine("The lesser angle between the clock arrows is " + clock.AngleBetweenArrows); 


bool isNumber(string? input, out int number)
{
    if(!int.TryParse(input, out number))
    {
        Console.WriteLine("Please enter a valid integer number.");
        return false;
    }
    return true;
}

bool isNumberInBetween(int number, int lower_boundary, int upper_boundary)
{
    if (number <= upper_boundary && number >= lower_boundary)
        return true;
    
    Console.WriteLine($"Please enter a number between {lower_boundary} and {upper_boundary}.");
    return false;
    
}

int GetValidNumber(int lower_boundary, int upper_boundary)
{
    bool valid_number = false;
    int number = 0;
    do
    {
        string? user_input = Console.ReadLine();

        valid_number = isNumber(user_input, out number) && isNumberInBetween(number, lower_boundary, upper_boundary);


    } while (!valid_number);

    return number;
}