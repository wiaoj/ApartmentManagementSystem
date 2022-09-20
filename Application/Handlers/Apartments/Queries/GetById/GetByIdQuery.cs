using Application.Handlers.Apartments.Dtos.Queries;
using MediatR;

namespace Application.Handlers.Apartments.Queries.GetById;
public class GetByIdQuery : IRequest<GetByIdDto> {
    public Guid Id { get; set; }

    internal class GetByIdQueryHandler : IRequestHandler<GetByIdQuery, GetByIdDto> {
        public Task<GetByIdDto> Handle(GetByIdQuery request, CancellationToken cancellationToken) {
            throw new NotImplementedException();
        }
    }
}
