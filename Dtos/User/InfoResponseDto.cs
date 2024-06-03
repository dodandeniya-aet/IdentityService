namespace AuthService.Dtos;

public class InfoResponseDto
{
    public string Email { get; set; }
    public bool IsEmailConfirmed { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
}
   