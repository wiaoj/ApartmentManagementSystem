using Application.Handlers.Bills.BusinessRules;
using Application.Handlers.Bills.Constants;
using Application.Handlers.Bills.Dtos.Commands;
using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using Domain.Enums;
using MediatR;

namespace Application.Handlers.Bills.Commands.Update;

public class UpdateBillCommand : IRequest<UpdatedBillDto> {
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public BillType BillType { get; set; }
    public DateTime Month { get; set; }
    public Decimal Price { get; set; }
    public String Description { get; set; }
    public Boolean IsPaid { get; set; }

    internal class UpdateBillCommandHandler : IRequestHandler<UpdateBillCommand, UpdatedBillDto> {
        private readonly IBillRepository _billRepository;
        private readonly BillBusinessRules _billBusinessRules;
        private readonly IMapper _mapper;

        public UpdateBillCommandHandler(IBillRepository billRepository, BillBusinessRules billBusinessRules, IMapper mapper) {
            _billRepository = billRepository;
            _billBusinessRules = billBusinessRules;
            _mapper = mapper;
        }

        public async Task<UpdatedBillDto> Handle(UpdateBillCommand request, CancellationToken cancellationToken) {
            await _billBusinessRules.BillShouldExistWhenRequestId(request.Id);

            Bill mappedBill = _mapper.Map<Bill>(request);
            Bill updatedBill = await _billRepository.UpdateAsync(mappedBill);

            UpdatedBillDto updatedBillDto = _mapper.Map<UpdatedBillDto>(updatedBill);
            updatedBillDto.Message = BillMessageConstants.Updated;

            return updatedBillDto;
        }
    }
}