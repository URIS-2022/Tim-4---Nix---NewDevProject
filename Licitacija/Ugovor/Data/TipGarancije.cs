using System.ComponentModel;

namespace Ugovor.Data
{
    public enum TipGarancije
    {
        [Description("Jemstvo")] Jemstvo,
        [Description("Bankarska garancija")] BankarskaGarancija,
        [Description("Garancija nekretninom")] GarancijaNekretninom,
        [Description("Zirantska")] Zirantska,
        [Description("Uplata gotovinom")] UplataGotovinom
    }
}
