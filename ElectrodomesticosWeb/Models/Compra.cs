using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ElectrodomesticosWeb.Models
{
    public class Compra
    {
        public int Id { get; set; }
        [DisplayName("Nombre del Cliente")]
        [Required(ErrorMessage = "Es requerido ingresar el nombre del cliente")]
        public string NombreCliente { get; set; }

        [DisplayName("Número de tarjeta")]
        [Required(ErrorMessage = "Es requerido ingresar el número de tarjeta")]
        [DataType(DataType.CreditCard)]//valida que se ingrese un número de tarjeta
        public string NumTarjeta { get; set; }
        [Required(ErrorMessage = "Es requerido ingresar la dirección para guardar")]
        public string Direccion { get; set; }
        [Required(ErrorMessage = "Es requerido ingresar el número de teléfono")]
        public string Telefono { get; set; }

        public virtual ICollection<DetalleCompra> DetalleCompas { get; set; }

    }
}