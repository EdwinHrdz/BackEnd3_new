namespace primeraAPI.Models
{
    public class LoginResponse
    {
        public int IsSuccess { get; set; }
        public string Message { get; set; }
        public int Id { get; set; }
        public string Correo { get; set; }
        public string Nombre { get; set; }
        public string TipoDeUsuario { get; set; }
        public string Estatus { get; set; }
    }
}
