using Application.Abstractions.Common;
using Application.Contracts.Login.DTO;
using Domain.Primitives.Maybe;
using Domain.Primitives.Result;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Identity
{
    public class IdentityService : IIdentityService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IUserClaimsPrincipalFactory<AppUser> _userClaimsPrincipalFactory;
        private readonly IAuthorizationService _authorizationService;

        public IdentityService(UserManager<AppUser> userManager,IUserClaimsPrincipalFactory<AppUser> userClaimsPrincipalFactory
            ,IAuthorizationService authorizationService)
        {
            _userManager = userManager;
            _userClaimsPrincipalFactory = userClaimsPrincipalFactory;
            _authorizationService = authorizationService;
        }
        public Task<bool> AuthorizeAsync(string userId, string policyName)
        {
            throw new NotImplementedException();
        }

        public Task<(Result Result, string UserId)> CreateUserAsync(string userName, string password)
        {
            throw new NotImplementedException();
        }

        public Task<Result> DeleteUserAsync(string userId)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetUserNameAsync(string userId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsInRoleAsync(string userId, string role)
        {
            throw new NotImplementedException();
        }

        public async Task<Maybe<UserResponse>> ValidateUser(LoginRequest credentials)
        {
            Maybe<UserResponse> userResult = Maybe<UserResponse>.None;

            var user = await _userManager.FindByNameAsync(credentials.userName);
            if(user is null) {
                user = await _userManager.FindByEmailAsync(credentials.userName);
            }
            
            if(user is not null)
            {
                var result =await _userManager.CheckPasswordAsync(user, credentials.password);
                if (!result)
                {
                    return userResult;
                }
 
                var response = new UserResponse
                {
                    FirstName = user.FirstName,
                    LastName    = user.LastName,    
                    UserId= user.Id,    
                    UserName    =user.UserName,
                    Roles=user.UserRoles?.Select(x=>x.Role.Name)?.ToList(),
                    CompanyId= user.UserCompany.Select(x => x.CompanyId).First()
            };
                return response;

            }

            return userResult;
        }
    }
}
