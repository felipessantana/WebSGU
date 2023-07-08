using ConsumindoAPI.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using JsonConverter = Newtonsoft.Json.JsonConverter;
using System.Text.Json;

namespace ConsumindoAPI.Services
{
    internal class UsuarioServices
    {
        public async Task<Usuario> Integracao(int id_usuario)
        {
            HttpClient httpclient = new HttpClient();
            var response = await httpclient.GetAsync($"https://localhost:7107/api/usuario/{id_usuario}");
            var jsonString = await response.Content.ReadAsStringAsync();

            Usuario jsonObject = JsonConvert.DeserializeObject<Usuario>(jsonString);

            if(jsonObject != null)
            {
                return jsonObject;
            }
            else
            {
                return new Usuario
                {
                    Vericacao = true
                };
            }
            
        }
    }
}
