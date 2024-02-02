using TestProject.Methods;

namespace TestProject;

class Program
{
    public static void Main(string[] args)
    {
        var services = new Method();

        /*
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
        */

        //services.DeleteNumberById();
        var list = new List<double>() { 123.312, 43245, 45, 432, 4, 5, 6, 1, 4, };
        var list2 = new List<double>() {9,9,9,9,9,9,9,9,9,9,9};
        
        var ss = list.CustomFindMax(x => x > 1);

        var conc = list.CustomConcatList(list2);

        foreach (var item in conc)
        {
            Console.Write($"{item} ");
        }
        
        Console.WriteLine($"\nMax number from list is {ss}");

        //instance specific
        var se = new Method();
        
        //static class specific
        
        
        

    }
}

static class  CustomMethods
{
    public static List<TSource> CustomConcatList<TSource>(this List<TSource> source, List<TSource> predicate)
    {
        foreach (var item in predicate)
        {
            source.Add(item);
        }

        return source;
    }
    
    
    public static TSource CustomFindMax<TSource>(this List<TSource> source,Func<TSource, bool> predicate)
    {
        var list = new List<TSource>();
        
        if (list != null)
        {
            foreach (var item in source)
            {
                if (predicate(item))
                {
                    list.Add(item);
                }
            }
        }
        else
        {
            throw new Exception();
        }
        return list.Max();
    }
}