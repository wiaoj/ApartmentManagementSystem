namespace Application.Handlers.Phonenumbers.Dtos.Commands;
public record UpdatedPhoneNumberDto {
    public Guid Id { get; set; }
    public String Message { get; set; }
}