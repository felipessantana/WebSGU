using API_CRUD.Data;
using API_CRUD.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_CRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly ApiCrudDBContext _dBContext;
        public UsuarioController(ApiCrudDBContext apiCrudDBContex)
        {
            _dBContext = apiCrudDBContex;
        }


        [HttpGet, Route("listAll")]
        public async Task<IActionResult> BuscarTodosUsuariosAsync()
        {
            List<UsuarioModel> model = await _dBContext.Usuarios.ToListAsync();

            return Ok(model);
        }


        [HttpGet, Route("listUserID")]
        public async Task<UsuarioModel> BuscarPorId(int IdUsuario)
        {
            return await _dBContext.Usuarios.FirstOrDefaultAsync(x => x.IdUsuario == IdUsuario);
        }


        [HttpPost, Route("InsertUser")]
        public IActionResult Adicionar(UsuarioModel usuario)
        {
            _dBContext.Usuarios.Add(usuario);
            _dBContext.SaveChanges();
            return Ok(usuario);
        }



        [HttpPost, Route("UpdateUser")]
        public async Task<UsuarioModel> Atualizar(UsuarioModel usuario)
        {
            UsuarioModel usuarioPorId = await _dBContext.Usuarios.FirstOrDefaultAsync(x => x.IdUsuario == usuario.IdUsuario);
            if (usuarioPorId == null)
            {
                throw new Exception("Usuario para o ID: {IdUsuario} não foi encontrado no banco de dados.");

            }
            usuarioPorId.NomeCompleto = usuario.NomeCompleto;
            usuarioPorId.CpfUsuario = usuario.CpfUsuario;
            usuarioPorId.TelefoneUsuario = usuario.TelefoneUsuario;
            usuarioPorId.EmailUsuario = usuario.EmailUsuario;
            usuarioPorId.DataDeCriacao = usuario.DataDeCriacao;
            usuarioPorId.StatusUsuario= usuario.StatusUsuario;

            _dBContext.Usuarios.Update(usuarioPorId);
            _dBContext.SaveChanges();

            return usuarioPorId;


        }
        [HttpDelete, Route("DeleteUser")]
        public async Task<bool> Apagar(int IdUsuario)
        {
            UsuarioModel usuarioPorId = await BuscarPorId(IdUsuario);
            if (usuarioPorId == null)
            {
                throw new Exception("Usuario para o ID: {IdUsuario} não foi encontrado no banco de dados.");

            }
            _dBContext.Usuarios.Remove(usuarioPorId);
            _dBContext.SaveChanges();
            return true;


        }


    }
}
