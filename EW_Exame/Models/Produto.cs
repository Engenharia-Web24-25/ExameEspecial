using System.ComponentModel.DataAnnotations;
using EW_Exame.Models;

public class Produto
{
    public int Id { get; set; }

    public string Nome { get; set; } = string.Empty;

    public string Descricao { get; set; } = string.Empty;

    public int CategoriaId { get; set; }

    public Categoria Categoria { get; set; } = null!;
    public string Username { get; set; } = string.Empty;

}
