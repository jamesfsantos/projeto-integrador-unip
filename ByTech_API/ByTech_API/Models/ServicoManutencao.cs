namespace ByTech_API.Models
{
    public class ServicoManutencao
    {
        public int Id { get; set; }
        public string Protocolo { get; set; }
        public int ClienteId { get; set; }
        public int TecnicoId { get; set; }
        public string Equipamento { get; set; }
        public string Descricao_Problema { get; set; }
        public string Observacoes_Tecnicas { get; set; }
        public string Status_Servico {  get; set; }
        public DateTime Data_Entrada { get; set; }

        public virtual Usuarios Cliente { get; set; }
        public virtual Usuarios Tecnico { get; set; }
    }
}
