using System.ComponentModel.DataAnnotations;

namespace CrudNet7MVC.Models
{

    //Un modelo es una tabla en la base de datos
    public class Contacto
    {

        [Key] //genera el id como clave primaria
        public int Id { get; set; }  //prop atajo

        [Required(ErrorMessage ="El nombre es obligatorio")] // campo obligatorio
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El telefono es obligatorio")]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "El celular es obligatorio")]
        public string Celular { get; set; }

        [Required(ErrorMessage = "El email es obligatorio")]
        public string Email { get; set; }

        public DateTime FechaCreacion { get; set; } // buena practica para tener un registro de la fecha del registro

    }
}
