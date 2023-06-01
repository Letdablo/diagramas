using System.ComponentModel.DataAnnotations;

namespace NetCoreSize.Models
{
    public class TerminalInformation
    {
        [Key]
        public int Id { get; set; }
        public string? terminal_name { get; set; }
        public string? terminal_desc { get; set; }
        public string? fab_name { get; set; }
        public string? estado_name { get; set; }
        public string? fecha_fabricacion { get; set; }
        public string? fecha_estado { get; set; }

    }
}
