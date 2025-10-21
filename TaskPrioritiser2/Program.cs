using Priority;

namespace Priority
{
    public enum TaskPriority
        {
            Low,
            Medium,
            High,
            Critical
    }
}

class Task
{
    private int id;
    private string description;
    private DateTime deadline;
    private TaskPriority priority;
    private bool status;

    public Task(int id, string description, DateTime deadline, TaskPriority priority, bool status)
    {
        this.id = id;
        this.description = description;
        this.deadline = deadline;
        this.priority = priority;
        this.status = false; // Default status is incomplete
    }

    public int getId() { return this.id; }
    public string getDescription() { return this.description; }
    public DateTime getDeadline() { return this.deadline; }
    public TaskPriority getPriority() { return this.priority; }
    public bool getStatus() { return this.status; }

    public void changeStatus()
    {
        this.status = !status;
    }

    override public string ToString()
    {
        return $"Task {id}: {this.description}, Deadline: {this.deadline.ToShortDateString()}, Priority: {this.priority}, Status: {(this.status ? "Complete" : "Incomplete")}";
    }

}



class Program
{

    static Task CreateTask(int id_count)
    {
        Console.WriteLine("Creating a new task...");
        Console.WriteLine("Enter task description:");
        string description = Console.ReadLine();
        Console.WriteLine("Enter task deadline (yyyy-mm-dd):");
        DateTime deadline = DateTime.Parse(Console.ReadLine());
        Console.WriteLine("Enter task priority (Low, Medium, High, Critical):");
        TaskPriority priority = (TaskPriority)Enum.Parse(typeof(TaskPriority), Console.ReadLine(), true);
        return new Task(id_count + 1, description, deadline, priority, false);
    }
    static void Main(string[] args)
    {
        List<Task> tasks = new List<Task>();
        bool exit_choice = false;
        while (!exit_choice)
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Welcome to the Task Prioritiser!");
                Console.WriteLine("Choose an option:\n[1] View your tasks\n[2] Create a task\n[3] Mark a task complete/incomplete\n[4] Close");
                int choice = Convert.ToInt16(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Your Tasks:");
                        foreach (var task in tasks)
                        {
                            if (!task.getStatus())
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                            }

                            Console.WriteLine(task);
                        }
                        Console.ReadLine();
                        Console.ResetColor();
                        break;
                    case 2:
                        if (tasks.Count == 0)
                        {
                            tasks.Add(CreateTask(0));
                            Console.WriteLine("Task created successfully!");
                            break;
                        }
                        tasks.Add(CreateTask(tasks[tasks.Count - 1].getId()));
                        Console.WriteLine("Task created successfully!");
                        break;
                    case 3:
                        Console.WriteLine("Enter the task number to mark as complete:");
                        int i = 0;
                        foreach (var task in tasks)
                        {
                            i++;
                            Console.WriteLine($"[{i}] {task}");
                        }
                        int taskNumber = Convert.ToInt16(Console.ReadLine());
                        if (taskNumber > 0 && taskNumber <= tasks.Count)
                        {
                            tasks[taskNumber - 1].changeStatus();
                            Console.WriteLine("Task status updated successfully!");
                        }
                        else
                        {
                            Console.WriteLine("Invalid task number.");
                        }
                        break;
                    case 4:
                        exit_choice = true;
                        Console.WriteLine("Exiting Task Prioritiser. Goodbye!");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid choice. Please try again.");
            }
        }

    }
}