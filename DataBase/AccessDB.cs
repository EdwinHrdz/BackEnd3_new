using primeraAPI.Models;
using System.Data.SqlClient;

namespace primeraAPI.DataBase
{
    public class AccessDB
    {
        private readonly string _dataBase;
        public AccessDB(IConfiguration configuration) 
        {
            _dataBase = configuration["ConnectionStrings:DataBase"]!;
        }

        public LoginResponse Login (LoginRequest DataRequest)
        {
            using (SqlConnection connection = new SqlConnection(_dataBase))
            {
                try
                {
                    connection.Open();
                    LoginResponse loginResponse = new LoginResponse() { Message = "Sin respuesta de la Base de Datos"};
                    string query = string.Format("exec Access @Method = 'login', @Email = '{0}', @Password='{1}' ", DataRequest.Username,DataRequest.Password);
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                loginResponse = new LoginResponse()
                                {
                                    IsSuccess = reader["IsSuccess"] != DBNull.Value ? (int)reader["IsSuccess"] : 0,
                                    Message = reader["Message"].ToString() ?? "",
                                    Id = reader["Id"] != DBNull.Value ? (int)reader["Id"] : 0,
                                    Correo = reader["Correo"].ToString() ?? "",
                                    Nombre = reader["Nombre"].ToString() ?? "",
                                    TipoDeUsuario = reader["TipoDeUsuario"].ToString() ?? "",
                                    Estatus = reader["Estatus"].ToString() ?? ""
                                };
                            }
                        }
                    }
                    return loginResponse;
                }
                catch (Exception ex)
                {
                    return new LoginResponse()
                    {
                        Message = ex.Message
                    };
                }
            }

        }
    }
}
