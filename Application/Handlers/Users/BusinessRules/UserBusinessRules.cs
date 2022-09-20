using Application.Handlers.Users.Constants;
using Application.Repositories;
using Domain.Entities;

namespace Application.Handlers.Users.BusinessRules;
internal class UserBusinessRules {
    private readonly IUserRepository _userRepository;

    public UserBusinessRules(IUserRepository userRepository) {
        this._userRepository = userRepository;
    }

    public async Task UserIdentityNumberCanNotBeDuplicatedWhenInserted(String identityNumber) {
        IQueryable<User> result = await _userRepository
            .GetWhereAsync(x => x.IdentityNumber.Equals(identityNumber), enableTracking: false);
        if(result.Any())
            throw new Exception(UserMessageConstants.AlredyExist);
    }

    public Task UserShouldExistWhenRequest(User? user) {
        _ = user ?? throw new Exception(UserMessageConstants.NotFound);
        return Task.CompletedTask;
    }

    public async Task UserShouldExistWhenRequestId(Guid id) {
        _ = await _userRepository.GetByIdAsync(id, enableTracking: false)
            ?? throw new Exception(UserMessageConstants.NotFound);
    }
}