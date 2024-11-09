using System;

class Program
{
    static bool isRunning = true;
    static List<string> todos = [];
    static List<string> options = ["[1] - Add Todo", "[2] - Delete Todo", "[3] - List all todos", "[4] - Exit"];

    static void Main(string[] args)
    {
        ListOptions();
        StartAndGetOption();

        Console.WriteLine("Press Enter to exit...");
        Console.ReadLine();
    }

    private static void ListOptions()
    {
        foreach (var option in options)
        {
            Console.WriteLine(option);
        }
    }

    private static void StartAndGetOption()
    {
        while (isRunning)
        {
            Console.Write("Please select an option:");
            var selectedOption = Console.ReadLine();

            if (string.IsNullOrEmpty(selectedOption))
            {
                Console.WriteLine("[ERROR]Invalid option. Enter h for help.");
                continue;
            }

            NavigateOptions(selectedOption);
        }
    }

    private static void NavigateOptions(string selectedOption)
    {
        switch (selectedOption)
        {
            case "1":
                AddTodo();
                break;
            case "2":
                DeleteTodo();
                break;
            case "3":
                ListTodos();
                break;
            case "4":
                Exit();
                break;
            case "h":
                ListOptions();
                break;
            default:
                Console.WriteLine("[ERROR]Invalid option. Enter h for help.");
                break;
        }
    }

    private static void Exit()
    {
        Console.WriteLine("Goodbye!");
        isRunning = false;
    }

    private static void ListTodos()
    {
        if (todos.Count > 0)
        {
            Console.WriteLine($"You have {todos.Count} todos:");

            for (int i = 0; i < todos.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {todos[i]}");
            }
        }
        else
        {
            Console.WriteLine("[WARNING] No todos found.");
            return;
        }
    }

    private static void DeleteTodo()
    {
        Console.Write("Please enter the index of the todo you want to delete: ");
        var index = Console.ReadLine();

        if (int.TryParse(index, out int result))
        {
            if (result > 0 && result <= todos.Count)
            {
                todos.RemoveAt(result - 1);
            }
            else
            {

                Console.WriteLine("[ERROR] Invalid index, please try again.");
            }
        }
        else
        {
            Console.WriteLine("[ERROR] Invalid index, please try again.");
        }
    }

    private static void AddTodo()
    {
        Console.Write("Please enter the todo: ");
        var todo = Console.ReadLine();

        if (string.IsNullOrEmpty(todo))
        {
            Console.WriteLine("[ERROR] Todo cannot be empty.");
            return;
        }

        todos.Add(todo);
    }
}
