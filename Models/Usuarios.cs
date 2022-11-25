using System.ComponentModel.DataAnnotations;

namespace ApiMaisEventos.Models
{
    public class Usuarios
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo Nome é Obrigatorio ")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo Email é Obrigatorio ")]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Informe um email válido")]
        public string email { get; set; }

        [Required(ErrorMessage = "O campo Senha é Obrigatorio ")]
        [MinLength(8)]
        public string senha { get; set; }
    }
}
