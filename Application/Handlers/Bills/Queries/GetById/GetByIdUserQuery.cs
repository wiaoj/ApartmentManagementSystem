using Application.Handlers.Vehicles.BusinessRules;
using Application.Handlers.Vehicles.Dtos.Queries;
using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Handlers.Vehicles.Queries.GetById;
public class GetByUserIdVehicleQuery : IRequest<IQueryable<GetByUserIdVehicleDto>> {
    public Guid UserId { get; set; }

    internal class GetByUserIdVehicleQueryHandler : IRequestHandler<GetByUserIdVehicleQuery, IQueryable<GetByUserIdVehicleDto>> {
        private readonly IVehicleRepository _vehicleRepository;
        private readonly VehicleBusinessRules _vehicleBusinessRules;
        private readonly IMapper _mapper;

        public GetByUserIdVehicleQueryHandler(IVehicleRepository vehicleRepository, VehicleBusinessRules vehicleBusinessRules, IMapper mapper) {
            _vehicleRepository = vehicleRepository;
            _vehicleBusinessRules = vehicleBusinessRules;
            _mapper = mapper;
        }

        public async Task<IQueryable<GetByUserIdVehicleDto>> Handle(GetByUserIdVehicleQuery request, CancellationToken cancellationToken) {
            await _vehicleBusinessRules.VehicleShouldExistWhenRequestUserId(request.UserId);

            IQueryable<Vehicle>? vehicle = await _vehicleRepository.GetWhereAsync(x => x.CarOwnerId.Equals(request.UserId), enableTracking: false);

            IQueryable<GetByUserIdVehicleDto> getByIdVehicleDto = _mapper.ProjectTo<GetByUserIdVehicleDto>(vehicle);

            return getByIdVehicleDto;
        }
    }
}