namespace Application.Handlers.PhoneNumbers.Dtos.Queries;

public record GetByUserIdPhoneNumberDto {
    public Guid Id { get; set; }
    public String CountryCode { get; set; }
    public String Number { get; set; }
}