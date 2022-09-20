using Application.Handlers.PhoneNumbers.Constants;
using Application.Repositories;
using Domain.Entities;

namespace Application.Handlers.Phonenumbers.BusinessRules;
internal class PhoneNumberBusinessRules {
	private readonly IPhoneNumberRepository _phoneNumberRepository;
	public PhoneNumberBusinessRules(IPhoneNumberRepository phoneNumberRepository) {
		this._phoneNumberRepository = phoneNumberRepository;
	}

    public async Task PhoneNumberCanNotBeDuplicatedWhenInserted(String number) {
        IQueryable<PhoneNumber> result = await _phoneNumberRepository
            .GetWhereAsync(x => x.Number.Equals(number), enableTracking: false);
        if(result.Any())
            throw new Exception(PhoneNumberMessageConstants.AlredyExist);
    }

    public Task PhoneNumberShouldExistWhenRequest(PhoneNumber? phoneNumber) {
        _ = phoneNumber ?? throw new Exception(PhoneNumberMessageConstants.NotFound);
        return Task.CompletedTask;
    }

    public async Task PhoneNumberShouldExistWhenRequestId(Guid id) {
        _ = await _phoneNumberRepository.GetByIdAsync(id, enableTracking: false)
            ?? throw new Exception(PhoneNumberMessageConstants.NotFound);
    }

}