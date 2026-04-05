using DFTGames.Localization;

namespace Q17pD.PalmIsland.Interface
{
    public interface IObservable
    {
        public string NameKey { get; }
        public ObservableType Type { get; }
    }
    public enum ObservableType { None, Look, Interact }
}
