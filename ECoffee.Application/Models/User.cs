using ECoffee.Application.DTOs.Request;
using ECoffee.Application.Enums;
using ECoffee.Application.Exceptions;
using ECoffee.Application.ValueObjects;

namespace ECoffee.Application.Models
{
    public class User : BaseDomain
    {
        public Email Email { get; private set; } 
        public string PasswordHash { get; private set; } 
        public string FullName { get; private set; } 
        public string Address { get; private set; } 
        public DateOnly DateOfBirth { get; private set; }
        public UserStatus Status { get; private set; }
        public List<string> Roles { get; private set; } 

        private User(string email, string passwordHash, string fullName, string address, DateOnly dob, UserStatus status, IEnumerable<string> roles)
        {
            Email = new Email(email);
            PasswordHash = passwordHash;
            FullName = fullName;
            Address = address;
            DateOfBirth = dob;
            Status = status;
            Roles = roles.ToList();
        }

        public static User Create (CreateUserRequest request, string passwordHash)
        {
            return new User(request.Email, passwordHash, request.FullName, request.Address, request.DayOfBirth, UserStatus.Activate, new List<string>());
        }

        public static User Rehydrate( long id, string email, string passwordHash, string fullName, string address, DateOnly dob, UserStatus status, IEnumerable<string> roles)
        {
            var user = new User(email, passwordHash, fullName, address, dob, status, roles);
            user.Id = id;
            return user;
        }

        public void Rename (string fullName) 
        {
            FullName = fullName;
        }

        public void ChangeAddress (string address) 
        { 
            Address = address; 
        }

        public void ChangeDateOfBirth(DateOnly newDateOfBirth) { 
            DateOfBirth = newDateOfBirth;
        }

        public void Lock()
        {
            Status = UserStatus.Locked;
        }

        public void Unlock() {
            Status = UserStatus.Activate;
        }

        internal void UpdateRoles(List<string> roles)
        {
            Roles = roles.ToList();
        }
    }
}
