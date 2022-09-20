using Application.Handlers.Phonenumbers.BusinessRules;
using Application.Handlers.Phonenumbers.Dtos.Commands;
using Application.Handlers.PhoneNumbers.Constants;
using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Handlers.Phonenumbers.Commands.Delete;

public class DeletePhoneNumberCommand : IRequest<DeletedPhoneNumberDto> {
    public Guid Id { get; set; }

    internal class DeleteCommandHandler : IRequestHandler<DeletePhoneNumberCommand, DeletedPhoneNumberDto> {
        private readonly IPhoneNumberRepository _phoneNumberRepository;
        private readonly PhoneNumberBusinessRules _phoneNumberBusinessRules;
        private readonly IMapper _mapper;

        public DeleteCommandHandler(IPhoneNumberRepository phoneNumberRepository, PhoneNumberBusinessRules phoneNumberBusinessRules, IMapper mapper) {
            _phoneNumberRepository = phoneNumberRepository;
            _phoneNumberBusinessRules = phoneNumberBusinessRules;
            _mapper = mapper;
        }

        public async Task<DeletedPhoneNumberDto> Handle(DeletePhoneNumberCommand request, CancellationToken cancellationToken) {
            await _phoneNumberBusinessRules.PhoneNumberShouldExistWhenRequestId(request.Id);

            PhoneNumber mappedPhoneNumber = _mapper.Map<PhoneNumber>(request);

            PhoneNumber deletedPhoneNumber = await _phoneNumberRepository.DeleteAsync(mappedPhoneNumber);

            DeletedPhoneNumberDto deletedPhoneNumberDto = _mapper.Map<DeletedPhoneNumberDto>(deletedPhoneNumber);
            deletedPhoneNumberDto.Message = PhoneNumberMessageConstants.Deleted;

            return deletedPhoneNumberDto;
        }
    }
}