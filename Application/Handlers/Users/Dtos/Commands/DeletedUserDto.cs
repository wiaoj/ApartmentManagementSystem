namespace Application.Handlers.Users.Dtos.Commands;
public record DeletedUserDto {
    public Guid Id { get; set; }
    public String Message { get; set; }
}