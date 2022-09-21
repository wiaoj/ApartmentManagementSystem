namespace Application.Handlers.Vehicles.Dtos.Queries;

public record GetByUserIdVehicleDto {
    public Guid Id { get; set; }
    public String Plate { get; set; }
}