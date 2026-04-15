using Q17pD.PalmIsland.Player;
using Q17pD.PalmIsland.Player.Canvas;

namespace Q17pD.PalmIsland.Interface
{
    public interface IInterectable
    {
        public void Interact(Inventory inventory = null, Canvas playerCanvas = null, AudioHandler audioHandler = null);
    }
}
