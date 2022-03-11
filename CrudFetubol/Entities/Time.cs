using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CrudFutebol.Entities
{
    public class Time
    {
        [Key]
        [Display(Name = "Id")]
        public int TimeId { get; set; }

        [Required]
        [Display(Name = "Nome do Time")]
        [StringLength(25, ErrorMessage = "O nome deve ter entre 1 à 70 caracteres")]
        public string Nome { get; set; }
    }
}
