using RCV_FRONTEND.Models;

namespace RCV_FRONTEND.Servicios
{
    public interface IServicioI_API
    {
        Task<List<Imagen>> Lista();
        Task<Imagen> ObtenerI(int idImagen);
        Task<bool> GuardarI(Imagen objeto);
        Task<bool> EditarI(Imagen objeto);

        Task<bool> EliminarI(int IdImagen);
    }
}
