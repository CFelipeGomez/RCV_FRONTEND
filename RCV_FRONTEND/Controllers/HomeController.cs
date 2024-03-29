using Microsoft.AspNetCore.Mvc;
using RCV_FRONTEND.Models;
using System.Diagnostics;

using RCV_FRONTEND.Servicios;

namespace RCV_FRONTEND.Controllers
{
    public class HomeController : Controller
    {
        private readonly IServicioI_API _servicioApi;

        private readonly IServicioU_API _servicioUApi;

        public HomeController(IServicioI_API servicioApi, IServicioU_API servicioUApi)
        {
            _servicioApi = servicioApi;
            _servicioUApi = servicioUApi;
        }

        //usar esta vista para listar Imagen
        /*public async Task<IActionResult> Index()
        {
            List<Imagen> Lista = await _servicioApi.Lista();

            return View(Lista);
        }
        */

        public async Task<IActionResult> Index()
        {
            List<Usuario> ListaU = await _servicioUApi.ListaU();

            return View(ListaU);
        }
        //usar esta vista para editar y guardar Usuario
        public async Task<IActionResult> Usuario(int idUsuario)
        {
            if (idUsuario == 0)
            {
                ViewBag.Accion = "Nuevo Usuario";
                return View(new Usuario());
            }

            var usuario = await _servicioUApi.ObtenerU(idUsuario);

            if (usuario != null)
            {
                ViewBag.Accion = "Editar Usuario";
                return View(usuario);
            }
            else
            {
                // Manejar el caso en que no se encuentre el usuario con el ID especificado
                // Puedes redirigir a una página de error o mostrar un mensaje al usuario
                return NotFound(); // Retorna un error 404
            }
        }

        [HttpPost]
        public async Task<IActionResult> GuardarCambiosU(Usuario ob_usuario)
        {
            bool respuesta;

            if (ob_usuario.IdUsuario == 0)
            {
                respuesta = await _servicioUApi.GuardarU(ob_usuario);
            }
            else
            {
                respuesta = await _servicioUApi.EditarU(ob_usuario);
            }

            if (respuesta)
                return RedirectToAction("Index");
            else
                return NoContent();
        }


        [HttpGet]
        public async Task<IActionResult> EliminarU(int idUsuario)
        {
            var respuesta = await _servicioUApi.EliminarU(idUsuario);

            if (respuesta)
                return RedirectToAction("Index");
            else
                return NoContent();
        }


    //usar esta vista para editar y guardar Imagen
    public async Task<IActionResult> Imagen(int idImagen)
        {
            Imagen modelo_imagen = new Imagen();

            ViewBag.Accion = "Nueva Imagen";

            if (idImagen != 0)
            {
                modelo_imagen = await _servicioApi.ObtenerI(idImagen);
                ViewBag.Accion = "Editar Imagen";
            }

            return View(modelo_imagen);
        }

        [HttpPost]
        public async Task<IActionResult> GuardarCambios(Imagen ob_imagen)
        {
            bool respuesta;

            if (ob_imagen.Id_Imagen == 0)
            {
                respuesta = await _servicioApi.GuardarI(ob_imagen);
            }
            else
            {
                respuesta = await _servicioApi.EditarI(ob_imagen);
            }

            if (respuesta)
                return RedirectToAction("Index");
            else
                return NoContent();
        }


        [HttpGet]
        public async Task<IActionResult> EliminarI(int idImagen)
        {
            var respuesta = await _servicioApi.EliminarI(idImagen);

            if (respuesta)
                return RedirectToAction("Index");
            else
                return NoContent();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
