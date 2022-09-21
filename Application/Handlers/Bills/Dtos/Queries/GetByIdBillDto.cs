namespace Application.Handlers.Bills.Dtos.Queries;
public record GetByIdBillDto {
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
}