
namespace RCV_FRONTEND.Models
{
    public class ResultadoApi
    {
        public string mensage {  get; set; }
        public List<Imagen> lista { get; set; }

        public Imagen objeto { get; set; }

        internal List<Usuario> listaU()
        {
            throw new NotImplementedException();
        }
    }
}
