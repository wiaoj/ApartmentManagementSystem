namespace Application.Handlers.Phonenumbers.Dtos.Commands;
public record DeletedPhoneNumberDto {
    public Guid Id { get; set; }
    public String Message { get; set; }
}