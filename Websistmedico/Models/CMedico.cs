using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Websistmedico.Models
{

    [Table("tmedico")]
    public class CMedico
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
        [EmailAddress]
        public string correo { get; set; }
        [Required]
        public string titulo { get; set; }
        [Required]
        public string especialidad { get; set; }
        [Required]
        public int celular { get; set; }
        [Required]
        public string comuna { get; set; }


    }
}