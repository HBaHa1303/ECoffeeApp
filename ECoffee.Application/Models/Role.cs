using ECoffee.Application.DTOs.Request;
using ECoffee.Application.Exceptions;
using ECoffee.Application.ValueObjects;

namespace ECoffee.Application.Models
{
    public class Role : BaseDomain
    {
        public string Name { get; private set; } 
    }
}
