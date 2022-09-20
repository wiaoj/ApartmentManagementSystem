using Domain.Entities.Base;

namespace Domain.Entities;
public class User : IBaseEntity {
    public String FirstName { get; set; }
    public String LastName { get; set; }
    public String IdentityNumber { get; set; }
    public String Email { get; set; }

    public ICollection<PhoneNumber> PhoneNumbers { get; set; }

    public Boolean IsTenant { get; set; }
    public Guid ApartmentId { get; set; }
    public Apartment Apartment { get; set; }

    public ICollection<Vehicle> Vehicles { get; set; }
}