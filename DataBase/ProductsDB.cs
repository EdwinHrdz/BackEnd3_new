using primeraAPI.Models;
using System.Data.SqlClient;

namespace primeraAPI.DataBase
{
    public class ProductsDB
    {
        private readonly string _dataBase;
        public ProductsDB(IConfiguration configuration)
        {
            _dataBase = configuration["ConnectionStrings:DataBase"]!;
        }
        public List<Products> GetProducts()
        {
            List<Products> products = new List<Products>();
            using (SqlConnection connection = new SqlConnection(_dataBase))
            {
                try
                {
                    connection.Open();
                    string query = "exec Store @Method = 'get_products'";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                products.Add(new Products()
                                {
                                    Id = (int)reader["Id"],
                                    Clasificacion = reader["Clasificacion"].ToString(),
                                    CodigoProducto = reader["CodigoProducto"].ToString(),
                                    NombreProducto = reader["NombreProducto"].ToString(),
                                    Precio = (decimal)reader["Precio"],
                                    CantidadEnStock = (int)reader["CantidadEnStock"]
                                });
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al obtener los productos: " + ex.Message);
                }
            }

            return products;
        }
    }
}
