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
        public UserService (IUserRepository userRepository, IRoleRepository roleRepository, PasswordHasher<User> passwordHasher, IUnitOfWork uow)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
            _passwordHasher = passwordHasher;
            _uow = uow;
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

            var newUser = User.Create(request, passwordHash);

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

            user.Rename(request.FullName);
            user.ChangeDateOfBirth(request.DayOfBirth);
            user.ChangeAddress(request.Address);
            user.UpdateRoles(request.Roles);

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
            user.Unlock();
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
            user.Lock();
            _userRepository.Update(user);

            await _uow.SaveChangesAsync();
        }
    }
}
