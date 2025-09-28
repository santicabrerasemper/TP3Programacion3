using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using ConexionesBD;

namespace Negocio
{
    public class ListaCategorias
    {
        public List<Categorias> ListarCategorias()
        {
            List<Categorias> categorias = new List<Categorias>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.SetearConsulta("SELECT id, Descripcion FROM CATEGORIAS");
                datos.EjectuarLectura();

                while (datos.lector.Read())
                {
                    Categorias categoria = new Categorias();
                    categoria.id = Convert.ToInt32(datos.lector["id"]);
                    categoria.Descripcion = datos.lector["Descripcion"].ToString();
                    categorias.Add(categoria);
                }

                return categorias;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
