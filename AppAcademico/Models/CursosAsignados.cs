using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AppAcademico.Models
{
    public class CursosAsignados
    {
        public int IdCurso { get; set; }

        public string NombreCurso { get; set; }

        public string Usuario { get; set; }

        [Key]
        public int IdCursosAsignados { get; set; }
    }
}
