using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using ConexionesBD;

namespace Negocio
{
    public class ListaImagenes
    {
        public List<Imagenes> ListarImagenesPorArticulo(int idArticulo)
        {
            List<Imagenes> lista = new List<Imagenes>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.SetearConsulta("SELECT Id, IdArticulo, ImagenUrl FROM IMAGENES WHERE IdArticulo = @id");
                datos.SetearParametros("@id", idArticulo);
                datos.EjectuarLectura();

                while (datos.lector.Read())
                {
                    Imagenes img = new Imagenes();
                    img.Id = (int)datos.lector["Id"];
                    img.IdArticulo = (int)datos.lector["IdArticulo"];
                    img.ImagenUrl = datos.lector["ImagenUrl"].ToString();

                    lista.Add(img);
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
