using Application.Handlers.Users.BusinessRules;
using Application.Handlers.Users.Constants;
using Application.Handlers.Users.Dtos.Commands;
using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Handlers.Users.Commands.Update;

public class UpdateUserCommand : IRequest<UpdatedUserDto> {
    public Guid Id { get; set; }
    public String FirstName { get; set; }
    public String LastName { get; set; }
    public String IdentityNumber { get; set; }
    public String Email { get; set; }
    public Boolean IsTenant { get; set; }
    public Guid ApartmentId { get; set; }

    internal class UpdateCommandHandler : IRequestHandler<UpdateUserCommand, UpdatedUserDto> {
        private readonly IUserRepository _userRepository;
        private readonly UserBusinessRules _userBusinessRules;
        private readonly IMapper _mapper;

        public UpdateCommandHandler(IUserRepository userRepository, UserBusinessRules userBusinessRules, IMapper mapper) {
            _userRepository = userRepository;
            _userBusinessRules = userBusinessRules;
            _mapper = mapper;
        }

        public async Task<UpdatedUserDto> Handle(UpdateUserCommand request, CancellationToken cancellationToken) {
            await _userBusinessRules.UserShouldExistWhenRequestId(request.Id);

            User mappedUser = _mapper.Map<User>(request);
            User updatedUser = await _userRepository.UpdateAsync(mappedUser);

            UpdatedUserDto updatedUserDto = _mapper.Map<UpdatedUserDto>(updatedUser);
            updatedUserDto.Message = UserMessageConstants.Updated;

            return updatedUserDto;
        }
    }
}