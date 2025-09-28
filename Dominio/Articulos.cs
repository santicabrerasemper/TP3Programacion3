using System;
using System.Collections.Generic;
using System.ComponentModel;  // Para DisplayName
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Dominio
{
    public class Articulos
    {
        [DisplayName("ID")]
        public int Id { get; set; }

        [DisplayName("Código")]
        public string Codigo { get; set; }

        [DisplayName("Nombre")]
        public string Nombre { get; set; }

        [DisplayName("Descripción")]
        public string Descripcion { get; set; }

        [DisplayName("Categoría")]
        public Categorias categoria { get; set; }

        [DisplayName("Marca")]
        public Marcas marcas { get; set; }

        [DisplayName("URL de Imagen")]
        public string ImagenUrl { get; set; }

        [DisplayName("Precio")]
        public float Precio { get; set; }

        [DisplayName("Imágenes")]
        public List<Imagenes> Imagenes { get; set; } = new List<Imagenes>();
    }
}
