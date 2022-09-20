using Application.Handlers.PhoneNumbers.Dtos.Queries;
using MediatR;

namespace Application.Handlers.PhoneNumbers.Queries.GetAll;
public class GetAllPhoneNumberQuery : IRequest<GetAllPhoneNumberDto> {

    internal class GetAllPhoneNumberQueryHandler : IRequestHandler<GetAllPhoneNumberQuery, GetAllPhoneNumberDto> {
        public Task<GetAllPhoneNumberDto> Handle(GetAllPhoneNumberQuery request, CancellationToken cancellationToken) {
            throw new NotImplementedException();
        }
    }
}