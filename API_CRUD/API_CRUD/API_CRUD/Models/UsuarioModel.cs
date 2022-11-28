

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_CRUD.Model
{
    [Table("Usuario")]
    public class UsuarioModel
    {
       
       
        [Key]
        public int IdUsuario { get; set; }
        public string NomeCompleto { get; set; }
        public string CpfUsuario { get; set; }
        public string TelefoneUsuario { get; set; }
        public string EmailUsuario { get; set; }

        public DateTime DataDeCriacao { get; set; }
        public int StatusUsuario { get; set; }
    }
}
