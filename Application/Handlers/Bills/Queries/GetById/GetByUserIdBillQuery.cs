using Application.Handlers.Bills.BusinessRules;
using Application.Handlers.Bills.Dtos.Queries;
using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Handlers.Bills.Queries.GetById;
public class GetByUserIdBillQuery : IRequest<IQueryable<GetByUserIdBillDto>> {
    public Guid UserId { get; set; }

    internal class GetByUserIdBillQueryHandler : IRequestHandler<GetByUserIdBillQuery, IQueryable<GetByUserIdBillDto>> {
        private readonly IBillRepository _billRepository;
        private readonly BillBusinessRules _billBusinessRules;
        private readonly IMapper _mapper;

        public GetByUserIdBillQueryHandler(IBillRepository billRepository, BillBusinessRules billBusinessRules, IMapper mapper) {
            _billRepository = billRepository;
            _billBusinessRules = billBusinessRules;
            _mapper = mapper;
        }

        public async Task<IQueryable<GetByUserIdBillDto>> Handle(GetByUserIdBillQuery request, CancellationToken cancellationToken) {
            await _billBusinessRules.BillShouldExistWhenRequestUserId(request.UserId);

            IQueryable<Bill>? bill = await _billRepository.GetWhereAsync(x => x.CarOwnerId.Equals(request.UserId), enableTracking: false);

            IQueryable<GetByUserIdBillDto> getByIdBillDto = _mapper.ProjectTo<GetByUserIdBillDto>(bill);

            return getByIdBillDto;
        }
    }
}