namespace ByTech_API.Models
{
    public class CampanhaEmail
    {
        public int Id { get; set; }
        public int AdminId { get; set; }
        public string Assunto { get; set; }
        public string CorpoMensagem { get; set; }
        public DateTime Data_Disparo { get; set; }
        public Usuarios UsuarioAdmin { get; set; }
    }
}
