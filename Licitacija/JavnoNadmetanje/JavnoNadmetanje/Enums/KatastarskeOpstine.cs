using System.ComponentModel.DataAnnotations;

namespace JavnoNadmetanje.Enums
{
    /// <summary>
    /// 11 mogucih izbor razlicitih delova opstine Subotica
    /// oni su u sistemu obelezeni brojevima od 0 do 10
    /// 0 - Cantavir
    /// 1 - Backi Vinogradi
    /// 2 - Bikovo
    /// 3 - Djudjin
    /// 4 - Zednik
    /// 5 - Tavankut
    /// 6 - Bajmok
    /// 7 - Donji Grad
    /// 8 - Stari Grad
    /// 9 - Novi Grad
    /// 10 - Palic
    /// </summary>
    public enum KatastarskeOpstine 
    {
        #pragma warning disable CS1591 //nepotreban XML koment

        [Display(Name = "Cantavir")] Cantavir,
        [Display(Name = "Backi Vinogradi")] BackiVinogradi,
        [Display(Name = "Bikovo")] Bikovo,
        [Display(Name = "Djudjin")] Djudjin,
        [Display(Name = "Zednik")] Zednik,
        [Display(Name = "Tavankut")] Tavankut,
        [Display(Name = "Bajmok")] Bajmok,
        [Display(Name = "Donji Grad")] DonjiGrad,
        [Display(Name = "Stari Grad")] StariGrad,
        [Display(Name = "Novi Grad")] NoviGrad,
        [Display(Name = "Palic")] Palic

        #pragma warning restore CS1591 //nepotreban XML koment
    }
}
