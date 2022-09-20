namespace Application.Handlers.Apartments.Dtos.Commands;
public record UpdatedDto {
    public Guid Id { get; set; }
    public String Message { get; set; }
}