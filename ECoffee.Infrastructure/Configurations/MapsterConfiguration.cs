using ECoffee.Application.DTOs.Request;
using ECoffee.Application.DTOs.Response;
using ECoffee.Application.Models;
using ECoffee.Application.Repositories;
using ECoffee.Infrastructure.Entities;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECoffee.Infrastructure.Configurations
{
    public static class MapsterConfiguration
    {
        public static void Configure()
        {
            TypeAdapterConfig<User, UserEntity>.NewConfig()
                .Map(dest => dest.PasswordHash, src => src.PasswordHash.HashedValue);

            //TypeAdapterConfig<CreateUserRequest, User>.NewConfig()
            //    .IgnoreNullValues(true); // ví dụ ignore null
        }
    }
}
