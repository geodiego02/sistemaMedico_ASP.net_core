using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Websistmedico.Models
{
    [Table("tpaciente")]
    public class CPaciente
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string ap { get; set; }
        [Required]
        public string am { get; set; }
        [Required]
        public string nombres { get; set; }
        [Required]
        public int rut { get; set; }
        [Required]
        public string dv { get; set; }
        [Required]
        public string sexo { get; set; }
        [Required]
        [EmailAddress]
        public string correo { get; set; }
        [Required]
        public string prevision { get; set; }
        [Required]
        public int edad { get; set; }
        [Required]
        public int celular { get; set; }


    }
}