using Application.Handlers.Vehicles.BusinessRules;
using Application.Handlers.Vehicles.Constants;
using Application.Handlers.Vehicles.Dtos.Commands;
using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Handlers.Vehicles.Commands.Create;

public class CreateVehicleCommand : IRequest<CreatedVehicleDto> {
    public String Plate { get; set; }
    public Guid UserId { get; set; }

    internal class CreateCommandHandler : IRequestHandler<CreateVehicleCommand, CreatedVehicleDto> {
        private readonly IVehicleRepository _vehicleRepository;
        private readonly VehicleBusinessRules _vehicleBusinessRules;
        private readonly IMapper _mapper;

        public CreateCommandHandler(IVehicleRepository vehicleRepository, VehicleBusinessRules vehicleBusinessRules, IMapper mapper) {
            _vehicleRepository = vehicleRepository;
            _vehicleBusinessRules = vehicleBusinessRules;
            _mapper = mapper;
        }

        public async Task<CreatedVehicleDto> Handle(CreateVehicleCommand request, CancellationToken cancellationToken) {
            await _vehicleBusinessRules.VehiclePlateCanNotBeDuplicatedWhenInserted(request.Plate);

            Vehicle mappedVehicle = _mapper.Map<Vehicle>(request);
            Vehicle createdVehicle = await _vehicleRepository.AddAsync(mappedVehicle);

            CreatedVehicleDto createdVehicleDto = _mapper.Map<CreatedVehicleDto>(createdVehicle);
            createdVehicleDto.Message = VehicleMessageConstants.Created;

            return createdVehicleDto;
        }
    }
}