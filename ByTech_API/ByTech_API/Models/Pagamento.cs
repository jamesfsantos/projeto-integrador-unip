namespace ByTech_API.Models
{
    public class Pagamento
    {
        public int Id { get; set; }
        public int VendaId { get; set; }
        public string Metodo { get; set; }
        public string Status { get; set; }
        public DateTime DataConfirmacao { get; set; }
    }
}
