using API_CRUD.Model;
using API_CRUD.Repositorio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace API_CRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioRepositorio _usuarioRepositorio;

        public UsuarioController()
        {
            _usuarioRepositorio = new UsuarioRepositorio();
        }

        [HttpGet]
        public ActionResult<IEnumerable<Usuario>> Get()
        {

            return _usuarioRepositorio.GetUsuarios;
        }

        [HttpGet("{id_usuario}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }
        [HttpPost]
        public void Post([FromBody] Usuario usuario)
        {
            _usuarioRepositorio.InserirUsuario(usuario);
        }

        [HttpPut("{id_usuario}")]
        public void Put(int id_usuario, [FromBody] string value)

        {

        }
        [HttpDelete("{id_usuario}")]
        public void Delete(int id_usuario)
        {
        }
    }
}
