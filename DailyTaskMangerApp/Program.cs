using static DailyTaskMangerApp.TaskManager;

Console.ForegroundColor = ConsoleColor.Yellow;
Console.WriteLine("--------------------------------------------------");
Console.WriteLine("|            Daily Task Planner                  |");
Console.WriteLine("|         Organize Your Week with Ease!          |");
Console.WriteLine("--------------------------------------------------");
Console.ResetColor();



Dictionary<DayOfWeek, List<string>> dailyTasks = new Dictionary<DayOfWeek, List<string>>();

while (true)
{
    Console.WriteLine("\nSelect an option:");
    Console.WriteLine("1. Add tasks for a day");
    Console.WriteLine("2. View tasks for a day");
    Console.WriteLine("3. Exit\n");

    string input = Console.ReadLine();

    if (int.TryParse(input, out int option))
    {
        switch (option)
        {
            case 1:
                AddTasksForDay();
                break;
            case 2:
                ViewTasksForDay();
                break;
            case 3:
                return;
            default:
                Console.WriteLine("Invalid option. Please select a valid option.");
                break;
        }
    }
    else
    {
        Console.WriteLine("Invalid input. Please enter a valid option number.");
    }
}

