namespace Application.Handlers.Bills.Dtos.Commands;
public record CreatedBillDto {
    public Guid Id { get; set; }
    public String Message { get; set; }
}