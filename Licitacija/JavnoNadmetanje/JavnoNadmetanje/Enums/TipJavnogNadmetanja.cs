using System.ComponentModel.DataAnnotations;

namespace JavnoNadmetanje.Enums
{
    /// <summary>
    /// 2 moguca izbora tipa javnog nadmetanja obelezena 0 i 1
    /// 0 - Javna licitacija
    /// 1 - Otvaranje zatvorenih ponuda
    /// </summary>
    public enum TipJavnogNadmetanja
    {
        #pragma warning disable CS1591 //nepotreban XML koment

        [Display(Name = "Javna licitacija")] JavnaLicitacija,
        [Display(Name = "Otvaranje zatvorenih ponuda")] OtvaranjeZatvorenihPonuda

        #pragma warning restore CS1591 //nepotreban XML koment
    }
}
