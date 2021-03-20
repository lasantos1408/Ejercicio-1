using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AppAcademico.Models
{
    public class Cursos
    {
        [Key]
        public int IdCurso { get; set; }

        public string NombreCurso { get; set; }

        public string Usuario { get; set; }

        //public ICollection<Evaluacion> Eval { get; set; }
    }
}
