namespace Biblioteca.Models
{
    public class LivroModel
    {
        public int id { get; set; }

        public String titulo { get; set;}

        public Autores autor { get; set; }

        public String sumario { get; set; }

        public Genero genero { get; set; }

        public Status status { get; set; }


    }
}
