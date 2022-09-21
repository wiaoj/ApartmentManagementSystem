using Application.Handlers.Users.BusinessRules;
using Application.Handlers.Users.Dtos.Queries;
using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Handlers.Users.Queries.GetById;
public class GetByIdUserQuery : IRequest<GetByIdUserDto> {
    public Guid Id { get; set; }

    internal class GetByIdUserQueryHandler : IRequestHandler<GetByIdUserQuery, GetByIdUserDto> {
        private readonly IUserRepository _userRepository;
        private readonly UserBusinessRules _userBusinessRules;
        private readonly IMapper _mapper;

        public GetByIdUserQueryHandler(IUserRepository userRepository, UserBusinessRules userBusinessRules, IMapper mapper) {
            _userRepository = userRepository;
            _userBusinessRules = userBusinessRules;
            _mapper = mapper;
        }

        public async Task<GetByIdUserDto> Handle(GetByIdUserQuery request, CancellationToken cancellationToken) {
            await _userBusinessRules.UserShouldExistWhenRequestId(request.Id);

            User? user = await _userRepository.GetByIdAsync(
                request.Id,
                include: x => 
                    x.Include(u => u.Vehicles)
                     .Include(u => u.PhoneNumbers),
                enableTracking: false);

            //gereksiz ama keyfi eklendi - neden olmasın
            await _userBusinessRules.UserShouldExistWhenRequest(user);

            GetByIdUserDto getByIdUserDto = _mapper.Map<GetByIdUserDto>(user);

            return getByIdUserDto;
        }
    }
}