using System.ComponentModel.DataAnnotations;

namespace SIGE_INICIO_C__API.Dtos.User
{
    public class CreateUserRequestDto
    {
        [Required(ErrorMessage = "El usuario es requerido")]
        [MinLength(3, ErrorMessage = "El usuario debe tener mas de 3 caracteres")]
        [MaxLength(280, ErrorMessage = "El usuario no debe tener mas de 280 caracteres")]
        public string UserId { get; set; } = null!;
        [Required(ErrorMessage = "El nombre es requerido")]
        [MinLength(3, ErrorMessage = "El nombre debe tener mas de 3 caracteres")]
        [MaxLength(280, ErrorMessage = "El nombre no debe tener mas de 280 caracteres")]
        public string Name { get; set; } = null!;
        [Required(ErrorMessage = "El apellido es requerido")]
        [MinLength(3, ErrorMessage = "El apellido debe tener mas de 3 caracteres")]
        [MaxLength(280, ErrorMessage = "El apellido no debe tener mas de 280 caracteres")]
        public string? LastName { get; set; }
        public List<string>? Privileges { get; set; }
        public string? Password { get; set; }
        public List<String>? Areas { get; set; }
    }
}