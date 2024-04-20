using System.ComponentModel.DataAnnotations;

namespace L02P02_2021AR601_2021MM656.Models
{   public class usuariosDB
    {
        public class puestos
        {
            [Key]
            public int id { get; set; }
            public string? puesto { get; set; }
            public string? estado { get; set; }

            public DateTime? created_at { get; set; }

        }

        public class departamentos
        {
            [Key]
            public int id { get; set; }
            public string? departamento { get; set; }
            public string? estado { get; set; }

            public DateTime? created_at { get; set; }

        }

        public class clientes
        {
            [Key]
            public int id { get; set; }
            public string? nombre { get; set; }
            public string? apellido { get; set; }
            public string? email { get; set; }
            public string? direccion { get; set; }

            public string? genero { get; set; }
            public int? id_departamento { get; set; }

            public int? id_puesto { get; set; }

            public string? estado_registro { get; set; }

            public DateTime? created_at { get; set; }

            public DateTime? updated_at { get; set; }



        }
    }
}
