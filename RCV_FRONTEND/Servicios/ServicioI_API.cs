using Newtonsoft.Json;
using RCV_FRONTEND.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RCV_FRONTEND.Servicios
{
    public class ServicioI_API : IServicioI_API
    {
        private static string _baseurl;

        public ServicioI_API()
        {
            _baseurl = "http://www.rcvapi.somee.com/"; // Reemplaza "URL_BASE_DE_TU_API" con la URL base de tu API
        }

        public async Task<List<Imagen>> Lista()
        {
            List<Imagen> lista = new List<Imagen>();

            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseurl);

            var response = await cliente.GetAsync("api/Imagenes/ListaI");

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<ResultadoApi>(json_respuesta);
                lista = resultado.lista;
            }
            return lista;
        }

        public async Task<Imagen> ObtenerI(int idImagen)
        {
            Imagen objeto = new Imagen();

            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseurl);

            var response = await cliente.GetAsync($"api/Imagenes/obtenerI/{idImagen}");

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<ResultadoApi>(json_respuesta);
                objeto = resultado.objeto;
            }
            return objeto;
        }

        public async Task<bool> GuardarI(Imagen objeto)
        {
            bool respuesta = false;

            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseurl);

            var content = new StringContent(JsonConvert.SerializeObject(objeto), Encoding.UTF8, "application/json");

            var response = await cliente.PostAsync("api/Imagenes/GuardarI/", content);

            if (response.IsSuccessStatusCode)
            {
                respuesta = true;
            }
            return respuesta;
        }

        public async Task<bool> EditarI(Imagen objeto)
        {
            bool respuesta = false;

            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseurl);

            var content = new StringContent(JsonConvert.SerializeObject(objeto), Encoding.UTF8, "application/json");

            var response = await cliente.PutAsync("api/Imagenes/EditarI/", content);

            if (response.IsSuccessStatusCode)
            {
                respuesta = true;
            }
            return respuesta;
        }

        public async Task<bool> EliminarI(int idImagen)
        {
            bool respuesta = false;

            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseurl);

            var response = await cliente.DeleteAsync($"api/Imagenes/Eliminar/{idImagen}");

            if (response.IsSuccessStatusCode)
            {
                respuesta = true;
            }
            return respuesta;
        }
    }
}
