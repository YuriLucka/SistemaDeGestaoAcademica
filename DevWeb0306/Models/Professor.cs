using System.ComponentModel.DataAnnotations;

namespace DevWeb0306.Models
{
    public class Professor
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        [Display(Name = "CPF")]
        public string Cpf { get; set; } = string.Empty;
    }
}