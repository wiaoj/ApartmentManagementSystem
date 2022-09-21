using Application.Handlers.Vehicles.Dtos.Queries;
using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Handlers.Vehicles.Queries.GetAll;
public class GetAllVehicleQuery : IRequest<IQueryable<GetAllVehicleDto>> {

    internal class GetAllVehicleQueryHandler : IRequestHandler<GetAllVehicleQuery, IQueryable<GetAllVehicleDto>> {
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IMapper _mapper;

        public GetAllVehicleQueryHandler(IVehicleRepository vehicleRepository, IMapper mapper) {
            _vehicleRepository = vehicleRepository;
            _mapper = mapper;
        }

        public async Task<IQueryable<GetAllVehicleDto>> Handle(GetAllVehicleQuery request, CancellationToken cancellationToken) {
            IQueryable<Vehicle> mappedVehicles = _vehicleRepository.GetAll(enableTracking: false);

            IQueryable<GetAllVehicleDto> getAllVehicleDto = _mapper.ProjectTo<GetAllVehicleDto>(mappedVehicles);

            return getAllVehicleDto;
        }
    }
}