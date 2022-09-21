using Domain.Enums;

namespace Application.Handlers.Bills.Dtos.Commands;
public record UpdatedBillDto {
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public BillType BillType { get; set; }
    public DateTime Month { get; set; }
    public Decimal Price { get; set; }
    public String Description { get; set; }
    public Boolean IsPaid { get; set; }
    public String Message { get; set; }
}