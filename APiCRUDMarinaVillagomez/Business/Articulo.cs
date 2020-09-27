using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using Microsoft.Data.SqlClient;
using APiCRUDMarinaVillagomez;
using APiCRUDMarinaVillagomez.DataHelper;

namespace APiCRUDMarinaVillagomez.Business
{
    public class Articulo
    {

        public static List<Model.Articulo> GetArticulos()
        {
            List<Model.Articulo> articulos = new List<Model.Articulo>();
            try
            {
                

                var ds = SqlHelper.ExecuteQueryWithDataset("uSP_GetArticulos");

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    articulos.Add(new Model.Articulo()
                    {
                        idArticulo = int.Parse(ds.Tables[0].Rows[i]["idArticulo"].ToString()),
                        descripcion = ds.Tables[0].Rows[i]["descripcion"].ToString(),
                        nombreFabricante = ds.Tables[0].Rows[i]["nombreFabricante"].ToString(),
                        precio = decimal.Parse(ds.Tables[0].Rows[i]["precio"].ToString()),
                        unidadMedida = ds.Tables[0].Rows[i]["unidadMedida"].ToString()
                    });
                }
            }
            catch(Exception ex)
            {
                throw (ex);
            }
             
            return articulos;
        }

        public static bool AddArticulo(Model.Articulo articulo)
        {
            var bandera = false;
            try { 
            var parametros = new SqlParameter[4];
            parametros[0] = new SqlParameter("@descripcion", articulo.descripcion);
            parametros[1] = new SqlParameter("@nombreFabricante", articulo.nombreFabricante);
            parametros[2] = new SqlParameter("@precio", articulo.precio);
            parametros[3] = new SqlParameter("@unidadMedida", articulo.unidadMedida);

            var ds = SqlHelper.ExecuteQueryWithDataset("uSP_AddArticulo",parametros);

                bandera = int.Parse(ds.Tables[0].Rows[0]["Respuesta"].ToString()) == 1 ? true : false;
            }
            catch (Exception ex)
            {
                throw (ex);
               
            }
            return bandera;
        }

        public static bool PutArticulo(Model.Articulo articulo)
        {
            var bandera = false;
            try
            {
                

                var parametros = new SqlParameter[5];
                parametros[0] = new SqlParameter("@idArticulo", articulo.idArticulo);
                parametros[1] = new SqlParameter("@descripcion", articulo.descripcion);
                parametros[2] = new SqlParameter("@nombreFabricante", articulo.nombreFabricante);
                parametros[3] = new SqlParameter("@precio", articulo.precio);
                parametros[4] = new SqlParameter("@unidadMedida", articulo.unidadMedida);

                var ds = SqlHelper.ExecuteQueryWithDataset("uSP_UpdateArticulo", parametros);

                bandera = int.Parse(ds.Tables[0].Rows[0]["Respuesta"].ToString()) == 1 ? true : false;
            }
            catch (Exception ex)
            {
                throw (ex);

            }
            return bandera;
        }

        public static bool DeleteArticulo(int idArticulo)
        {
            var bandera = false;
            try
            {
                 
                var parametros = new SqlParameter[1];
                parametros[0] = new SqlParameter("@idArticulo", idArticulo);
               
                var ds = SqlHelper.ExecuteQueryWithDataset("uSP_DeleteArticulo", parametros);

                bandera = int.Parse(ds.Tables[0].Rows[0]["Respuesta"].ToString()) == 1 ? true : false;
            }
            catch (Exception ex)
            {
                throw (ex);

            }
            return bandera;
        }

    }
}
