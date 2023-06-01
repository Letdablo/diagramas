using System.ComponentModel.DataAnnotations;

namespace NetCoreSize.Models
{
    public class Estado
    {
        [Key]
        public int id_estado { get; set; }
        public string? estado_name { get; set; }
        public string? estado_desc { get; set; }
    }
}
