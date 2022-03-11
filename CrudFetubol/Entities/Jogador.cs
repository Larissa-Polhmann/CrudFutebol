using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CrudFutebol.Entities
{
    public class Jogador
    {
        [Key]
        [Display(Name = "Id")]
        public int JogadorId { get; set; }

        [Required]
        [Display(Name = "Nome do Jogador")]
        [StringLength(25, ErrorMessage = "O nome deve ter entre 1 à 100 caracteres")]
        public string Nome { get; set; }

        [Required]
        [Display(Name = "Posição do Jogador")]
        [StringLength(25, ErrorMessage = "A posição deve ter entre 1 à 20 caracteres")]
        public string Posicao { get; set; }
    }
}
