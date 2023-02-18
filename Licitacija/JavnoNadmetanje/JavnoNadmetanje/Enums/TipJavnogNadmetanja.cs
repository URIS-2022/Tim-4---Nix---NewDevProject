using System.ComponentModel.DataAnnotations;

namespace JavnoNadmetanje.Enums
{
    public enum TipJavnogNadmetanja
    {
        [Display(Name = "Javna licitacija")] JavnaLicitacija,
        [Display(Name = "Otvaranje zatvorenih ponuda")] OtvaranjeZatvorenihPonuda
    }
}
