using RCV_FRONTEND.Models;

namespace RCV_FRONTEND.Servicios
{
    public interface IServicioU_API
    {
        Task<List<Usuario>> ListaU();
        Task<Usuario> ObtenerU(int idUsuario);
        Task<bool> GuardarU(Usuario objetoU);
        Task<bool> EditarU(Usuario objetoU);
        Task<bool> EliminarU(int idUsuario);
    }
}
