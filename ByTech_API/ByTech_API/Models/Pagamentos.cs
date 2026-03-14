namespace ByTech_API.Models
{
    public class Pagamentos
    {
        public int Id { get; set; }
        public int VendaId { get; set; }
        public string Metodo { get; set; }
        public string Status { get; set; }
        public DateTime Data_Confirmacao { get; set; }
    }
}
