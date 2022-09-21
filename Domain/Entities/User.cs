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
    public ICollection<Bill> Bills { get; set; }

    public User() { }
    public User(String firstName, String lastName, String identityNumber, String email, Boolean isTenant, Guid apartmentId) : this() {
        this.FirstName = firstName;
        this.LastName = lastName;
        this.IdentityNumber = identityNumber;
        this.Email = email;
        this.IsTenant = isTenant;
        this.ApartmentId = apartmentId;
    }
}