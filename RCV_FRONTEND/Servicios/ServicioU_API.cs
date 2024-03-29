using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RCV_FRONTEND.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using RCV_FRONTEND.Servicios;
namespace RCV_FRONTEND.Servicios
{
    public class ServicioU_API : IServicioU_API
    {
        private readonly string _baseurl;

        public ServicioU_API()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            _baseurl = builder.GetSection("ApiSettings:baseUrl").Value;

            if (string.IsNullOrEmpty(_baseurl)) // Verifica si la URL base es nula o vacía
            {
                throw new ArgumentNullException(nameof(_baseurl), "Base URL is null or empty.");
            }
        }

        public async Task<List<Usuario>> ListaU()
        {
            List<Usuario> listaU = new List<Usuario>();

            using var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseurl);

            var response = await cliente.GetAsync("api/Usuario/ListaU");

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<ResultadoApi>(json_respuesta);

                if (resultado.listaU != null)
                {
                    listaU = resultado.lista;
                }
            }
        }

            public async Task<Usuario> ObtenerU(int idUsuario)
        {
            Usuario objetoU = new Usuario();

            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseurl);

            var response = await cliente.GetAsync($"api/Usuario/obtenerU/{idUsuario}");

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<ResultadoApi>(json_respuesta);
                //objetoU = resultado.objetoU;
            }
            return objetoU;
        }

        public async Task<bool> GuardarU(Usuario objeto)
        {
            bool respuesta = false;

            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseurl);

            var content = new StringContent(JsonConvert.SerializeObject(objeto), Encoding.UTF8, "application/json");

            var response = await cliente.PostAsync("api/Usuario/GuardarU/", content);

            if (response.IsSuccessStatusCode)
            {
                respuesta = true;
            }
            return respuesta;
        }

        public async Task<bool> EditarU(Usuario objeto)
        {
            bool respuesta = false;

            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseurl);

            var content = new StringContent(JsonConvert.SerializeObject(objeto), Encoding.UTF8, "application/json");

            var response = await cliente.PutAsync("api/Usuario/EditarU/", content);

            if (response.IsSuccessStatusCode)
            {
                respuesta = true;
            }
            return respuesta;
        }

        public async Task<bool> EliminarU(int idUsuario)
        {
            bool respuesta = false;

            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseurl);

            var response = await cliente.DeleteAsync($"api/Usuario/EliminarU/{idUsuario}");

            if (response.IsSuccessStatusCode)
            {
                respuesta = true;
            }
            return respuesta;
        }
    }
}
