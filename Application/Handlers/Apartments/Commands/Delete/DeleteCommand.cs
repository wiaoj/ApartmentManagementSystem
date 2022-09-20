using Application.Handlers.Apartments.Dtos.Commands;
using MediatR;

namespace Application.Handlers.Apartments.Commands.Delete;

public class DeleteCommand : IRequest<DeletedDto> {
	public Guid Id { get; set; }

	internal class DeleteCommandHandler : IRequestHandler<DeleteCommand, DeletedDto> {
		public Task<DeletedDto> Handle(DeleteCommand request, CancellationToken cancellationToken) {
            throw new NotImplementedException();
        }
	}
}