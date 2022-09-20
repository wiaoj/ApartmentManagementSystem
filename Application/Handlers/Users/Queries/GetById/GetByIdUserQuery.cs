using Application.Handlers.Users.Dtos.Queries;
using MediatR;

namespace Application.Handlers.Users.Queries.GetById;
public class GetByIdUserQuery : IRequest<GetByIdUserDto> {
    public Guid Id { get; set; }

    internal class GetByIdUserQueryHandler : IRequestHandler<GetByIdUserQuery, GetByIdUserDto> {
        public Task<GetByIdUserDto> Handle(GetByIdUserQuery request, CancellationToken cancellationToken) {
            throw new NotImplementedException();
        }
    }
}