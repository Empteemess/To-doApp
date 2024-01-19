namespace Test;

class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        GetName();
        Console.WriteLine("Hello");
        Console.WriteLine("Hello");
    }

    public static void GetName()
    {
        Console.Write("Enter a name : ");
        var input = Console.ReadLine();
        
        switch (input)
        {
          case  "gio":
              
              Console.WriteLine("bazadze");
          break;
          case "kaladze":
              Console.WriteLine("Nadziralaaaaaa");
              break;
        }
    }
}