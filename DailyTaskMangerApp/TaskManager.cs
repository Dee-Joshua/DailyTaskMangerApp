using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyTaskMangerApp
{
    internal class TaskManager
    {
        static Dictionary<DayOfWeek, List<string>> dailyTasks = new Dictionary<DayOfWeek, List<string>>();
        static Dictionary<DayOfWeek, List<string>> taskTimes = new Dictionary<DayOfWeek, List<string>>();

        public static void AddTasksForDay()
        {
            Console.WriteLine("\nSelect a day of the week:");
            Console.WriteLine("1. Sunday");
            Console.WriteLine("2. Monday");
            Console.WriteLine("3. Tuesday");
            Console.WriteLine("4. Wednesday");
            Console.WriteLine("5. Thursday");
            Console.WriteLine("6. Friday");
            Console.WriteLine("7. Saturday");
            

            string input = Console.ReadLine();

            if (int.TryParse(input, out int dayOfWeekNumber) && dayOfWeekNumber >= 1 && dayOfWeekNumber <= 7)
            {
                DayOfWeek selectedDay = (DayOfWeek)(dayOfWeekNumber - 1);

                if (selectedDay == DayOfWeek.Wednesday || selectedDay == DayOfWeek.Saturday || selectedDay == DayOfWeek.Sunday)
                {
                    Console.WriteLine("You cannot add tasks for this day.");
                }
                else
                {

                    while (true)
                    {
                        Console.WriteLine($"\nEnter tasks for {selectedDay} (Type 'done' to finish):");
                        string task = Console.ReadLine();

                        if (string.Equals(task, "done", StringComparison.OrdinalIgnoreCase))
                        {
                            break;
                        }

                        if (!dailyTasks.ContainsKey(selectedDay))
                        {
                            dailyTasks[selectedDay] = new List<string>();
                            taskTimes[selectedDay] = new List<string>();
                        }

                        Console.WriteLine($"Enter the time for '{task}' (e.g., 9:00 AM):");
                        string time = Console.ReadLine();
                        dailyTasks[selectedDay].Add(task);
                        taskTimes[selectedDay].Add(time);
                    }
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid day number.");
            }
        }

        public static void ViewTasksForDay()
        {
            Console.WriteLine("\nSelect a day of the week to view tasks:");
            Console.WriteLine("1. Sunday");
            Console.WriteLine("2. Monday");
            Console.WriteLine("3. Tuesday");
            Console.WriteLine("4. Wednesday");
            Console.WriteLine("5. Thursday");
            Console.WriteLine("6. Friday");
            Console.WriteLine("7. Saturday");

            string input = Console.ReadLine();

            if (int.TryParse(input, out int dayOfWeekNumber) && dayOfWeekNumber >= 1 && dayOfWeekNumber <= 7)
            {
                DayOfWeek selectedDay = (DayOfWeek)(dayOfWeekNumber - 1);

                if (!dailyTasks.ContainsKey(selectedDay))
                {
                    Console.WriteLine($"No tasks for {selectedDay}.");
                }
                else
                {
                    Console.WriteLine($"Tasks for {selectedDay}:");
                    for (int i = 0; i < dailyTasks[selectedDay].Count; i++)
                    {
                        string task = dailyTasks[selectedDay][i];
                        string time = taskTimes[selectedDay][i];
                        Console.WriteLine($"- {task} ({time})");
                    }
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid day number.");
            }
        }
    }
}
