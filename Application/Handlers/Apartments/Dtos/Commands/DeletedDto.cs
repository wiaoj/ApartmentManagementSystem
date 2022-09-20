namespace Application.Handlers.Apartments.Dtos.Commands;
public record DeletedDto {
    public Guid Id { get; set; }
    public String Message { get; set; }
}