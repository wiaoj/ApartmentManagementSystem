using Application.Handlers.Users.Dtos.Queries;
using MediatR;

namespace Application.Handlers.Users.Queries.GetAll;
public class GetAllUserQuery : IRequest<GetAllUserDto> {

    internal class GetAllQueryHandler : IRequestHandler<GetAllUserQuery, GetAllUserDto> {
        public Task<GetAllUserDto> Handle(GetAllUserQuery request, CancellationToken cancellationToken) {
            throw new NotImplementedException();
        }
    }
}