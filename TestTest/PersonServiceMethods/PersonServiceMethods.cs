using System.Runtime.InteropServices.JavaScript;
using System.Text.RegularExpressions;
using System.Threading.Channels;
using Microsoft.Win32.SafeHandles;
using TestTest.Entities;
using TestTest.PersonEnums;

namespace TestTest.PersonServiceMethods;

public class PersonServiceMethods
{
    public MyDbContext Context;

    public PersonServiceMethods()
    {
        Context = new MyDbContext();
    }

    public void Login()
    {
        Console.Clear();
        Console.Write("Enter UserName or Mail : ");
        var mailInput = Console.ReadLine();

        Console.Write("Enter Password : ");
        var passwordInput = Console.ReadLine();

        var checkPerson = Context.Person.FirstOrDefault(x =>
            x.MailPassword.Mail == mailInput && x.MailPassword.Password == passwordInput);

        if (checkPerson != null)
        {
            while (true)
            {
                Console.Write("Enter <Connection> <Edit> <Show> <Search> <RemoveAccount> or <LogOut> : ");
                var userInputBeforeUpper = Console.ReadLine().Trim().ToLower();
                var userInput =
                    userInputBeforeUpper.Replace(userInputBeforeUpper[0], char.ToUpper(userInputBeforeUpper[0]));
                switch (userInput)
                {
                    case nameof(LoginEnums.Connection):
                        AddOrRemoveConnection(checkPerson);
                        break;
                    case nameof(LoginEnums.Edit):
                        EditPersonInfos(checkPerson);
                        break;
                    case nameof(LoginEnums.Removeaccount):
                        RemoveAccount(checkPerson);
                        break;
                    case nameof(LoginEnums.Show):
                        PrintDetails(checkPerson);
                        break;
                    case nameof(LoginEnums.Search):
                        SearchByInput();
                        break;
                    case nameof(LoginEnums.Logout):
                        return;
                    default:
                        Console.WriteLine("\nWrong Input\n");
                        return;
                }
            }
        }
        else
        {
            Console.WriteLine("\nYou Can't Enter\n");
        }
    }
    public void Register()
    {
        Console.WriteLine("\nRegister\n");
        try
        {
            var pattern = @"^(?=.*[A-Z])(?=.*\d).{8,}$";
            var regex = new Regex(pattern);

            Console.Write("Enter UserName or Mail : ");
            var userNameInput = Console.ReadLine();

            Console.Write("Enter Password : ");
            var passwordInput = Console.ReadLine();

            var mailCheck = Context.MailPassword.Any(x => x.Mail == userNameInput);

            if (regex.IsMatch(passwordInput) && !mailCheck)
            {
                Console.Write("Enter FirstName : ");
                var nameInput = Console.ReadLine().Trim();

                Console.Write("Enter lastName : ");
                var lastNameInput = Console.ReadLine().Trim();

                Console.Write("Enter Gender : ");
                var genderInput = GenderCheck(Console.ReadLine().Trim());

                Console.Write("Enter ID : ");
                var personIdInput = Console.ReadLine().Trim();

                Console.Write("Enter Date Of Birth : ");
                var birthInput = int.Parse(Console.ReadLine().Trim());

                Console.Write("Enter City : ");
                var cityInput = Console.ReadLine().Trim();

                Console.Write("Enter PhoneType : ");
                var phoneTypeInput = PhoneTypeCheck(Console.ReadLine().Trim());

                Console.Write("Enter PhoneNumber : ");
                var phoneNumberInput = Console.ReadLine().Trim();


                if (nameInput != string.Empty && lastNameInput != string.Empty && genderInput != null &&
                    personIdInput != string.Empty
                    && birthInput != null && cityInput != string.Empty && phoneTypeInput != null)
                {
                    var person = new Person()
                    {
                        FirstName = nameInput,
                        LastName = lastNameInput,
                        Gender = genderInput,
                        PersonIdNumber = personIdInput,
                        BirthYear = birthInput,
                        City = cityInput,
                        PhoneType = phoneTypeInput,
                        PhoneNumber = phoneNumberInput,
                        MailPassword = new MailPassword()
                        {
                            Mail = userNameInput,
                            Password = passwordInput
                        }
                    };
                    Context.Person.Add(person);
                    Context.SaveChanges();
                    Console.WriteLine("\nPerson Added....\n");
                }
                else
                {
                    Console.WriteLine("U must fill info....");
                }
            }
            else
            {
                Console.WriteLine("\nEmail or Password is incorrect..\n");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"{e.Message} / Try Again...");
        }
    }
    public void AddOrRemoveConnection(Person person)
    {
        Console.Write("Add or Remove Connection : ");
        var userInput = Console.ReadLine().Trim().ToLower();

        switch (userInput)
        {
            case "add":
                AddConnectPerson(person);
                break;
            case "remove":
                RemoveConnectPerson(person);
                break;
            default:
                Console.WriteLine("\nWrong Input\n");
                return;
        }
    }
    
    private void SearchByInput()
    {
        Console.Clear();
        Console.Write("\nSearch By Name , LastName or Id : ");
        var searchInput = Console.ReadLine();

        var selectedPersons = Context.Person.Where(x => x.FirstName.Contains(searchInput) ||
                                                        x.LastName.Contains(searchInput) ||
                                                        x.PersonIdNumber.Contains(searchInput));
        var i = 1;
        foreach (var item in selectedPersons)
        {
            Console.WriteLine(
                $"{i}.\n" +
                $"FirstName : {item.FirstName}\n" +
                $"LastName : {item.LastName}\n" +
                $"Gender : {item.Gender}\n" +
                $"ID : {item.PersonIdNumber}\n" +
                $"BirthYear : {item.BirthYear}\n" +
                $"City : {item.City}\n" +
                $"PhoneNumber : {item.PhoneNumber}\n" +
                $"PhoneType : {item.PhoneType}\n");
            i++;
        }
    }
    private void PrintDetails(Person person)
    {
        Console.WriteLine("\nCurrent Person Info..\n");
        Console.WriteLine(
            $"FirstName : {person.FirstName}\n" +
            $"LastName : {person.LastName}\n" +
            $"Gender : {person.Gender}\n" +
            $"ID : {person.PersonIdNumber}\n" +
            $"BirthYear : {person.BirthYear}\n" +
            $"City : {person.City}\n" +
            $"PhoneNumber : {person.PhoneNumber}\n" +
            $"PhoneType : {person.PhoneType}\n");

        Console.WriteLine("Connections");
        var personConnectionInfo = person.Connections;

        var i = 1;
        foreach (var item in personConnectionInfo)
        {
            Console.WriteLine($"{i}.{item.FirstName} {item.LastName} -- {item.ConnectionType}");
            i++;
        }
    }
    private void RemoveAccount(Person person)
    {
        Console.Write("User will be delete Y/N : ");
        var userInput = Console.ReadLine().Trim().ToLower();

        switch (userInput)
        {
            case "y":
                Context.Person.Remove(person);
                Context.SaveChanges();
                Console.WriteLine("\nAccount Removed Successfully...\n");
                break;
            case "n":
                return;
            default:
                Console.WriteLine("Wrong input....");
                return;
        }
    }
    private void RemoveConnectPerson(Person person)
    {
        Console.Clear();
        Console.WriteLine("\nPersons...");
        foreach (var item in person.Connections)
        {
            if (person.Id != item.Id)
            {
                Console.WriteLine($"(ID : {item.Id}) {item.FirstName} {item.LastName}");
            }
            else
            {
                continue;
            }
        }

        Console.Write("\nChose Person ID to Remove as Connection : ");
        var personIdInput = int.Parse(Console.ReadLine());

        var removeConnection = person.Connections.FirstOrDefault(x => x.Id == personIdInput);
        person.Connections.Remove(removeConnection);
        Context.SaveChanges();
    }
    private void AddConnectPerson(Person person)
    {
        PrintShortPersonInfo(person);
        Console.Write("How many connection do you want : ");
        var quantityInput = int.Parse(Console.ReadLine());

        for (var i = 0; i < quantityInput; i++)
        {
            Console.Clear();
            PrintShortPersonInfo(person);
            Console.Write("\nChose Person ID to add as Connection : ");
            var personIdInput = int.Parse(Console.ReadLine());

            var chosedPerson = Context.Person.FirstOrDefault(x => x.Id == personIdInput);

            Console.Write("Enter connection Type <Relative> or <Collegue> : ");
            var connectionInput = ConnectionCheck(Console.ReadLine());

            var addedPerson = new Person()
            {
                Connections = new List<Connections>()
                {
                    new Connections()
                    {
                        FirstName = chosedPerson.FirstName,
                        LastName = chosedPerson.LastName,
                        ConnectionType = connectionInput,
                    }
                }
            };

            foreach (var item in addedPerson.Connections)
            {
                person.Connections.Add(item);
            }

            Context.SaveChanges();
        }

        Console.WriteLine("\nConnection Added...\n");
    }
    private void EditPersonInfos(Person person)
    {
        Console.WriteLine("\nEdit Person Infos....");
        Console.Write("Enter <FirstName> <LastName> <Gender> <Id> <BirthYear> <City> or <PhoneNumber> : ");
        var userInputBeforeUpper = Console.ReadLine().ToLower().Trim();
        var userInput = userInputBeforeUpper.Replace(userInputBeforeUpper[0], char.ToUpper(userInputBeforeUpper[0]));

        switch (userInput)
        {
            case nameof(EditPersonEnums.FirstName):
                EditFirstName(person);
                Console.WriteLine("\nFirstName edited successfully..\n");
                break;
            case nameof(EditPersonEnums.LastName):
                EditLastName(person);
                Console.WriteLine("\nLastName edited successfully..\n");
                break;
            case nameof(EditPersonEnums.Gender):
                EditGender(person);
                Console.WriteLine("\nGender edited successfully..\n");
                break;
            case nameof(EditPersonEnums.Id):
                EditId(person);
                Console.WriteLine("\nId edited successfully..\n");
                break;
            case nameof(EditPersonEnums.BirthYear):
                EditBirthYear(person);
                Console.WriteLine("\nBirthYear edited successfully..\n");
                break;
            case nameof(EditPersonEnums.City):
                EditCity(person);
                Console.WriteLine("\nCity edited successfully..\n");
                break;
            case nameof(EditPersonEnums.PhoneNumber):
                EditPhoneNumber(person);
                Console.WriteLine("\nPhoneNumber edited successfully..\n");
                break;
        }
    }
    private void EditFirstName(Person person)
    {
        Console.Write("Enter new FirstName : ");
        var newFirstNameInput = Console.ReadLine();

        person.FirstName = newFirstNameInput;
        Context.SaveChanges();
    }
    private void EditLastName(Person person)
    {
        Console.Write("Enter new LastName : ");
        var newLastNameInput = Console.ReadLine();

        person.LastName = newLastNameInput;
        Context.SaveChanges();
    }
    private void EditGender(Person person)
    {
        Console.Write("Enter new Gender : ");
        var newGenderInput = GenderCheck(Console.ReadLine());

        person.Gender = newGenderInput;
        Context.SaveChanges();
    }
    private void EditId(Person person)
    {
        Console.Write("Enter new ID : ");
        var newIdInput = Console.ReadLine();

        person.PersonIdNumber = newIdInput;
        Context.SaveChanges();
    }
    private void EditBirthYear(Person person)
    {
        Console.Write("Enter new BirtYear : ");
        var newBirthYearInput = int.Parse(Console.ReadLine());

        person.BirthYear = newBirthYearInput;
        Context.SaveChanges();
    }
    private void EditCity(Person person)
    {
        Console.Write("Enter new City : ");
        var newCityInput = Console.ReadLine();

        person.City = newCityInput;
        Context.SaveChanges();
    }
    private void EditPhoneNumber(Person person)
    {
        Console.Write("Enter new PhoneNumber : ");
        var newPhoneNumber = Console.ReadLine();

        person.PhoneNumber = newPhoneNumber;
        Context.SaveChanges();
    }
    private void PrintShortPersonInfo(Person person)
    {
        Console.Clear();
        var persons = Context.Person;

        Console.WriteLine("\nPersons...");
        foreach (var item in persons)
        {
            if (person.Id != item.Id)
            {
                Console.WriteLine($"(ID : {item.Id}) {item.FirstName} {item.LastName}");
            }
            else
            {
                continue;
            }
        }
    }
    private GenderEnum GenderCheck(string gender)
    {
        switch (gender)
        {
            case nameof(GenderEnum.Female):
                return GenderEnum.Female;
            case nameof(GenderEnum.Male):
                return GenderEnum.Male;
            default:
                return GenderEnum.Male;
        }
    }
    private PhoneTypeEnum PhoneTypeCheck(string phoneNum)
    {
        switch (phoneNum)
        {
            case nameof(PhoneTypeEnum.Home):
                return PhoneTypeEnum.Home;
            case nameof(PhoneTypeEnum.Mobile):
                return PhoneTypeEnum.Mobile;
            case nameof(PhoneTypeEnum.Office):
                return PhoneTypeEnum.Office;
            default:
                return PhoneTypeEnum.Mobile;
        }
    }
    private ConnectionEnum ConnectionCheck(string connection)
    {
        switch (connection)
        {
            case nameof(ConnectionEnum.Collegue):
                return ConnectionEnum.Collegue;
            case nameof(ConnectionEnum.Relative):
                return ConnectionEnum.Relative;
            default:
                return ConnectionEnum.Etc;
        }
    }
}