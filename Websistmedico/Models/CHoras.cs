using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Websistmedico.Models
{

    [Table("thoras")]
    public class CHoras
    {
        [Key]
        public int id { get; set; }
        public string fecha { get; set; }
        public string hora { get; set; }
        public string ap   { get; set; }
        public string nombre { get; set; }
        public string especialidad { get; set; }
        public string estado { get; set; }
        public string paciente { get; set; }

    }
}