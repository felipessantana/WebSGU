using API_CRUD.Dao;
using API_CRUD.Model;
using System.Collections.Generic;

namespace API_CRUD.Repositorio
{
    public class UsuarioRepositorio
    {
        private readonly DaoUsuario _daoUsuario;
        public UsuarioRepositorio()
        {
            _daoUsuario = new DaoUsuario();
        }

        public List<Usuario> GetUsuarios
        {
            get
            {
                return _daoUsuario.GetUsuarios();
            }
        }
        public void InserirUsuario(Usuario usuario)
        {
            _daoUsuario.InserUsuario(usuario);
        }
    }
}
