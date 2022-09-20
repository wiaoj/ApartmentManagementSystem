using Application.Handlers.Users.BusinessRules;
using Application.Handlers.Users.Constants;
using Application.Handlers.Users.Dtos.Commands;
using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Handlers.Users.Commands.Create;

public class CreateUserCommand : IRequest<CreatedUserDto> {
    public String FirstName { get; set; }
    public String LastName { get; set; }
    public String IdentityNumber { get; set; }
    public String Email { get; set; }

    public Boolean IsTenant { get; set; }
    public Guid ApartmentId { get; set; }

    internal class CreateCommandHandler : IRequestHandler<CreateUserCommand, CreatedUserDto> {
        private readonly IUserRepository _userRepository;
        private readonly UserBusinessRules _userBusinessRules;
        private readonly IMapper _mapper;

        public CreateCommandHandler(IUserRepository userRepository, UserBusinessRules userBusinessRules, IMapper mapper) {
            _userRepository = userRepository;
            _userBusinessRules = userBusinessRules;
            _mapper = mapper;
        }

        public async Task<CreatedUserDto> Handle(CreateUserCommand request, CancellationToken cancellationToken) {
            await _userBusinessRules.UserIdentityNumberCanNotBeDuplicatedWhenInserted(request.IdentityNumber);

            User mappedUser = _mapper.Map<User>(request);
            User createdUser = await _userRepository.AddAsync(mappedUser);

            CreatedUserDto createdUserDto = _mapper.Map<CreatedUserDto>(createdUser);
            createdUserDto.Message = UserMessageConstants.Created;

            return createdUserDto;
        }
    }
}