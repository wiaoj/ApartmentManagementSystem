namespace Application.Handlers.PhoneNumbers.Dtos.Queries;

public record GetAllPhoneNumberDto {
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public String CountryCode { get; set; }
    public String Number { get; set; }
}