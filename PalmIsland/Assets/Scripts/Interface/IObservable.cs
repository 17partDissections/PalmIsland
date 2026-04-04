using DFTGames.Localization;

namespace Q17pD.PalmIsland.Interface
{
    public interface IObservable
    {
        public string NameKey { get; }
        public void ShowName(LocalizeTMPro nameText)
        {
            nameText.localizationKey = NameKey;
            nameText.UpdateLocale();
        }
        public void HideName(LocalizeTMPro nameText)
        {
            nameText.localizationKey = string.Empty;
            nameText.UpdateLocale();
        }
    }
}
