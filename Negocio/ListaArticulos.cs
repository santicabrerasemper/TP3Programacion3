using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using ConexionesBD;
using System.Globalization;



namespace Negocio
{
    public class ListaArticulos
    {
        public List<Articulos> ArticulosListar()
        {
            List<Articulos> lista = new List<Articulos>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.SetearConsulta(@"
                    SELECT 
                        A.Id,
                        A.Codigo,
                        A.Nombre,
                        A.Descripcion,
                        C.Id AS IdCategoria,
                        C.Descripcion AS Categoria,
                        M.Id AS IdMarca,
                        M.Descripcion AS Marca,
                        (SELECT TOP 1 ImagenUrl FROM IMAGENES WHERE IdArticulo = A.Id) AS ImagenUrl,
                        A.Precio
                    FROM ARTICULOS A
                    LEFT JOIN CATEGORIAS C ON A.IdCategoria = C.Id
                    LEFT JOIN MARCAS M ON A.IdMarca = M.Id");
                datos.EjectuarLectura();

                ListaImagenes gestorImagenes = new ListaImagenes();

                while (datos.lector.Read())
                {
                    Articulos aux = new Articulos();
                    aux.Id = (int)datos.lector["Id"];

                    aux.Codigo = datos.lector["Codigo"] != DBNull.Value ? (string)datos.lector["Codigo"] : null;
                    aux.Nombre = datos.lector["Nombre"].ToString();
                    aux.Descripcion = datos.lector["Descripcion"].ToString();

                    Categorias categoria = new Categorias();

                    if (datos.lector["IdCategoria"] != DBNull.Value)
                        categoria.id = (int)datos.lector["IdCategoria"];
                    else
                        categoria.id = 0;  // o -1, según tu lógica

                    if (datos.lector["Categoria"] != DBNull.Value)
                        categoria.Descripcion = datos.lector["Categoria"].ToString();
                    else
                        categoria.Descripcion = string.Empty; // o null, según prefieras

                    aux.categoria = categoria;


                    Marcas marcas = new Marcas();
                    if (datos.lector["IdMarca"] != DBNull.Value)
                    {
                        marcas.id = (int)datos.lector["IdMarca"];
                        marcas.Descripcion = datos.lector["Marca"].ToString();
                    }
                    aux.marcas = marcas;

                    aux.Precio = datos.lector["Precio"] != DBNull.Value ? Convert.ToSingle(datos.lector["Precio"]) : 0;

                    aux.ImagenUrl = datos.lector["ImagenUrl"] != DBNull.Value ? datos.lector["ImagenUrl"].ToString() : null;

                    // Lista completa de imágenes (opcional, si la necesitas)
                    aux.Imagenes = gestorImagenes.ListarImagenesPorArticulo(aux.Id);

                    lista.Add(aux);
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void agregarArticulo(Articulos articulo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                // Insertar artículo y obtener el ID generado
                datos.SetearConsulta("INSERT INTO ARTICULOS (Nombre, Codigo, Descripcion, Precio, IdCategoria, IdMarca) " +
                                     "VALUES (@Nombre, @Codigo, @Descripcion, @Precio, @IdCategoria, @IdMarca); " +
                                     "SELECT SCOPE_IDENTITY();");

                datos.SetearParametros("@Nombre", articulo.Nombre);
                datos.SetearParametros("@Codigo", articulo.Codigo);
                datos.SetearParametros("@Descripcion", articulo.Descripcion);
                datos.SetearParametros("@Precio", articulo.Precio);
                datos.SetearParametros("@IdCategoria", articulo.categoria.id);
                datos.SetearParametros("@IdMarca", articulo.marcas.id);

                int idArticulo = Convert.ToInt32(datos.EjecutarScalar());

                // Insertar cada imagen asociada al artículo
                foreach (var imagen in articulo.Imagenes)
                {
                    AccesoDatos datosImg = new AccesoDatos();
                    try
                    {
                        datosImg.SetearConsulta("INSERT INTO IMAGENES (IdArticulo, ImagenUrl) VALUES (@IdArticulo, @ImagenUrl)");
                        datosImg.SetearParametros("@IdArticulo", idArticulo);
                        datosImg.SetearParametros("@ImagenUrl", imagen.ImagenUrl);
                        datosImg.ejecturarAccion();
                    }
                    finally
                    {
                        datosImg.CerrarConexion();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.CerrarConexion();
            }
        }

        public void modificarArticulo(Articulos articulo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetearConsulta("UPDATE ARTICULOS SET Nombre = @Nombre, Descripcion = @Descripcion, Codigo = @Codigo, IdMarca =@IdMarca, IdCategoria = @IdCategoria, Precio = @Precio Where id = @Id");
                datos.SetearParametros("@Nombre", articulo.Nombre);
                datos.SetearParametros("@Codigo", articulo.Codigo);
                datos.SetearParametros("@Descripcion", articulo.Descripcion);
                datos.SetearParametros("@Precio", articulo.Precio);
                datos.SetearParametros("@IdCategoria", articulo.categoria.id);
                datos.SetearParametros("@IdMarca", articulo.marcas.id);
                datos.SetearParametros("@Id", articulo.Id);

                datos.ejecturarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.CerrarConexion();
            }
            actualizarImagenes(articulo);
        }

        private void actualizarImagenes(Articulos articulo)
        {
            // Borramos todas las imágenes anteriores del artículo
            AccesoDatos datosDelete = new AccesoDatos();
            datosDelete.SetearConsulta("DELETE FROM IMAGENES WHERE IdArticulo = @IdArticulo");
            datosDelete.SetearParametros("@IdArticulo", articulo.Id);
            datosDelete.ejecturarAccion();
            datosDelete.CerrarConexion();

            // Insertamos nuevamente las que tiene en la lista
            foreach (var imagen in articulo.Imagenes)
            {
                AccesoDatos datosInsert = new AccesoDatos();
                datosInsert.SetearConsulta("INSERT INTO IMAGENES (IdArticulo, ImagenUrl) VALUES (@IdArticulo, @ImagenUrl)");
                datosInsert.SetearParametros("@IdArticulo", articulo.Id);
                datosInsert.SetearParametros("@ImagenUrl", imagen.ImagenUrl);
                datosInsert.ejecturarAccion();
                datosInsert.CerrarConexion();
            }
        }

        public void Eliminar(int id)
        {
            try
            {
                AccesoDatos datos = new AccesoDatos();
                datos.SetearConsulta("delete from ARTICULOS where id = @id ");
                datos.SetearParametros("@id",id);
                datos.ejecturarAccion();
            }
            catch (Exception ex )
            {

                throw ex;
            }
        }

        public List<Articulos> ListarArticulosConImagenes()
        {
            List<Articulos> lista = new List<Articulos>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.SetearConsulta(@"SELECT 
                                A.Id, A.Nombre, A.Codigo, A.Descripcion, A.Precio, 
                                A.IdCategoria, A.IdMarca,
                                I.Id AS IdImagen, I.ImagenUrl,
                                C.Descripcion AS CategoriaDescripcion,
                                M.Descripcion AS MarcaDescripcion
                              FROM ARTICULOS A
                              LEFT JOIN IMAGENES I ON A.Id = I.IdArticulo
                              INNER JOIN CATEGORIAS C ON A.IdCategoria = C.Id
                              INNER JOIN MARCAS M ON A.IdMarca = M.Id
                              ORDER BY A.Id");

                datos.EjectuarLectura();

                Articulos articulo = null;
                int ultimoId = -1;

                while (datos.lector.Read())
                {
                    int idActual = (int)datos.lector["Id"];

                    if (idActual != ultimoId)
                    {
                        articulo = new Articulos();
                        articulo.Id = idActual;
                        articulo.Nombre = (string)datos.lector["Nombre"];
                        articulo.Codigo = (string)datos.lector["Codigo"];
                        articulo.Descripcion = (string)datos.lector["Descripcion"];
                        articulo.Precio = Convert.ToSingle(datos.lector["Precio"]);

                        // Categoría
                        articulo.categoria = new Categorias()
                        {
                            id = (int)datos.lector["IdCategoria"],
                            Descripcion = (string)datos.lector["CategoriaDescripcion"]
                        };

                        // Marca
                        articulo.marcas = new Marcas()
                        {
                            id = (int)datos.lector["IdMarca"],
                            Descripcion = (string)datos.lector["MarcaDescripcion"]
                        };

                        articulo.Imagenes = new List<Imagenes>();
                        lista.Add(articulo);

                        ultimoId = idActual;
                    }

                    // Si hay imagen para el artículo
                    if (datos.lector["IdImagen"] != DBNull.Value)
                    {
                        Imagenes imagen = new Imagenes()
                        {
                            Id = (int)datos.lector["IdImagen"],
                            ImagenUrl = (string)datos.lector["ImagenUrl"]
                        };
                        articulo.Imagenes.Add(imagen);
                    }
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.CerrarConexion();
            }



        }

        public List<Articulos> filtrar(string campo, string criterio, string filtro)
        {
            var lista = new List<Articulos>();
            var datos = new AccesoDatos();
            var gestorImagenes = new ListaImagenes();

            try
            {
                const string PRECIO_NORMALIZADO = @"
CAST(
    CASE 
        WHEN A.Precio < 1000 
             AND ABS(A.Precio - ROUND(A.Precio, 2)) > 0.00001
             THEN A.Precio * 1000 
        ELSE A.Precio 
    END 
AS DECIMAL(18,2))";

                var sb = new StringBuilder($@"
SELECT A.Id, A.Codigo, A.Nombre, A.Descripcion,
       C.Id AS IdCategoria, C.Descripcion AS Categoria,
       M.Id AS IdMarca, M.Descripcion AS Marca,
       (SELECT TOP 1 ImagenUrl FROM IMAGENES WHERE IdArticulo = A.Id) AS ImagenUrl,
       {PRECIO_NORMALIZADO} AS Precio           -- 👈 mostramos el precio normalizado
FROM ARTICULOS A
LEFT JOIN CATEGORIAS C ON A.IdCategoria = C.Id
LEFT JOIN MARCAS M ON A.IdMarca = M.Id
WHERE 1=1 ");

                bool usarPrecio = false; decimal precio = 0m;
                bool usarTexto = false; string patron = null;
                string columnaTexto = null;

                if (campo == "Precio")
                {
                    var esAR = CultureInfo.GetCultureInfo("es-AR");
                    if (!decimal.TryParse((filtro ?? "").Trim(), NumberStyles.Number, esAR, out precio) &&
                        !decimal.TryParse((filtro ?? "").Trim(), NumberStyles.Number, CultureInfo.InvariantCulture, out precio))
                        throw new Exception("Ingrese un número válido para Precio (ej: 10000 o 10.000,50).");

                    // 👇 Comparamos contra el PRECIO_NORMALIZADO
                    switch (criterio)
                    {
                        case "Mayor a": sb.Append($" AND {PRECIO_NORMALIZADO} > @precio"); break;
                        case "Menor a": sb.Append($" AND {PRECIO_NORMALIZADO} < @precio"); break;
                        case "Igual a": sb.Append($" AND {PRECIO_NORMALIZADO} = @precio"); break;
                        default: throw new Exception("Criterio inválido para Precio.");
                    }
                    usarPrecio = true;
                }
                else if (campo == "Nombre" || campo == "Descripcion")
                {
                    columnaTexto = (campo == "Nombre") ? "A.Nombre" : "A.Descripcion";
                    var f = (filtro ?? "").Trim();

                    switch (criterio)
                    {
                        case "Comienza con": patron = f + "%"; break;
                        case "Termina con": patron = "%" + f; break;
                        default: patron = "%" + f + "%"; break; // Contiene
                    }

                    sb.Append($" AND {columnaTexto} LIKE @txt");
                    usarTexto = true;
                }

                datos.SetearConsulta(sb.ToString());
                if (usarPrecio) datos.SetearParametros("@precio", precio);
                if (usarTexto) datos.SetearParametros("@txt", patron);

                datos.EjectuarLectura();

                while (datos.lector.Read())
                {
                    var aux = new Articulos
                    {
                        Id = (int)datos.lector["Id"],
                        Codigo = datos.lector["Codigo"] != DBNull.Value ? (string)datos.lector["Codigo"] : null,
                        Nombre = datos.lector["Nombre"].ToString(),
                        Descripcion = datos.lector["Descripcion"].ToString(),
                        categoria = new Categorias
                        {
                            id = datos.lector["IdCategoria"] != DBNull.Value ? (int)datos.lector["IdCategoria"] : 0,
                            Descripcion = datos.lector["Categoria"] != DBNull.Value ? datos.lector["Categoria"].ToString() : string.Empty
                        },
                        marcas = new Marcas
                        {
                            id = datos.lector["IdMarca"] != DBNull.Value ? (int)datos.lector["IdMarca"] : 0,
                            Descripcion = datos.lector["Marca"] != DBNull.Value ? datos.lector["Marca"].ToString() : null
                        },
                   
                        Precio = datos.lector["Precio"] != DBNull.Value ? Convert.ToSingle(datos.lector["Precio"]) : 0,
                        ImagenUrl = datos.lector["ImagenUrl"] != DBNull.Value ? datos.lector["ImagenUrl"].ToString() : null
                    };

                    aux.Imagenes = gestorImagenes.ListarImagenesPorArticulo(aux.Id);
                    lista.Add(aux);
                }

                return lista;
            }
            finally
            {
                datos.CerrarConexion();
            }
        }
    }
}


