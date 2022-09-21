using Application.Handlers.Apartments.BusinessRules;
using Application.Handlers.Apartments.Dtos.Queries;
using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Handlers.Apartments.Queries.GetById;
public class GetByIdApartmentQuery : IRequest<GetByIdApartmentDto> {
    public Guid Id { get; set; }

    internal class GetByIdApartmentQueryHandler : IRequestHandler<GetByIdApartmentQuery, GetByIdApartmentDto> {
        private readonly IApartmentRepository _apartmentRepository;
        private readonly ApartmentBusinessRules _apartmentBusinessRules;
        private readonly IMapper _mapper;

        public GetByIdApartmentQueryHandler(IApartmentRepository apartmentRepository, ApartmentBusinessRules apartmentBusinessRules, IMapper mapper) {
            _apartmentRepository = apartmentRepository;
            _apartmentBusinessRules = apartmentBusinessRules;
            _mapper = mapper;
        }

        public async Task<GetByIdApartmentDto> Handle(GetByIdApartmentQuery request, CancellationToken cancellationToken) {
            await _apartmentBusinessRules.ApartmentShouldExistWhenRequestId(request.Id);

            Apartment? apartment = await _apartmentRepository.GetByIdAsync(request.Id, enableTracking: false);

            GetByIdApartmentDto getByIdApartmentDto = _mapper.Map<GetByIdApartmentDto>(apartment);

            return getByIdApartmentDto;
        }
    }
}