using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace WebApplication1.Models
{
    public class Producto
    {
 
        public int IdProducto { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int Cantidad { get; set; }

        /*public Producto()
        {

        }*/

        /*public Producto(int idProducto, string nombre, string descripcion, int cantidad)
        {
            this.IdProducto = idProducto;
            this.Nombre = nombre;
            this.Descripcion = descripcion;
            this.Cantidad = cantidad;
        }*/

       
    }
}
