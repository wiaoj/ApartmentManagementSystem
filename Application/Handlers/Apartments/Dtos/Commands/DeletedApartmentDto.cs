namespace Application.Handlers.Apartments.Dtos.Commands;
public record DeletedApartmentDto {
    public Guid Id { get; set; }
    public String Message { get; set; }
}