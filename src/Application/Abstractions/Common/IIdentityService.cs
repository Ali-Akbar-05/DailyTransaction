using Domain.Primitives.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstractions.Common;

public interface IIdentityService
{
    Task<string> GetUserNameAsync(int userId);

    Task<bool> IsInRoleAsync(int userId, string role);

    Task<bool> AuthorizeAsync(int userId, string policyName);

    Task<(Result Result, int UserId)> CreateUserAsync(string userName, string password);

    Task<Result> DeleteUserAsync(int userId);
}
