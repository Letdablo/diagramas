using System.ComponentModel.DataAnnotations;

namespace NetCoreSize.Models
{
    public class Fabricante
    {
        [Key]
        public int id_fab { get; set; }
        public string? fab_name { get; set; }
        public string? fab_desc { get; set; }
    }
}
