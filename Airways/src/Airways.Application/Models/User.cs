namespace Airways.Application.Models;

public class User
{
    public int ID { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    Role role { get; set; }
}

enum Role
{
    admin,
    customer
}
