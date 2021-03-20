using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AppAcademico.Models
{
    public class Prueba
    {
        [Key]
        public int Id { get; set; }

        public string nombre { get; set; }
    }
}
