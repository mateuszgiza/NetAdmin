using NetAdmin.DataAccess;
using NetAdmin.Infrastructure;

namespace NetAdmin.Application
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ICryptoService _cryptoService;

        public UserService(IUserRepository userRepository, ICryptoService cryptoService)
        {
            _userRepository = userRepository;
            _cryptoService = cryptoService;
        }

        public void Register(CreateUserRequest request)
        {
            var salt = _cryptoService.GenerateSalt();
            var hashedPassword = _cryptoService.HashPassword(request.Password, salt);

            var user = new User
            {
                Username = request.Username,
                Salt = salt,
                Password = hashedPassword
            };

            _userRepository.Add(user);
        }

        public UserLoginResponse SignIn(UserLoginRequest request)
        {
            var response = new UserLoginResponse();

            var dbUser = _userRepository.GetByName(request.Username);
            var isPasswordCorrect = _cryptoService.VerifyPassword(request.Password, dbUser.Salt, dbUser.Password);

            response.Successfull = isPasswordCorrect;

            return response;
        }
    }
}