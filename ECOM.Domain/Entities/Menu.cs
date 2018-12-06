

namespace ECOM.Domain.Entities
{
    public class Menu
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public string Area { get; set; }
        public string Descricao { get; set; }
    }
}
