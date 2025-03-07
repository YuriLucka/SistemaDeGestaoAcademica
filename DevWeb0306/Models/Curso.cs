using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace DevWeb0306.Models
{
    public class Curso
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        [Display(Name = "Eixo")]
        public int EixoId { get; set; }
        [ValidateNever]
        public virtual Eixo Eixo { get; set; } = null!;
    }
}
