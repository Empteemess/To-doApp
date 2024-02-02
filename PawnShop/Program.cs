using System.Diagnostics.CodeAnalysis;
using Moq;

namespace PawnShop;

class Program
{
    static void Main(string[] args)
    {
        var num1 = 12;
        var num2 = 23;
        (int sum, int average, string print) test = AddNumber(num1,num2);

        Console.WriteLine(test.print);
        Console.WriteLine($"Returned Sum is : {test.sum}");
        Console.WriteLine($"Returned Average is is : {test.average}");
    }


    public static (int,int,string) AddNumber(int num1, int num2)
    {
        var sum = num1 + num2;
        var average = (num1 + num2) / 2;
        var PrintDetails = $"Sum is {sum} , Average is {average}";

        return (sum, average, PrintDetails);
    }
}