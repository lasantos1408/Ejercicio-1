using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AppAcademico.Models
{
    public class Eval
    {
        [Key]
        public int IdEval { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal nota { get; set; }
        public int IdCurso { get; set; }
    }
}
