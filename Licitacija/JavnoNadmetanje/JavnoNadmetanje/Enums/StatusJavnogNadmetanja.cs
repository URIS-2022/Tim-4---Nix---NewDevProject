using System.ComponentModel.DataAnnotations;

namespace JavnoNadmetanje.Enums
{
    /// <summary>
    /// 3 moguca izbora statusa javnog nadmetanja obelezeni od 0 do 2 
    /// 0 - Prvi krug
    /// 1 - Drugi krug sa starim uslovima
    /// 2 - Drugi krug sa novim uslovima
    /// </summary>
    public enum StatusJavnogNadmetanja
    {
        #pragma warning disable CS1591 //nepotreban XML koment

        [Display(Name = "Prvi krug")] PrviKrug,
        [Display(Name = "Drugi krug sa starim uslovima")] DrugiKrugStariUslovi,
        [Display(Name = "Drugi krug sa novim uslovima")] DrugiKrugNoviUslovi

        #pragma warning restore CS1591 //nepotreban XML koment
    }
}
