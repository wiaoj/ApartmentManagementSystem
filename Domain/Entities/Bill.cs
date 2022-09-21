using Domain.Entities.Base;
using Domain.Enums;

namespace Domain.Entities;
public class Bill : IBaseEntity {
    public BillType BillType { get; set; }
    public DateTime Month { get; set; }
    public Decimal Price { get; set; }
    public String Description { get; set; }
    public Boolean IsPaid { get; set; }

    public Guid UserId { get; set; }
    public User User { get; set; }
}