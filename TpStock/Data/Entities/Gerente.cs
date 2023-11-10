namespace TpStock.Data.Entities
{
    public class Gerente: User
    {
        public ICollection<Movimiento> Movimientos { get; set; } = new List<Movimiento>();
    }
}
