namespace Airways.Application.Models;

public class CLass
{
    public int ID { get; set; }
    public ClassType className { get; set; }
    public string description { get; set; }
}

public enum ClassType
{
    Economy,
    Business,
    FirstClass
}
