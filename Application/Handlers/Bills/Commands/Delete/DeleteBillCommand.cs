using Application.Handlers.Bills.BusinessRules;
using Application.Handlers.Bills.Constants;
using Application.Handlers.Bills.Dtos.Commands;
using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Handlers.Bills.Commands.Delete;

public class DeleteBillCommand : IRequest<DeletedBillDto> {
    public Guid Id { get; set; }

    internal class DeleteCommandHandler : IRequestHandler<DeleteBillCommand, DeletedBillDto> {
        private readonly IBillRepository _billRepository;
        private readonly BillBusinessRules _billBusinessRules;
        private readonly IMapper _mapper;

        public DeleteCommandHandler(IBillRepository billRepository, BillBusinessRules billBusinessRules, IMapper mapper) {
            _billRepository = billRepository;
            _billBusinessRules = billBusinessRules;
            _mapper = mapper;
        }

        public async Task<DeletedBillDto> Handle(DeleteBillCommand request, CancellationToken cancellationToken) {
            await _billBusinessRules.BillShouldExistWhenRequestId(request.Id);

            Bill mappedBill = _mapper.Map<Bill>(request);
            Bill deletedBill = await _billRepository.DeleteAsync(mappedBill.Id);

            DeletedBillDto deletedBillDto = _mapper.Map<DeletedBillDto>(deletedBill);
            deletedBillDto.Message = BillMessageConstants.Deleted;

            return deletedBillDto;
        }
    }
}