using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SIGE_INICIO_C__API.Dtos.User;
using SIGE_INICIO_C__API.models;

namespace SIGE_INICIO_C__API.Mappers
{
    public static class UserMappers
    {
        public static UserDto ToUserDto(this User user)
        {
            return new UserDto
            {
                Id = user.Id,
                UserId = user.UserId,
                Name = user.Name,
                LastName = user.LastName,
                Privileges = user.Privileges,
                Password = user.Password,
                Areas = user.Areas,
            };
        }

        public static User ToUserFromCreateDTO(this CreateUserRequestDto userDto)
        {
            return new User
            {
                UserId = userDto.UserId,
                Name = userDto.Name,
                LastName = userDto.LastName,
                Privileges = userDto.Privileges,
                Password = userDto.Password,
                Areas = userDto.Areas,
            };
        }
    }
}