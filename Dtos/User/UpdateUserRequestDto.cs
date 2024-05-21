using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIGE_INICIO_C__API.Dtos.User
{
    public class UpdateUserRequestDto
    {
        public string UserId { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string? LastName { get; set; }
        public List<string>? Privileges { get; set; }
        public string? Password { get; set; }
        public List<String>? Areas { get; set; }
    }
}