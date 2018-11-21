using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebMVC.Models
{
    public class PedidoMVC
    {
        [Key]
        public int idPedido { get; set; }

        [DisplayName("Nome Medicamento")]
        [Required]
        public string nomeMedicamento { get; set; }

        [DisplayName("Quantidade")]
        [Required]
        public string qntdeMedicamento { get; set; }

        [DisplayName("Cód. Cliente")]
        [Required]
        public string codCliente { get; set; }
        
        [DisplayName("Data Entrega")]
        [Required]
        [DataType(DataType.DateTime)]
        //O Datatype solicitado foi o DATE e não DateTime
        public DateTime dataEntrega { get; set; }
    }
}