using Application.Handlers.PhoneNumbers.BusinessRules;
using Application.Handlers.PhoneNumbers.Dtos.Queries;
using Application.Repositories;
using AutoMapper;
using MediatR;

namespace Application.Handlers.PhoneNumbers.Queries.GetById;
public class GetByIdPhoneNumberQuery : IRequest<GetByIdPhoneNumberDto> {
    public Guid UserId { get; set; }

    internal class GetByIdPhoneNumberQueryHandler : IRequestHandler<GetByIdPhoneNumberQuery, GetByIdPhoneNumberDto> {
        private readonly IPhoneNumberRepository _phoneNumberRepository;
        private readonly PhoneNumberBusinessRules _phoneNumberBusinessRules;
        private readonly IMapper _mapper;

        public GetByIdPhoneNumberQueryHandler(IPhoneNumberRepository phoneNumberRepository, PhoneNumberBusinessRules phoneNumberBusinessRules, IMapper mapper) {
            _phoneNumberRepository = phoneNumberRepository;
            _phoneNumberBusinessRules = phoneNumberBusinessRules;
            _mapper = mapper;
        }

        public Task<GetByIdPhoneNumberDto> Handle(GetByIdPhoneNumberQuery request, CancellationToken cancellationToken) {
            throw new NotImplementedException();
        }
    }
}