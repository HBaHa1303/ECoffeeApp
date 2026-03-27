using ECoffee.Application.DTOs.Request;
using ECoffee.Application.DTOs.Response;
using ECoffee.Application.Exceptions;
using ECoffee.Application.Models;
using ECoffee.Application.Repositories;
using Mapster;
using Microsoft.AspNetCore.Identity;

namespace ECoffee.Application.Services
{
    public class AuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly PasswordHasher<User> _passwordHasher;
        private readonly IUserContext _userContext;

        public AuthService(IUserRepository userRepository, PasswordHasher<User> passwordHasher, IUserContext userContext)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
            _userContext = userContext;
        }

        public void Login (LoginRequest request)
        {
            User? user = _userRepository.FindByEmail(request.Email);

            if (user == null) {
                throw new NotFoundException("Email không tồn tại trong hệ thống");
            }

            var result = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash.HashedValue, request.Password);

            if (result == PasswordVerificationResult.Failed)
                throw new UnauthorizedException("Email hoặc mật khẩu không chính xác! Vui lòng thử lại");
            _userContext.SetCurrentUser(user.Adapt<UserResponse>());
        }
    }
}
