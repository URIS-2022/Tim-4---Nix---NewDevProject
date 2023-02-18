using System.ComponentModel.DataAnnotations;

namespace JavnoNadmetanje.Enums
{
    public enum KatastarskeOpstine 
    {
        [Display(Name = "Cantavir")] Cantavir,
        [Display(Name = "Backi Vinogradi")] BackiVinogradi,
        [Display(Name = "Bikovo")] Bikovo,
        [Display(Name = "Đuđin")] Đuđin,
        [Display(Name = "Žednik")] Žednik,
        [Display(Name = "Tavankut")]Tavankut,
        [Display(Name = "Bajmok")] Bajmok,
        [Display(Name = "Donji Grad")] DonjiGrad,
        [Display(Name = "Stari Grad")] StariGrad,
        [Display(Name = "Novi Grad")] NoviGrad,
        [Display(Name = "Palic")] Palic
    }
}
