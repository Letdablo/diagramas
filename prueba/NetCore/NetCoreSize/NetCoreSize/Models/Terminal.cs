using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetCoreSize.Models
{
    public class Terminal
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey(nameof(Estado))]
        public int id_estado { get; set; }
        [ForeignKey(nameof(Fabricante))]
        public int id_fab { get; set; }
        public string? fecha_fabricacion { get; set; }
        public string? fecha_estado { get; set; }
        public string? terminal_desc { get; set; }
        public string? terminal_name { get; set; }
    }
}
