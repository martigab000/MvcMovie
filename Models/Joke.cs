using System.ComponentModel.DataAnnotations;

namespace MvcMovie.Models{

    public class Joke
    {
        public int id { get; set; }
        public string type { get; set; }
        public string setup { get; set; }
        public string punchline { get; set; }
    }
}