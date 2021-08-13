using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using BTZTransportExpress.Models.Enums;

namespace BTZTransportExpress.Models
{
    public class Motorista
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Nome Completo")]
        [Required(ErrorMessage = "Este Campo é obrigatório")]
        public string Nome { get; set; }
        [Display(Name = "CPF")]
        [StringLength(11)]
        [Required(ErrorMessage = "Este Campo é obrigatório")]
        public string CPF { get; set; }       
        [StringLength(11)]
        [Display(Name = "Numero da CNH")]
        [Required(ErrorMessage = "Este Campo é obrigatório")]        
        public string CNH { get; set; }
        [Display(Name = "Categoria de CNH")]
        [StringLength(20, MinimumLength = 10)]
        [Required(ErrorMessage = "Este Campo é obrigatório")]
        public CategoriaCNH CategoriaCNH { get; set; }
        [Display(Name = "Data de Nascimento")]
        [Required(ErrorMessage = "Este Campo é obrigatório")]
        public DateTime DataNascimento { get; set; }

        public bool Status { get; set; }
    }
}
