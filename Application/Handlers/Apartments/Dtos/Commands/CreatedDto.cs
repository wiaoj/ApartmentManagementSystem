namespace Application.Handlers.Apartments.Dtos.Commands;
public record CreatedDto {
    public Guid Id { get; set; }
    public String Message { get; set; }
}