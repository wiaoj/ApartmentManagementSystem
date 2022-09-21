namespace Application.Handlers.Vehicles.Dtos.Queries;

public record GetAllVehicleDto {
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public String Plate { get; set; }
}