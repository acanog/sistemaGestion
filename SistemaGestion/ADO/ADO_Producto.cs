using SistemaGestion.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.PortableExecutable;

namespace SistemaGestion.ADO
{
    public class ADO_Producto
    {
        public static List<Producto> TraerProducto(int idUsuarioProducto)
        {
            var listaProductos = new List<Producto>();


            SqlConnectionStringBuilder conecctionbuilder = new SqlConnectionStringBuilder();
            conecctionbuilder.DataSource = "DESKTOP-RRAI8UU";
            conecctionbuilder.InitialCatalog = "dbSistemaGestionCoder";
            conecctionbuilder.IntegratedSecurity = true;
            var cs = conecctionbuilder.ConnectionString;

            using (SqlConnection connection = new SqlConnection(cs))
            {
                connection.Open();

                //  Punto 2
                SqlCommand cmd2 = connection.CreateCommand();
                cmd2.CommandText = "select * from Producto where idUsuario = @idUsuarioProducto";
                cmd2.Parameters.Add(new SqlParameter("@idUsuarioProducto", idUsuarioProducto));


                var param2 = new SqlParameter("@idUsuarioProducto", SqlDbType.Int);
                param2.Value = idUsuarioProducto;

                var reader2 = cmd2.ExecuteReader();
                while (reader2.Read())
                {
                    var produc = new Producto();

                    produc.Id = Convert.ToInt32(reader2.GetValue(0));
                    produc.Descripcion = reader2.GetValue(1).ToString();
                    produc.Costo = Convert.ToDouble(reader2.GetValue(2));
                    produc.PrecioVenta = Convert.ToDouble(reader2.GetValue(3));
                    produc.Stock = Convert.ToInt32(reader2.GetValue(4));
                    produc.IdUsuario = Convert.ToInt32(reader2.GetValue(5));

                    listaProductos.Add(produc);

                }
                
                reader2.Close();
                connection.Close();


                return listaProductos;

            }


        }       



    }


}
