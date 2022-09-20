namespace Application.Handlers.Phonenumbers.Dtos.Commands;
public record UpdatedPhoneNumberDto {
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public String CountryCode { get; set; }
    public String Number { get; set; }
    public String Message { get; set; }
}