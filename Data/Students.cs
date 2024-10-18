using System.ComponentModel.DataAnnotations;

namespace ExampleWeb.Data
{

    public class Students
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
    }
}
