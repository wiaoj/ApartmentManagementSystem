namespace Domain.Entities.Base;
public abstract class IBaseEntity {
    public Guid Id { get; set; }

	public IBaseEntity() {
		Id = Guid.NewGuid();
	}
}