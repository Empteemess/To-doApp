using TestProject.Methods;

namespace TestProject;

class Program
{
    public static void Main(string[] args)
    {
        var services = new Method();

        Console.Write("Enter Add Show or End : ");
        var userInput = Console.ReadLine().Trim().ToLower();

        while (true)
        {
            switch (userInput)
            {
                case "add":
                    services.AddPerson();
                    break;
                case "show":
                    services.GetNumberByName();
                    break;
                case "end":
                    return;
                default:
                    Console.WriteLine("Try again");
                    return;
            }
        }
    }
}