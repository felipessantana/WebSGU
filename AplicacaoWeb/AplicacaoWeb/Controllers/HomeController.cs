using AplicacaoWeb.Models;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System.Diagnostics;

namespace AplicacaoWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> IndexAsync()
        {

            

            var client = new RestClient("https://localhost:7107/api/Usuario");

            var request = new RestRequest("listAll", Method.Get);
            

            List<UsuarioModel> response = await client.GetAsync<List<UsuarioModel>>(request);

            ViewBag.usuario = response;

            return View();
        }

        public async Task<IActionResult> Deletar(int id)
        {
            var client = new RestClient("https://localhost:7107/api/Usuario");

            var request = new RestRequest("DeleteUser", Method.Get);
            request.AddParameter("IdUsuario", id);

            var  response = await client.DeleteAsync(request);


            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Cadastrar(UsuarioModel? modelUsuario)
        {
            
            if (modelUsuario.NomeCompleto == null)
            {
                return View();
            }
            modelUsuario.StatusUsuario = 1;
            modelUsuario.DataDeCriacao = DateTime.Now;
            modelUsuario.CpfUsuario = modelUsuario.CpfUsuario.Replace(".", "").Replace("-", ""); 
                

            var client = new RestClient("https://localhost:7107/api/Usuario");
            
            var request = new RestRequest("InsertUser", Method.Get);
            request.AddJsonBody(modelUsuario);

            UsuarioModel response = await client.PostAsync<UsuarioModel>(request);


            return RedirectToAction("Index");

        }
        public async Task<IActionResult> Editar(int id, UsuarioModel? modelUsuario)
        {

            if(modelUsuario.NomeCompleto != null)
            {
                modelUsuario.IdUsuario = id;
                modelUsuario.DataDeCriacao = DateTime.Now;
                modelUsuario.CpfUsuario = modelUsuario.CpfUsuario.Replace(".", "").Replace("-", "");

                var client1 = new RestClient("https://localhost:7107/api/Usuario");

                var request1 = new RestRequest("UpdateUser", Method.Get);
                request1.AddJsonBody(modelUsuario);

                UsuarioModel response1 = await client1.PostAsync<UsuarioModel>(request1);
                
                return RedirectToAction("Index");
            }
            var client = new RestClient("https://localhost:7107/api/Usuario");

            var request = new RestRequest("listUserID", Method.Get);
            request.AddParameter("IdUsuario", id);

            UsuarioModel response = await client.GetAsync<UsuarioModel>(request);

            ViewBag.usuario = response;

            return View();

        }
        
        


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}