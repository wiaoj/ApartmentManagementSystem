using Application.Handlers.PhoneNumbers.BusinessRules;
using Application.Handlers.PhoneNumbers.Constants;
using Application.Handlers.PhoneNumbers.Dtos.Commands;
using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Handlers.PhoneNumbers.Commands.Create;

public class CreatePhoneNumberCommand : IRequest<CreatedPhoneNumberDto> {
    public String CountryCode { get; set; }
    public String Number { get; set; }
    public Guid UserId { get; set; }

    internal class CreatePhonenumberCommandHandler : IRequestHandler<CreatePhoneNumberCommand, CreatedPhoneNumberDto> {
        private readonly IPhoneNumberRepository _phoneNumberRepository;
        private readonly PhoneNumberBusinessRules _phoneNumberBusinessRules;
        private readonly IMapper _mapper;

        public CreatePhonenumberCommandHandler(IPhoneNumberRepository phoneNumberRepository, PhoneNumberBusinessRules phoneNumberBusinessRules, IMapper mapper) {
            _phoneNumberRepository = phoneNumberRepository;
            _phoneNumberBusinessRules = phoneNumberBusinessRules;
            _mapper = mapper;
        }

        public async Task<CreatedPhoneNumberDto> Handle(CreatePhoneNumberCommand request, CancellationToken cancellationToken) {
            await _phoneNumberBusinessRules.PhoneNumberCanNotBeDuplicatedWhenInserted(request.Number);

            PhoneNumber mappedPhoneNumber = _mapper.Map<PhoneNumber>(request);

            PhoneNumber createdPhoneNumber = await _phoneNumberRepository.AddAsync(mappedPhoneNumber);

            CreatedPhoneNumberDto createdPhoneNumberDto = _mapper.Map<CreatedPhoneNumberDto>(createdPhoneNumber);
            createdPhoneNumberDto.Message = PhoneNumberMessageConstants.Created;

            return createdPhoneNumberDto;
        }
    }
}