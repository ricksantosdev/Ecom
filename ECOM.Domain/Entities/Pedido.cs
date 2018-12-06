
using System;

namespace ECOM.Domain.Entities
{
    public class Pedido
    {
        public int Id { get; set; }
        public int CLienteId { get; set; }
        public virtual Cliente Cliente { get; set; }
        public DateTime DataPedido { get; set; }
        public decimal Total { get; set; }
    }
}
