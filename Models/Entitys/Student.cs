using System.ComponentModel.DataAnnotations;

namespace ExampleWeb.Models.Entitys
{
    public class Student
    {
        public Guid Id { get; set; }

        [Display(Name = "Nombre Completo")]
        public string Name { get; set; }
        [Display(Name = "Correo")]
        public string Email { get; set; }
        [Display(Name = "Telefono")]
        public string Phone { get; set; }
        [Display(Name = "Usuario Activo")]
        public bool IsActive { get; set; }
    }
}
