using Domain.Entities.Base;

namespace Domain.Entities;

public class PhoneNumber : IBaseEntity {
    public String CountryCode { get; set; }
    public String Number { get; set; }

    public Guid PhoneNumberUserId { get; set; }
    public User PhoneNumberUser { get; set; }

    public PhoneNumber() { }
    public PhoneNumber(String number, Guid phoneNumberUserId) : this() {
        Number = number;
        PhoneNumberUserId = phoneNumberUserId;
    }
}