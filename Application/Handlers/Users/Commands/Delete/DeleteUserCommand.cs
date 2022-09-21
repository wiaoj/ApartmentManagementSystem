using Application.Handlers.Users.BusinessRules;
using Application.Handlers.Users.Constants;
using Application.Handlers.Users.Dtos.Commands;
using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Handlers.Users.Commands.Delete;

public class DeleteUserCommand : IRequest<DeletedUserDto> {
    public Guid Id { get; set; }

    internal class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, DeletedUserDto> {
        private readonly IUserRepository _userRepository;
        private readonly UserBusinessRules _userBusinessRules;
        private readonly IMapper _mapper;

        public DeleteUserCommandHandler(IUserRepository userRepository, UserBusinessRules userBusinessRules, IMapper mapper) {
            _userRepository = userRepository;
            _userBusinessRules = userBusinessRules;
            _mapper = mapper;
        }

        public async Task<DeletedUserDto> Handle(DeleteUserCommand request, CancellationToken cancellationToken) {
            await _userBusinessRules.UserShouldExistWhenRequestId(request.Id);

            User mappedUser = _mapper.Map<User>(request);
            User deletedUser = await _userRepository.DeleteAsync(mappedUser.Id);

            DeletedUserDto deletedUserDto = _mapper.Map<DeletedUserDto>(deletedUser);
            deletedUserDto.Message = UserMessageConstants.Deleted;

            return deletedUserDto;
        }
    }
}