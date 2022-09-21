namespace Application.Handlers.Bills.Dtos.Commands;
public record UpdatedBillDto {
    public Guid Id { get; set; }
    public String Message { get; set; }
}