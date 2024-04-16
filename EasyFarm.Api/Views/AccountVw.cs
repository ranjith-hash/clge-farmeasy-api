namespace EasyFarm.Api.Views;


public class SignInResponseVw
{
    public Guid UserId { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; }= string.Empty;
    public bool IsSeller { get; set; } = false;
}

public class SignUpVw
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; }
    public string Password { get; set; }
    public bool IsSeller { get; set; }
}

public class SignInVw
{
    public string Email { get; set; }
    public string Password { get; set; }
}


public class UserEmail
{
    public string Email { get; set; }
}