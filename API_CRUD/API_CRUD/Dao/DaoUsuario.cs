using API_CRUD.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace API_CRUD.Dao
{
    public class DaoUsuario
    {
        string conexao = @"Data Source=DESKTOP-SNACR73\SQLEXPRESS;Initial Catalog=db_usuario;Integrated Security=True";

        public List<Usuario> GetUsuarios()
        {
            List<Usuario> usuarios = new List<Usuario>();
            using (SqlConnection conn = new SqlConnection(conexao))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(@"GetUsuarios", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader != null)
                        {
                            while (reader.Read())
                            {
                                var usuario = new Usuario();
                                usuario.nome_completo = reader["nome_completo"].ToString();
                                usuario.cpf = reader["cpf"].ToString();
                                usuario.telefone = reader["telefone"].ToString();
                                usuario.email = reader["email"].ToString();
                                usuario.data_de_criacao = reader["data_de_criacao"].ToString();
                                usuario.ativo = reader["ativo"].ToString();
                                

                                usuarios.Add(usuario);


                            }
                        }
                    }
                }
            }
            return usuarios;
        }
        public void InserUsuario(Usuario usuario)
        {
            List<Usuario> usuarios = new List<Usuario>();
            using (SqlConnection conn = new SqlConnection(conexao))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(@"InseUsuarios", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                   
                    cmd.Parameters.AddWithValue("@nome_completo", usuario.nome_completo);
                    cmd.Parameters.AddWithValue("@cpf", usuario.cpf);
                    cmd.Parameters.AddWithValue("@telefone", usuario.telefone);
                    cmd.Parameters.AddWithValue("@email", usuario.email);
                    cmd.Parameters.AddWithValue("@ativo", usuario.ativo);
                    


                    cmd.ExecuteNonQuery();
                    
                }
            }
        }
    }
}
