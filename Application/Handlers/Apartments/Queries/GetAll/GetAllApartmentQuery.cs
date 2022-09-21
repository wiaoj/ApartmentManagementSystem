using Application.Handlers.Apartments.Dtos.Queries;
using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Handlers.Apartments.Queries.GetAll;
public class GetAllApartmentQuery : IRequest<IQueryable<GetAllApartmentDto>> {

    internal class GetAllApartmentQueryHandler : IRequestHandler<GetAllApartmentQuery, IQueryable<GetAllApartmentDto>> {
        private readonly IApartmentRepository _apartmentRepository;
        private readonly IMapper _mapper;

        public GetAllApartmentQueryHandler(IApartmentRepository apartmentRepository, IMapper mapper) {
            _apartmentRepository = apartmentRepository;
            _mapper = mapper;
        }

        public async Task<IQueryable<GetAllApartmentDto>> Handle(GetAllApartmentQuery request, CancellationToken cancellationToken) {
            IQueryable<Apartment> mappedApartments = _apartmentRepository.GetAll(enableTracking: false);

            IQueryable<GetAllApartmentDto> getAllApartmentDto = _mapper.ProjectTo<GetAllApartmentDto>(mappedApartments);

            return getAllApartmentDto;
        }
    }
}