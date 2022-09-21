using Application.Handlers.Apartments.Dtos.Commands;
using MediatR;

namespace Application.Handlers.Apartments.Commands.Create;

public class CreateCommand : IRequest<CreatedDto> {

    internal class CreateCommandHandler : IRequestHandler<CreateCommand, CreatedDto> {
        public Task<CreatedDto> Handle(CreateCommand request, CancellationToken cancellationToken) {
            throw new NotImplementedException();
        }
    }
}