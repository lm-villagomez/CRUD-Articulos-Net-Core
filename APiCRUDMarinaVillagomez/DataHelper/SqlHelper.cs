using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.Data.SqlClient;//nuget
using Microsoft.Extensions.Configuration;//nuget
using System.Data;
using System.IO;


namespace APiCRUDMarinaVillagomez.DataHelper
{
    [Serializable]
    public class SqlHelper
    {
       static SqlConnection conn;
        public static DataSet ExecuteQueryWithDataset(string spName, SqlParameter[] parameters)
        {
            try
            {
                return ExecuteQuery(spName, parameters);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error " + ex.Message + " ha ocurrido: " + ex.Message);
                throw;
            }
        }

        public static DataSet ExecuteQueryWithDataset(string spName)
        {
            try
            {
                return ExecuteQuery(spName);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error " + ex.Message + " ha ocurrido: " + ex.Message);
                throw;
            }
        }

        private static DataSet ExecuteQuery(string spName, SqlParameter[] parameters)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection conn = Conexion();
                using (SqlCommand cmd = new SqlCommand(spName, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddRange(parameters);
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {

                        da.Fill(ds);

                    }
                }
                return ds;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error " + ex + " ha ocurrido: " + ex.Message);
                throw;
            }
        }

        private static DataSet ExecuteQuery(string spName)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection conn = Conexion();
                using (SqlCommand cmd = new SqlCommand(spName, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {

                        da.Fill(ds);

                    }
                }
                return ds;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error " + ex + " ha ocurrido: " + ex.Message);
                throw;
            }
        }

        private static SqlConnection Conexion()
        {
          
            var configurationBuilder = new ConfigurationBuilder();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            configurationBuilder.AddJsonFile(path, false);

            var root = configurationBuilder.Build();
            string connectionString = root.GetSection("ConnectionStrings").GetSection("DefaultConnection").Value;
            var appSetting = root.GetSection("ApplicationSettings");


            string str = @connectionString;
           
            conn = new SqlConnection(str);



            return conn;
        }

    }
}