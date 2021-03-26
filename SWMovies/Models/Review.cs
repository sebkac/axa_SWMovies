
using System.ComponentModel.DataAnnotations;

namespace SWMovies.Models
{
    public class Review
    {
        public int ID { get; set; }
        public string MovieID { get; set; }
        public string Comment { get; set; }
        [Range(1, 10)]
        public short Rating { get; set; }
        public string User { get; set; }
    }
}
