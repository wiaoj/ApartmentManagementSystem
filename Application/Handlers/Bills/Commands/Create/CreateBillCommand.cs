using Application.Handlers.Bills.BusinessRules;
using Application.Handlers.Bills.Constants;
using Application.Handlers.Bills.Dtos.Commands;
using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using Domain.Enums;
using MediatR;

namespace Application.Handlers.Bills.Commands.Create;

public class CreateBillCommand : IRequest<CreatedBillDto> {
    public Guid UserId { get; set; }
    public BillType BillType { get; set; }
    public DateTime Month { get; set; }
    public Decimal Price { get; set; }
    public String Description { get; set; }
    public Boolean IsPaid { get; set; }


    internal class CreateCommandHandler : IRequestHandler<CreateBillCommand, CreatedBillDto> {
        private readonly IBillRepository _billRepository;
        private readonly BillBusinessRules _billBusinessRules;
        private readonly IMapper _mapper;

        public CreateCommandHandler(IBillRepository billRepository, BillBusinessRules billBusinessRules, IMapper mapper) {
            _billRepository = billRepository;
            _billBusinessRules = billBusinessRules;
            _mapper = mapper;
        }

        public async Task<CreatedBillDto> Handle(CreateBillCommand request, CancellationToken cancellationToken) {
            //await _billBusinessRules.BillPlateCanNotBeDuplicatedWhenInserted(request.?);

            Bill mappedBill = _mapper.Map<Bill>(request);
            Bill createdBill = await _billRepository.AddAsync(mappedBill);

            CreatedBillDto createdBillDto = _mapper.Map<CreatedBillDto>(createdBill);
            createdBillDto.Message = BillMessageConstants.Created;

            return createdBillDto;
        }
    }
}