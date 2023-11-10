using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TpStock.Data.Entities
{
    public class Movimiento
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Gerente> Gerentes { get; set; }   = new List<Gerente>();
        public ICollection<Vendedor> Vendedores { get; set; } = new List<Vendedor>();
        public ICollection<EncargadoStock> EncargadoStock { get; } = new HashSet<EncargadoStock>();


    }
}
