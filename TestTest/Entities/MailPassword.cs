namespace TestTest.Entities;

public class MailPassword
{
    public int Id { get; set; }
    public string Mail { get; set; }
    public string Password { get; set; }
    
    public int PersonId { get; set; }
    public virtual Person Person { get; set; }
}