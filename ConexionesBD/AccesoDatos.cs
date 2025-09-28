using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace ConexionesBD
{
    public class AccesoDatos
    {
        private SqlConnection Conexion;
        private SqlCommand Comando;
        private SqlDataReader Lector;
        public SqlDataReader lector
        {
            get { return Lector; }
        }

        public AccesoDatos()
        {
            Conexion = new SqlConnection("server=.\\SQLEXPRESS; database=CATALOGO_P3_DB; integrated security=true");
            Comando = new SqlCommand();
        }
        public void SetearConsulta(string Consulta)
        {
            Comando.CommandType = System.Data.CommandType.Text;
            Comando.CommandText = Consulta;
        }
        public void EjectuarLectura()
        {
            Comando.Connection = Conexion;

            try
            {
                Conexion.Open();
                Lector = Comando.ExecuteReader();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void CerrarConexion()
        {
            if (lector != null)
            {
                lector.Close();
            }
            Conexion.Close();
        }

        public void ejecturarAccion()
        {
            Comando.Connection = Conexion;
            try
            {
                Conexion.Open();
                Comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void SetearParametros(string nombre, Object valor)
        {
            Comando.Parameters.AddWithValue(nombre, valor);
        }

        public object EjecutarScalar()
        {
            Comando.Connection = Conexion;
            try
            {
                Conexion.Open();
                return Comando.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Conexion.Close();
            }
        }
    }
}

