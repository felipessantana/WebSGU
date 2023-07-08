using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsumindoAPI.Entities
{
    internal class Usuario
    {
        public int id_usuario { get; set; }
        public string nome_completo { get; set; }
        public string cpf { get; set; }
        public string telefone { get; set; }
        public string email { get; set; }

        public string data_de_criacao { get; set; }
        public string ativo { get; set; }

        public bool Vericacao = false;
    }
}
