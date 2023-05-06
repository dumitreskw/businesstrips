namespace BusinessTrips.Business.DTOs;

public record UserDTO
{
    public string Id { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public bool AccountStatus { get; set; }
    public string UserRole { get; set; }
    public bool IsEmailConfirmed { get; set; }
}
