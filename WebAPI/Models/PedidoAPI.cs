using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class PedidoAPI
    {
        [Key]
        public int idPedido { get; set; }
        public string nomeMedicamento { get; set; }
        public string qntdeMedicamento { get; set; }
        public string codCliente { get; set; }
        public DateTime dataEntrega { get; set; }
    }
}