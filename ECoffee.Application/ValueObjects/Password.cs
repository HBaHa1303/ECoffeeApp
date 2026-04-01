using ECoffee.Application.Exceptions;
using System.Text.RegularExpressions;

namespace ECoffee.Application.ValueObjects
{
    public class Password : IEquatable<Password>
    {
        public string HashedValue { get; }

        public Password(string hashedValue, string? plainText = null)
        {
            if (string.IsNullOrWhiteSpace(hashedValue))
                throw new BadRequestException("Password không được rỗng");

            if (plainText is not null)
            {
                ValidateStrength(plainText);
            }

            HashedValue = hashedValue;
        }

        private static void ValidateStrength(string password)
        {
            if (password.Length < 8)
                throw new BadRequestException("Password phải có ít nhất 8 ký tự");

            if (!Regex.IsMatch(password, @"[A-Z]"))
                throw new BadRequestException("Password phải có ít nhất 1 chữ hoa");

            if (!Regex.IsMatch(password, @"[a-z]"))
                throw new BadRequestException("Password phải có ít nhất 1 chữ thường");

            if (!Regex.IsMatch(password, @"\d"))
                throw new BadRequestException("Password phải có ít nhất 1 số");

            if (!Regex.IsMatch(password, @"[\W_]"))
                throw new BadRequestException("Password phải có ít nhất 1 ký tự đặc biệt");
        }

        public bool Equals(Password? other)
        {
            if (other is null) return false;
            return HashedValue == other.HashedValue;
        }

        public override bool Equals(object? obj) => Equals(obj as Password);
        public override int GetHashCode() => HashedValue.GetHashCode();
    }
}