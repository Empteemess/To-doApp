using Moq;

namespace PawnShop;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter a number : ");
        var input = Console.ReadLine().Trim();


        var ss = int.TryParse(input, out int outInput);

        if (ss)
        {
            Console.WriteLine(outInput);
        }
    }
}