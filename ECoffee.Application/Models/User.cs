using ECoffee.Application.DTOs.Request;
using ECoffee.Application.Enums;
using ECoffee.Application.Exceptions;
using ECoffee.Application.ValueObjects;

namespace ECoffee.Application.Models
{
    public class User : BaseDomain
    {
        public Email Email { get; private set; } 
        public Password PasswordHash { get; private set; } 
        public string FullName { get; private set; } 
        public string Address { get; private set; } 
        public DateOnly DateOfBirth { get; private set; }
        public UserStatus Status { get; private set; }
        public List<string> Roles { get; private set; } 

        private User(string email, string passwordHash, string? password, string fullName, string address, DateOnly dob, 
            UserStatus status, IEnumerable<string> roles, string createdBy, string updatedBy, DateTime createdAt, DateTime updatedAt)
        {
            Email = new Email(email);
            PasswordHash = new Password(passwordHash, password);
            FullName = fullName;
            Address = address;
            DateOfBirth = dob;
            Status = status;
            Roles = roles.ToList();
            CreatedBy = createdBy;
            UpdatedBy = updatedBy;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }

        public static User Create (CreateUserRequest request, string passwordHash, string? password, string audit)
        {
            return new User(request.Email, passwordHash, password, request.FullName, request.Address, request.DayOfBirth, 
                UserStatus.Activate, new List<string>(), audit, audit, DateTime.Now, DateTime.Now);
        }

        public static User Rehydrate(long id, string email, string passwordHash, string? password, string fullName, 
            string address, DateOnly dob, UserStatus status, IEnumerable<string> roles, string createdBy, string updatedBy, 
            DateTime createdAt, DateTime updatedAt)
        {
            var user = new User(email, passwordHash, password, fullName, address, dob, status, roles, createdBy, updatedBy, createdAt, updatedAt);
            user.Id = id;
            return user;
        }

        public void Rename (string fullName, string updatedBy) 
        {
            FullName = fullName;
            Touch(updatedBy);
        }

        public void ChangeAddress (string address, string updatedBy) 
        { 
            Address = address;
            Touch(updatedBy);
        }

        public void ChangeDateOfBirth(DateOnly newDateOfBirth, string updatedBy) { 
            DateOfBirth = newDateOfBirth;
            Touch(updatedBy);
        }

        public void Lock(string updatedBy)
        {
            Status = UserStatus.Locked;
            Touch(updatedBy);
        }

        public void Unlock(string updatedBy) {
            Status = UserStatus.Activate;
            Touch(updatedBy);
        }

        public void UpdateRoles(List<string> roles, string updatedBy)
        {
            Roles = roles.ToList();
            Touch(updatedBy);
        }

        private void Touch(string updatedBy)
        {
            UpdatedBy = updatedBy;
            UpdatedAt = DateTime.Now;
        }
    }
}
