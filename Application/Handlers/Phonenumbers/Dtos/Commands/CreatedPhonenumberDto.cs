namespace Application.Handlers.PhoneNumbers.Dtos.Commands;
public record CreatedPhoneNumberDto {
    public Guid Id { get; set; }
    public String Number { get; set; }
    public Guid UserId { get; set; }
    public String Message { get; set; }
}