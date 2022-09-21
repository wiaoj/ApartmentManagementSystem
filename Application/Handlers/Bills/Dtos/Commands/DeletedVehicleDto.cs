namespace Application.Handlers.Vehicles.Dtos.Commands;
public record DeletedVehicleDto {
    public Guid Id { get; set; }
    public String Message { get; set; }
}