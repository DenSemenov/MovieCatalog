using System.ComponentModel.DataAnnotations.Schema;

namespace MovieCatalog.Models
{
    public class Movies
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public int year { get; set; }
        public string producer { get; set; }
        public string user { get; set; }
        public string poster { get; set; }
    }
}