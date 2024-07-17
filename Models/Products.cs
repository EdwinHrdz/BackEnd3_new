namespace primeraAPI.Models
{
    public class Products
    {
        public int Id { get; set; }
        public string Clasificacion { get; set; }
        public string CodigoProducto { get; set; }
        public string NombreProducto { get; set; }
        public decimal Precio { get; set; }
        public int CantidadEnStock { get; set; }
    }
    
    public class ProductsResponse() : GeneralResponse
    {
        public List<Products> Products { get; set; }
    }
}
