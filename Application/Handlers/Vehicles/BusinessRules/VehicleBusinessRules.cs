using Application.Handlers.Vehicles.Constants;
using Application.Repositories;
using Domain.Entities;

namespace Application.Handlers.Vehicles.BusinessRules;
internal class VehicleBusinessRules {
    private readonly IVehicleRepository _vehicleRepository;

    public VehicleBusinessRules(IVehicleRepository vehicleRepository) {
        _vehicleRepository = vehicleRepository;
    }

    public async Task VehiclePlateCanNotBeDuplicatedWhenInserted(String plate) {
        IQueryable<Vehicle> result = await _vehicleRepository
            .GetWhereAsync(x => x.Plate.Equals(plate), enableTracking: false);
        if(result.Any())
            throw new Exception(VehicleMessageConstants.AlredyExist);
    }

    public Task VehicleShouldExistWhenRequest(Vehicle? vehicle) {
        _ = vehicle ?? throw new Exception(VehicleMessageConstants.NotFound);
        return Task.CompletedTask;
    }

    public async Task VehicleShouldExistWhenRequestId(Guid id) {
        _ = await _vehicleRepository.GetByIdAsync(id, enableTracking: false)
            ?? throw new Exception(VehicleMessageConstants.NotFound);
    }

    public async Task VehicleShouldExistWhenRequestUserId(Guid userId) {
        _ = await _vehicleRepository.GetWhereAsync(x => x.CarOwnerId.Equals(userId), enableTracking: false)
            ?? throw new Exception(VehicleMessageConstants.NotFound);
    }
}