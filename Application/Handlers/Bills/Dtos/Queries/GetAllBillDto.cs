namespace Application.Handlers.Bills.Dtos.Queries;

public record GetAllBillDto {
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
}