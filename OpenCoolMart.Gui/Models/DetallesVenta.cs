namespace OpenCoolMart.Gui.Models
{
    public class DetallesVenta
    {
        public int VentaId { get; set; }
        public int ProductoId { get; set; }

        public int CantiProd { get; set; }
        public double VentaProductos { get; set; }

        public ProductoResponseDto Producto { get; set; }
    }
}
