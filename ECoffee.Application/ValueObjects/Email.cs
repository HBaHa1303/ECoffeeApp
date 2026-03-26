using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using System.Text.RegularExpressions;

namespace ECoffee.Application.ValueObjects
{
    public class Email
    {
        public string Value { get; private set; }

        private static readonly Regex EmailRegex = new(
            @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
            RegexOptions.Compiled | RegexOptions.IgnoreCase
        );

        public Email(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Email cannot be empty.", nameof(value));

            if (!EmailRegex.IsMatch(value))
                throw new ArgumentException("Email is not valid.", nameof(value));

            Value = value;
        }

        public override bool Equals(object? obj)
        {
            if (obj is not Email other) return false;
            return string.Equals(Value, other.Value, StringComparison.OrdinalIgnoreCase);
        }

        public override int GetHashCode()
        {
            return Value.ToLowerInvariant().GetHashCode();
        }

        public override string ToString() => Value;

        public static implicit operator string(Email email) => email.Value;
    }
}
