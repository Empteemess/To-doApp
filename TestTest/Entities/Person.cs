using TestTest.PersonEnums;

namespace TestTest.Entities;

public class Person
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public GenderEnum Gender { get; set; }
    public string PersonIdNumber { get; set; }
    public int BirthYear { get; set; }
    public string City { get; set; }
    public PhoneTypeEnum PhoneType { get; set; }
    public string PhoneNumber { get; set; }
    public virtual ICollection<Connections> Connections { get; set; }
    public virtual MailPassword MailPassword { get; set; }
}