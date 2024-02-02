using TestTest.PersonEnums;

namespace TestTest.Entities;

public class Connections
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public ConnectionEnum ConnectionType { get; set; }

    public int Person1Id { get; set; }
    public virtual Person Persons { get; set; }
}