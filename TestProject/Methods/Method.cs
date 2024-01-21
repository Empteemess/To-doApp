using TestProject.Entities;

namespace TestProject.Methods;

public class Method
{
    private MyDbContext context = new MyDbContext();

    public void GetNumberByName()
    {
        Console.Write("Enter firstName : ");
        var firstNameInput = Console.ReadLine();

        Console.Write("Enter lastName : ");
        var lastNameInput = Console.ReadLine();

        var personsPhoneNumber = 0;

        var PersonInfo =
            context.Person.FirstOrDefault(x =>
                x.FirstName.Contains(firstNameInput) && x.LastName.Contains(lastNameInput));

        foreach (var item in PersonInfo.Number)
        {
            personsPhoneNumber = item.PhoneNumber;
            Console.WriteLine($"{firstNameInput} {lastNameInput}'s phone number is : {personsPhoneNumber}");
        }
    }

    public void AddPerson()
    {
        Console.Write("Enter firstName : ");
        var fir = Console.ReadLine();

        Console.Write("Enter lastName : ");
        var las = Console.ReadLine();

        var person = new Person()
        {
            FirstName = fir,
            LastName = las,
            Number = new List<Number>()
        };

        var context = new MyDbContext();

        Console.Write("Enter add or end : ");
        var ss = Console.ReadLine();

        switch (ss)
        {
            case "add":
                Console.Write("Enter numberquantity : ");
                var inputNum = int.Parse(Console.ReadLine());
                while (inputNum > 0)
                {
                    Console.Write("Enter PhoneNumber : ");
                    var phoneNumm = int.Parse(Console.ReadLine());

                    var num1 = new Number() { PhoneNumber = phoneNumm };
                    person?.Number.Add(num1);
                    inputNum--;
                }

                context.Person.Add(person);
                context.SaveChanges();
                Console.WriteLine($"{fir} {las} Added...");
                break;
            case "end":
                return;
        }
    }
}