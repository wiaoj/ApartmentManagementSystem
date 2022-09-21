namespace Application.Handlers.Vehicles.Dtos.Commands;
public record CreatedVehicleDto {
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public String Plate { get; set; }
    public String Message { get; set; }
}