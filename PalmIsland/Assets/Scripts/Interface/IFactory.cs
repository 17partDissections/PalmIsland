using Q17pD.PalmIsland.Items;

namespace Q17pD.PalmIsland.Interface
{
    public interface IFactory 
    {
        public InGameItem Create(string neededItemNameKey);
    }
}
