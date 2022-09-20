using Domain.Entities.Base;

namespace Domain.Entities;

public class Vehicle : IBaseEntity {
    public String Plate { get; set; }

    public Guid CarOwnerId { get; set; }
    public User CarOwner { get; set; }

    public Vehicle() { }
    public Vehicle(String plate, User carOwner) : this() {
        Plate = plate;
        CarOwner = carOwner;
    }
}