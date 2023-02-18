using System.ComponentModel.DataAnnotations;

namespace JavnoNadmetanje.Enums
{
    public enum StatusJavnogNadmetanja
    {
        [Display(Name = "Prvi krug")] PrviKrug,
        [Display(Name = "Drugi krug sa starim uslovima")] DrugiKrugStariUslovi,
        [Display(Name = "Drugi krug sa novim uslovima")] DrugiKrugNoviUslovi
    }
}
