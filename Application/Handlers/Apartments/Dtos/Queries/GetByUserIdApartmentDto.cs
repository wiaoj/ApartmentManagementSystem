using ApartmentState = Domain.Enums.ApartmentState;
namespace Application.Handlers.Apartments.Dtos.Queries;

public record GetByUserIdApartmentDto {
    public Guid Id { get; set; }
    public String Number { get; set; }
    public String BlockNo { get; set; }
    public String Floor { get; set; }
    public String Type { get; set; }
    public ApartmentState ApartmentState { get; set; }
}