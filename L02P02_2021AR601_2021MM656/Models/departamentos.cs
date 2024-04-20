using System.ComponentModel.DataAnnotations;

namespace L02P02_2021AR601_2021MM656.Models
{
    public class departamentos
    {
        [Key]
        public int id { get; set; }
        public string? departamento { get; set; }
        public string? estado { get; set; }

        public DateTime? created_at { get; set; }




    }
}
