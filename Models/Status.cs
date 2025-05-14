using System.ComponentModel.DataAnnotations;

namespace Biblioteca.Models
{
    public enum Status
    {
        [Display(Name = "QUERO LER")]
        QUERO_LER,

        [Display(Name = "LENDO")]
        LENDO,

        [Display(Name = "COMPLETO")]
        COMPLETO
    }
}

