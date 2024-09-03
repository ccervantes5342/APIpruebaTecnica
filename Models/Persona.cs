using System.ComponentModel.DataAnnotations;

namespace ApiPruebaTec.Models
{
    public class Persona
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [StringLength(100, ErrorMessage = "El nombre no puede exceder los 100 caracteres.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El email es obligatorio.")]
        [EmailAddress(ErrorMessage = "El formato del email no es válido.")]
        public string Email { get; set; }

        [Range(0, 120, ErrorMessage = "La edad debe estar entre 0 y 120 años.")]
        public int Edad { get; set; }
    }
}
