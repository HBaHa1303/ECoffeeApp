using ECoffee.Application.DTOs.Request;
using ECoffee.Application.DTOs.Response;
using ECoffee.Application.Exceptions;
using ECoffee.Application.Models;
using ECoffee.Application.Repositories;
using Mapster;
using Microsoft.AspNetCore.Identity;

namespace ECoffee.Application.Services
{
    public class UserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly PasswordHasher<User> _passwordHasher;
        private readonly IUnitOfWork _uow;
        private readonly IUserContext _userContext;
        private readonly string currentUser;

        public UserService (IUserRepository userRepository, 
            IRoleRepository roleRepository, 
            PasswordHasher<User> passwordHasher, 
            IUnitOfWork uow,
            IUserContext userContext
            )
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
            _passwordHasher = passwordHasher;
            _uow = uow;
            _userContext = userContext;
            currentUser = _userContext.CurrentUser?.Email;
        }

        public async Task CreateUserAsync(CreateUserRequest request)
        {
            User? user = _userRepository.FindByEmail(request.Email);

            if (user != null)
            {
                throw new ConflictException("Email đã tồn tại trong hệ thống");
            }

            List<Role> roles = _roleRepository.GetByNames(request.Roles);

            if (roles.Count != request.Roles.Count)
                throw new NotFoundException("Role không tồn tại");

            string passwordHash = _passwordHasher.HashPassword(null, request.Password);

            var newUser = User.Create(request, passwordHash, request.Password, currentUser);

            _userRepository.Save(newUser, roles);
            await _uow.SaveChangesAsync();
        }

        public UserResponse FindUserById(long id) {
            UserResponse? user = _userRepository.ProjectionFindById(id);

            if (user == null)
            {
                throw new NotFoundException("Người dùng không tồn tại trong hệ thống");
            }

            return user;
        }

        public Task<List<UserResponse>> FindAllAsync() => Task.FromResult(_userRepository.FindAll());

        public async Task UpdateUserAsync(long id, UpdateUserRequest request)
        {
            User? user = _userRepository.FindById(id);

            if (user == null) throw new NotFoundException("Người dùng không tồn tại trong hệ thống");

            user.Rename(request.FullName, currentUser);
            user.ChangeDateOfBirth(request.DayOfBirth, currentUser);
            user.ChangeAddress(request.Address, currentUser);
            user.UpdateRoles(request.Roles, currentUser);

            _userRepository.Update(user);
            await _uow.SaveChangesAsync();
        }

        public async Task UnlockAsync(long id)
        {
            User? user = _userRepository.FindById(id);

            if (user == null)
            {
                throw new NotFoundException("Người dùng không tồn tại trong hệ thống");
            }
            user.Unlock(currentUser);
            _userRepository.Update(user);

            await _uow.SaveChangesAsync();
        }

        public async Task LockAsync(long id)
        {
            User? user = _userRepository.FindById(id);

            if (user == null)
            {
                throw new NotFoundException("Người dùng không tồn tại trong hệ thống");
            }
            user.Lock(currentUser);
            _userRepository.Update(user);

            await _uow.SaveChangesAsync();
        }
    }
}
