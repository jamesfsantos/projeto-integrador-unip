using System.Diagnostics.CodeAnalysis;

namespace ByTech_API.Models
{
    public class MensagensContato
    {
        public int Id { get; set; }

        [AllowNull]
        public int UsuarioId { get; set; }
        
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Celular { get; set; }
        public string Mensagem { get; set; }
        public DateTime Data_Envio { get; set; }

        public Usuarios Usuario { get; set; }
    }
}
