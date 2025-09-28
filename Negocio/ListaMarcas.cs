using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using ConexionesBD;

namespace Negocio
{
    public class ListaMarcas
    {
        public List<Marcas> ListarMarcas()
        {
            List<Marcas> marcas = new List<Marcas>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.SetearConsulta("SELECT id, Descripcion FROM MARCAS");
                datos.EjectuarLectura();

                while (datos.lector.Read())
                {
                    Marcas marca = new Marcas();
                    marca.id = Convert.ToInt32(datos.lector["id"]);
                    marca.Descripcion = (string)datos.lector["Descripcion"].ToString();
                    marcas.Add(marca);
                }

                return marcas;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
