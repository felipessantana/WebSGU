namespace AplicacaoWeb.Models
{
    public class UsuarioModel
    {
  

        public int IdUsuario { get; set; }
        public string NomeCompleto { get; set; }
        public string CpfUsuario { get; set; }
        public string TelefoneUsuario { get; set; }
        public string EmailUsuario { get; set; }

        public DateTime DataDeCriacao { get; set; }
        public int StatusUsuario { get; set; }


   
    }
}
