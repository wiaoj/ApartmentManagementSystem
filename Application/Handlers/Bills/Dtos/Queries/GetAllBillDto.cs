using Domain.Enums;

namespace Application.Handlers.Bills.Dtos.Queries;

public record GetAllBillDto {
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public BillType BillType { get; set; }
    public DateTime Month { get; set; }
    public Decimal Price { get; set; }
    public String Description { get; set; }
    public Boolean IsPaid { get; set; }
}