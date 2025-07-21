using System.ComponentModel.DataAnnotations;

namespace EW_Exame.Models
{
    public class Categoria
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório.")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "O nome deve ter entre 5 e 20 caracteres.")]
        [RegularExpression(@"^\S{5,20}$", ErrorMessage = "O nome não pode conter espaços.")]
        public string Nome { get; set; } = string.Empty; 

        public ICollection<Produto> Produtos { get; set; } = new List<Produto>(); 
    }
}
