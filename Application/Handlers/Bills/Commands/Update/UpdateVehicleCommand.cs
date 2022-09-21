using Application.Handlers.Vehicles.BusinessRules;
using Application.Handlers.Vehicles.Constants;
using Application.Handlers.Vehicles.Dtos.Commands;
using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Handlers.Vehicles.Commands.Update;

public class UpdateVehicleCommand : IRequest<UpdatedVehicleDto> {
    public Guid Id { get; set; }
    public String Plate { get; set; }
    public Guid UserId { get; set; }

    internal class UpdateVehicleCommandHandler : IRequestHandler<UpdateVehicleCommand, UpdatedVehicleDto> {
        private readonly IVehicleRepository _vehicleRepository;
        private readonly VehicleBusinessRules _vehicleBusinessRules;
        private readonly IMapper _mapper;

        public UpdateVehicleCommandHandler(IVehicleRepository vehicleRepository, VehicleBusinessRules vehicleBusinessRules, IMapper mapper) {
            _vehicleRepository = vehicleRepository;
            _vehicleBusinessRules = vehicleBusinessRules;
            _mapper = mapper;
        }

        public async Task<UpdatedVehicleDto> Handle(UpdateVehicleCommand request, CancellationToken cancellationToken) {
            await _vehicleBusinessRules.VehicleShouldExistWhenRequestId(request.Id);

            Vehicle mappedVehicle = _mapper.Map<Vehicle>(request);
            Vehicle updatedVehicle = await _vehicleRepository.UpdateAsync(mappedVehicle);

            UpdatedVehicleDto updatedVehicleDto = _mapper.Map<UpdatedVehicleDto>(updatedVehicle);
            updatedVehicleDto.Message = VehicleMessageConstants.Updated;

            return updatedVehicleDto;
        }
    }
}