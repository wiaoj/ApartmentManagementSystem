using Application.Handlers.Vehicles.Dtos.Queries;

namespace Application.Handlers.Users.Dtos.Queries;
public record GetByIdUserDto {
    public Guid Id { get; set; }
    public String FirstName { get; set; }
    public String LastName { get; set; }
    public String IdentityNumber { get; set; }
    public String Email { get; set; }
    public Boolean IsTenant { get; set; }
    public Guid ApartmentId { get; set; }

    public ICollection<GetByUserIdVehicleDto> Vehicles { get; set; }

    //araç - telefon - daire bilgileri eklenecek
}