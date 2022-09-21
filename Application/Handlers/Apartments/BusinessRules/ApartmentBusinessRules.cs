using Application.Handlers.Apartments.Constants;
using Application.Repositories;
using Domain.Entities;

namespace Application.Handlers.Apartments.BusinessRules;
internal class ApartmentBusinessRules {
    private readonly IApartmentRepository _apartmentRepository;

    public ApartmentBusinessRules(IApartmentRepository apartmentRepository) {
        _apartmentRepository = apartmentRepository;
    }

    public async Task ApartmentCanNotBeDuplicatedWhenInserted() { }

    public Task ApartmentShouldExistWhenRequest(Apartment? apartment) {
        _ = apartment ?? throw new Exception(ApartmentMessageConstants.NotFound);
        return Task.CompletedTask;
    }

    public async Task ApartmentShouldExistWhenRequestId(Guid id) {
        _ = await _apartmentRepository.GetByIdAsync(id, enableTracking: false)
            ?? throw new Exception(ApartmentMessageConstants.NotFound);
    }
}