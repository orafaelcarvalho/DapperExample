using System.ComponentModel.DataAnnotations;

namespace CarrosAPI.Models
{
    public class Carro
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo descrição é obrigatório")]
        [StringLength(45, ErrorMessage = "O campo descrição deve ter no máximo 45 caracteres")]
        public string Descricao { get; set; }
        [Required(ErrorMessage = "O campo marca é obrigatório")]
        [StringLength(45, ErrorMessage = "O campo marca deve ter no máximo 45 caracteres")]
        public string Marca { get; set;}
        [Required(ErrorMessage = "O campo valor é obrigatório")]
        public double Valor { get; set; }
    }
}
