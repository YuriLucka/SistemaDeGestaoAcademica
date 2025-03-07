using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace DevWeb0306.Models
{
    public class Materia
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        [Display(Name = "Curso")]
        public int CursoId { get; set; }
        [ValidateNever]
        public virtual Curso Curso { get; set; } = null!;
        [Display(Name = "Professor")]
        public int ProfessorId { get; set; }
        [ValidateNever]
        public virtual Professor Professor { get; set; } = null!;

    }
}
