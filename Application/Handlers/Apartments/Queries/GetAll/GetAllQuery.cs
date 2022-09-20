using Application.Handlers.Apartments.Dtos.Queries;
using MediatR;

namespace Application.Handlers.Apartments.Queries.GetAll;
public class GetAllQuery : IRequest<GetAllDto> {

    internal class GetAllQueryHandler : IRequestHandler<GetAllQuery, GetAllDto> {
        public Task<GetAllDto> Handle(GetAllQuery request, CancellationToken cancellationToken) {
            throw new NotImplementedException();
        }
    }
}
