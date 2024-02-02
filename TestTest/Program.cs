using TestTest.Entities;

namespace TestTest;

public class Program
{
    static void Main(string[] args)
    {
        var methods = new PersonServiceMethods.PersonServiceMethods();
        while (true)
        {
            Console.Write("\nEnter Login or Register : ");
            var userInput = Console.ReadLine().Trim().ToLower();
            switch (userInput)
            {
                case "login":
                    methods.Login();
                    break;
                case "register":
                    methods.Register();
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("\nWrong Input\n");
                    break;
            }
        }
    }
}