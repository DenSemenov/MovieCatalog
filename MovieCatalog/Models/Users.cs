using System.ComponentModel.DataAnnotations;

namespace MovieCatalog.Models
{
    public class Users
    {
        [Key]
        public string Login { get; set; }
        public string Password { get; set; }
    }
}