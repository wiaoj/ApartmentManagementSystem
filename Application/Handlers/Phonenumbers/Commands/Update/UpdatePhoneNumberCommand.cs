using Application.Handlers.PhoneNumbers.BusinessRules;
using Application.Handlers.PhoneNumbers.Constants;
using Application.Handlers.PhoneNumbers.Dtos.Commands;
using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Handlers.PhoneNumbers.Commands.Update;

public class UpdatePhoneNumberCommand : IRequest<UpdatedPhoneNumberDto> {
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public String CountryCode { get; set; }
    public String Number { get; set; }

    internal class UpdateCommandHandler : IRequestHandler<UpdatePhoneNumberCommand, UpdatedPhoneNumberDto> {
        private readonly IPhoneNumberRepository _phoneNumberRepository;
        private readonly PhoneNumberBusinessRules _phoneNumberBusinessRules;
        private readonly IMapper _mapper;

        public UpdateCommandHandler(IPhoneNumberRepository phoneNumberRepository, PhoneNumberBusinessRules phoneNumberBusinessRules, IMapper mapper) {
            _phoneNumberRepository = phoneNumberRepository;
            _phoneNumberBusinessRules = phoneNumberBusinessRules;
            _mapper = mapper;
        }

        public async Task<UpdatedPhoneNumberDto> Handle(UpdatePhoneNumberCommand request, CancellationToken cancellationToken) {
            await _phoneNumberBusinessRules.PhoneNumberShouldExistWhenRequestId(request.Id);

            PhoneNumber mappedPhoneNumber = _mapper.Map<PhoneNumber>(request);
            PhoneNumber updatedPhoneNumber = await _phoneNumberRepository.UpdateAsync(mappedPhoneNumber);

            UpdatedPhoneNumberDto updatedPhoneNumberDto = _mapper.Map<UpdatedPhoneNumberDto>(updatedPhoneNumber);
            updatedPhoneNumberDto.Message = PhoneNumberMessageConstants.Updated;

            return updatedPhoneNumberDto;
        }
    }
}