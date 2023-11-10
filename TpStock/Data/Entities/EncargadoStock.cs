namespace TpStock.Data.Entities
{
    public class EncargadoStock: User
    {
        public ICollection<Movimiento> MovimientosControles { get; set; } = new List<Movimiento>();
    }
}
