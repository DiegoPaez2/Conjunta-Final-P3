using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TDDTestingMVC1.Models
{
    public class Pedido
    {
        [Key]
        public int PedidoID { get; set; }

        [Required]
        public int ClienteID { get; set; }

        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime FechaPedido { get; set; } = DateTime.Now;

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal Monto { get; set; }

        [Required]
        [StringLength(50)]
        public string Estado { get; set; } = "Pendiente";

        // Relación con Cliente
        [ForeignKey("ClienteID")]
        public virtual Cliente Cliente { get; set; }
    }
}
