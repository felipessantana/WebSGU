using ConsumindoAPI.Entities;
using ConsumindoAPI.Services;

namespace ConsumindoAPI
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            Console.WriteLine("informe o id: ");
            int id_usuario = int.Parse(Console.ReadLine());

            UsuarioServices usuarioServices = new UsuarioServices();
            Usuario usuarioEncontrado = await usuarioServices.Integracao(id_usuario);

            if (!usuarioEncontrado.Vericacao)
            {
                Console.WriteLine("Usuario Encontrado");
                Console.WriteLine("Nome:" +usuarioEncontrado.nome_completo);
                Console.WriteLine("CPF:" + usuarioEncontrado.cpf);
                Console.WriteLine("Telefone:" + usuarioEncontrado.telefone);
                Console.WriteLine("E-mail:" + usuarioEncontrado.email);
                Console.WriteLine("Situação:" + usuarioEncontrado.ativo);
                Console.WriteLine("Data de Criação:" + usuarioEncontrado.data_de_criacao);
            }
            else
            {
                Console.WriteLine("Usuario não Encontrado");
            }
        }
    }
}