using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ElectrodomesticosWeb.Models
{
    public class Categoria
    {

        public int Id { get; set; }
        [DisplayName("Nombre de la categoria")]
        [Required]
        public string Nombre { get; set; }
        public virtual ICollection<Producto> Productos { get; set; }

    }
}