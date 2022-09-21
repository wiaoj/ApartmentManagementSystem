using Application.Handlers.Bills.Dtos.Queries;
using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Handlers.Bills.Queries.GetAll;
public class GetAllBillQuery : IRequest<IQueryable<GetAllBillDto>> {

    internal class GetAllBillQueryHandler : IRequestHandler<GetAllBillQuery, IQueryable<GetAllBillDto>> {
        private readonly IBillRepository _billRepository;
        private readonly IMapper _mapper;

        public GetAllBillQueryHandler(IBillRepository billRepository, IMapper mapper) {
            _billRepository = billRepository;
            _mapper = mapper;
        }

        public async Task<IQueryable<GetAllBillDto>> Handle(GetAllBillQuery request, CancellationToken cancellationToken) {
            IQueryable<Bill> mappedBills = _billRepository.GetAll(enableTracking: false);

            IQueryable<GetAllBillDto> getAllBillDto = _mapper.ProjectTo<GetAllBillDto>(mappedBills);

            return getAllBillDto;
        }
    }
}