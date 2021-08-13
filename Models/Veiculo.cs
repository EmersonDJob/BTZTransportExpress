using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using BTZTransportExpress.Models.Enums;

namespace BTZTransportExpress.Models
{
    public class Veiculo
    {
        [Key]
        [Required(ErrorMessage = "Este Campo é obrigatório")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Este Campo é obrigatório")]
        [Display(Name = "Placa do Veiculo")]
        public string Placa { get; set; }
        [Required(ErrorMessage = "Este Campo é obrigatório")]
        [Display(Name = "Marca do Veiculo")]
        public string NomeVeiculo { get; set; }
        [Required(ErrorMessage = "Este Campo é obrigatório")]
        [Display(Name = "Tipo de Combustivel")]
        public TipoCombustivel TipoCombustivel { get; set; }
        [Required(ErrorMessage = "Este Campo é obrigatório")]
        [Display(Name = "Fabricante")]
        public string Fabricante { get; set; }
        [Required(ErrorMessage = "Este Campo é obrigatório")]
        [Display(Name = "Ano de Fabricacao")]
        public DateTime AnoFabricacao { get; set; }
        [Required(ErrorMessage = "Este Campo é obrigatório")]
        [Display(Name = "Capacidade do tanque")]
        public float MaxTanque { get; set; }
    }
}
