using System.ComponentModel.DataAnnotations;

namespace L02P02_2021AR601_2021MM656.Models
{
    public class puestos
    {

        [Key]
        public int id { get; set; }
        public string? puesto { get; set; }
        public string? estado { get; set; }

        public DateTime? created_at { get; set; }

    }
}
