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

    public User() { }
    public User(String firstName, String lastName, String ıdentityNumber, String email, ICollection<PhoneNumber> phoneNumbers, Boolean ısTenant, Guid apartmentId, Apartment apartment, ICollection<Vehicle> vehicles) : this() {
        this.FirstName = firstName;
        this.LastName = lastName;
        this.IdentityNumber = ıdentityNumber;
        this.Email = email;
        this.PhoneNumbers = phoneNumbers;
        this.IsTenant = ısTenant;
        this.ApartmentId = apartmentId;
        this.Apartment = apartment;
        this.Vehicles = vehicles;
    }
}