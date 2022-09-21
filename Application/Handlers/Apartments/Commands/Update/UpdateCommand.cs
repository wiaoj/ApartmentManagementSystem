using Application.Handlers.Apartments.Dtos.Commands;
using MediatR;

namespace Application.Handlers.Apartments.Commands.Update;

public class UpdateCommand : IRequest<UpdatedDto> {
    public Guid Id { get; set; }

    internal class UpdateCommandHandler : IRequestHandler<UpdateCommand, UpdatedDto> {
        public Task<UpdatedDto> Handle(UpdateCommand request, CancellationToken cancellationToken) {
            throw new NotImplementedException();
        }
    }
}