using System;

namespace ECOM.Domain.Entities
{
    public class Login
    {
        public int Id { get; set; }
        public int  ClienteId { get; set; }
        public virtual Cliente Cliente { get; set; }
        public string Password { get; set; }
        public bool IsAdm { get; set; }
    }
}
