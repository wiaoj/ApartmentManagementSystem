using Domain.Entities.Base;
using ApartmentState = Domain.Enums.ApartmentState;

namespace Domain.Entities;

public class Apartment : IBaseEntity {
    public String Number { get; set; }
    public String BlockNo { get; set; }
    public String Floor { get; set; }
    public String Type { get; set; }
    public ApartmentState ApartmentState { get; set; }

    public Apartment() { }
    public Apartment(String number, String blockNo, String floor, String type, ApartmentState apartmentState) : this() {
        Number = number;
        BlockNo = blockNo;
        Floor = floor;
        Type = type;
        ApartmentState = apartmentState;
    }
}