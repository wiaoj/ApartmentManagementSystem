using Application.Handlers.Users.Dtos.Queries;
using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Handlers.Users.Queries.GetAll;
public class GetAllUserQuery : IRequest<IQueryable<GetAllUserDto>> {

    internal class GetAllQueryHandler : IRequestHandler<GetAllUserQuery, IQueryable<GetAllUserDto>> {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetAllQueryHandler(IUserRepository userRepository, IMapper mapper) {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<IQueryable<GetAllUserDto>> Handle(GetAllUserQuery request, CancellationToken cancellationToken) {
            IQueryable<User> mappedUsers = _userRepository.GetAll(enableTracking: false);

            IQueryable<GetAllUserDto> getAllUserDto = _mapper.ProjectTo<GetAllUserDto>(mappedUsers);

            return getAllUserDto;
        }
    }
}