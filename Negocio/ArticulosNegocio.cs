using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class ArticulosNegocio
    {
        public class ArticuloNegocio
        {
            private ListaArticulos datos = new ListaArticulos();

            public List<Articulos> ListarArticulos()
            {
                return datos.ArticulosListar();
            }
        }

    }
}
