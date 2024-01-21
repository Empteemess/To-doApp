namespace TestProject.Entities;

public class Number
{
    public int Id { get; set; }
    public int PhoneNumber { get; set; }

    public int PersonId { get; set; }
    public virtual Person Person { get; set; }
}