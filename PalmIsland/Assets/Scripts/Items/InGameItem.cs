using Q17pD.PalmIsland.Factories;
using Q17pD.PalmIsland.Interface;
using Q17pD.PalmIsland.Player;
using UnityEngine;
using Zenject;

namespace Q17pD.PalmIsland.Items
{
    public class InGameItem : MonoBehaviour, IObservable, IInterectable
    {
        [SerializeField] private ObservableType _type;
        [SerializeField] private string _itemNameKey;
        public Sprite ItemIcon;
        public string NameKey { get => _itemNameKey; }
        public ObservableType Type { get => _type; }

        [Inject] private void Construct(ItemObjectPool pool) { pool.AddToPool(this); }

        public void Interact(Inventory inventory = null, Player.Canvas.Canvas playerCanvas = null)
        {
            inventory.AddItem(gameObject, _itemNameKey);
            playerCanvas.AddItem(this);
        }
    } 
}
