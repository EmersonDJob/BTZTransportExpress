using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BTZTransportExpress.Models.Enums;

namespace BTZTransportExpress.Models
{
    public class Abastecimento
    {
        [Key]
        public int Id { get; set; }
       
        public int VeiculoId { get; set; }
        [ForeignKey("VeiculoId")]
        [Display(Name = "Veiculo")]
        public virtual Veiculo Veiculo { get; set; }


        public int MotoristaId { get; set; }
        [ForeignKey("MotoristaId")]
        [Display(Name = "Motorista")]
        public virtual Motorista Motorista { get; set; }
        [Display(Name = "Data de Abastecimento")]
        public DateTime Data { get; set; }
        [Display(Name = "Tipo de Combustivel")]
        public TipoCombustivel TipoCombustivel { get; set; }
        [Display(Name = "Quantidade Abastecida")]
        public double QuantidadeCombustivel { get; set; }
        [DisplayFormat(DataFormatString = "{0:C}")]
        [Display(Name = "Valor  Abastecido")]
        public double ValorTotal { get; set; }
    }
}
