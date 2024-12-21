namespace Airways.Application.Models.Classs;

public class CreateCLassModel
{
    public int ID { get; set; }
    public ClassType className { get; set; }
    public string description { get; set; }
}
public class CreateClassResponceModel : BaseResponceModel { }

public enum ClassType
{
    Economy,
    Business,
    FirstClass
}
