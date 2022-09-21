using Application.Handlers.Bills.Constants;
using Application.Repositories;
using Domain.Entities;

namespace Application.Handlers.Bills.BusinessRules;
internal class BillBusinessRules {
    private readonly IBillRepository _billRepository;

    public BillBusinessRules(IBillRepository billRepository) {
        _billRepository = billRepository;
    }

    public async Task BillPlateCanNotBeDuplicatedWhenInserted(String plate) {
        IQueryable<Bill> result = await _billRepository
            .GetWhereAsync(x => x.Plate.Equals(plate), enableTracking: false);
        if(result.Any())
            throw new Exception(BillMessageConstants.AlredyExist);
    }

    public Task BillShouldExistWhenRequest(Bill? bill) {
        _ = bill ?? throw new Exception(BillMessageConstants.NotFound);
        return Task.CompletedTask;
    }

    public async Task BillShouldExistWhenRequestId(Guid id) {
        _ = await _billRepository.GetByIdAsync(id, enableTracking: false)
            ?? throw new Exception(BillMessageConstants.NotFound);
    }

    public async Task BillShouldExistWhenRequestUserId(Guid userId) {
        _ = await _billRepository.GetWhereAsync(x => x.CarOwnerId.Equals(userId), enableTracking: false)
            ?? throw new Exception(BillMessageConstants.NotFound);
    }
}