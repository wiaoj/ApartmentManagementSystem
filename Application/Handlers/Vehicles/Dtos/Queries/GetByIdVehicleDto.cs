namespace Application.Handlers.Vehicles.Dtos.Queries;
public record GetByIdVehicleDto {
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public String Plate { get; set; }
}