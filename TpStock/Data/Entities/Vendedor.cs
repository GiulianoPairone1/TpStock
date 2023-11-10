namespace TpStock.Data.Entities
{
    public class Vendedor: User
    {
        public ICollection<Movimiento> MoimientosVendedidos { get; set; } = new List<Movimiento>();
    }
}
