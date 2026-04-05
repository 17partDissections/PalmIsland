using Q17pD.PalmIsland.Interface;
using Q17pD.PalmIsland.Player;
using UnityEngine;

namespace Q17pD.PalmIsland.Items
{
    public class InGameItem : MonoBehaviour, IObservable, IInterectable
    {
        [SerializeField] private string _itemNameKey;
        [SerializeField] private ObservableType _type;
        public Sprite ItemIcon;
        public string NameKey { get => _itemNameKey; }
        public ObservableType Type { get => _type; }

        public void Interact(Inventory inventory = null, Player.Canvas.Canvas playerCanvas = null)
        {
            inventory.AddItem(gameObject, _itemNameKey);
            //playerCanvas.AddItem(this);
        }
    } 
}
