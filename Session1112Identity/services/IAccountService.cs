using Microsoft.AspNetCore.Identity;
using Session1112Identity.Models;

namespace Session1112Identity.services
{
    public interface IAccountService
    {
        Task<IdentityResult> CreateAccount(SignUp signUp);
        Task<SignInResult> SignIn(SignIn signIn);
        Task Logout();

        Task<IdentityResult> AddRole(Role role);

        List<UsersDTO> getUsers();

        Task<List<UserRoles>> getRoles(string UserId);


		Task UpdateUserRoles(List<UserRoles> liUserRoles);

	}
}
