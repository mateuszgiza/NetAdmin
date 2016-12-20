using NetAdmin.Common.Abstractions;

namespace NetAdmin.Application
{
    public interface IUserService : IService
    {
        void Register(CreateUserRequest request);
        UserLoginResponse SignIn(UserLoginRequest request);
    }
}