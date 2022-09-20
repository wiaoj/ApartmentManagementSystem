namespace Application.Handlers.Users.Dtos.Commands;
public record UpdatedUserDto {
    public Guid Id { get; set; }
    public String FirstName { get; set; }
    public String LastName { get; set; }
    public String IdentityNumber { get; set; }
    public String Email { get; set; }
    public Boolean IsTenant { get; set; }
    public Guid ApartmentId { get; set; }
    public String Message { get; set; }
}