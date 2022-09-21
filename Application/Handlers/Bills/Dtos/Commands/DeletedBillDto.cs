namespace Application.Handlers.Bills.Dtos.Commands;
public record DeletedBillDto {
    public Guid Id { get; set; }
    public String Message { get; set; }
}