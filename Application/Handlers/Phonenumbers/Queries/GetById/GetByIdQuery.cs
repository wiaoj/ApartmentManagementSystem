using Application.Handlers.Phonenumbers.Dtos.Queries;
using MediatR;

namespace Application.Handlers.Phonenumbers.Queries.GetById;
public class GetByIdPhoneNumberQuery : IRequest<GetByIdPhoneNumberDto> {
    public Guid Id { get; set; }

    internal class GetByIdPhoneNumberQueryHandler : IRequestHandler<GetByIdPhoneNumberQuery, GetByIdPhoneNumberDto> {
        public Task<GetByIdPhoneNumberDto> Handle(GetByIdPhoneNumberQuery request, CancellationToken cancellationToken) {
            throw new NotImplementedException();
        }
    }
}