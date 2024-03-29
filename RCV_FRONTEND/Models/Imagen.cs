using System.ComponentModel.DataAnnotations.Schema;

namespace RCV_FRONTEND.Models
{
    public class Imagen
    {
        public int Id_Imagen { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? Telefono { get; set; }
        public string? Image { get; set; }
        public string? Documento { get; set; }

        public string? ID_UsuarioCreador { get; set; }


        //propiedad no mapeada para validar si se cargo un archivo
        [NotMapped]
        public IFormFile? File { get; set; }
    }
}
