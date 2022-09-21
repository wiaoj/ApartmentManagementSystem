using Application.Handlers.Vehicles.BusinessRules;
using Application.Handlers.Vehicles.Constants;
using Application.Handlers.Vehicles.Dtos.Commands;
using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Handlers.Vehicles.Commands.Delete;

public class DeleteVehicleCommand : IRequest<DeletedVehicleDto> {
    public Guid Id { get; set; }

    internal class DeleteCommandHandler : IRequestHandler<DeleteVehicleCommand, DeletedVehicleDto> {
        private readonly IVehicleRepository _vehicleRepository;
        private readonly VehicleBusinessRules _vehicleBusinessRules;
        private readonly IMapper _mapper;

        public DeleteCommandHandler(IVehicleRepository vehicleRepository, VehicleBusinessRules vehicleBusinessRules, IMapper mapper) {
            _vehicleRepository = vehicleRepository;
            _vehicleBusinessRules = vehicleBusinessRules;
            _mapper = mapper;
        }

        public async Task<DeletedVehicleDto> Handle(DeleteVehicleCommand request, CancellationToken cancellationToken) {
            await _vehicleBusinessRules.VehicleShouldExistWhenRequestId(request.Id);

            Vehicle mappedVehicle = _mapper.Map<Vehicle>(request);
            Vehicle deletedVehicle = await _vehicleRepository.DeleteAsync(mappedVehicle.Id);

            DeletedVehicleDto deletedVehicleDto = _mapper.Map<DeletedVehicleDto>(deletedVehicle);
            deletedVehicleDto.Message = VehicleMessageConstants.Deleted;

            return deletedVehicleDto;
        }
    }
}