using Q17pD.PalmIsland.Factories;
using Q17pD.PalmIsland.Interface;
using Q17pD.PalmIsland.Player;
using UnityEngine;
using Zenject;

namespace Q17pD.PalmIsland.Entities
{
    public class CollectableItem : MonoBehaviour, IObservable, IInterectable
    {
        [SerializeField] private string _itemNameKey;
        public Sprite ItemIcon;
        public string NameKey { get => _itemNameKey; }
        public ObservableType Type { get => ObservableType.Interact; }

        [Inject] private void Construct(ItemObjectPool pool) { pool.AddToPool(this); }

        public void Interact(Inventory inventory = null, Player.Canvas.Canvas playerCanvas = null, AudioHandler audioHandler = null)
        {
            inventory.AddItem(gameObject, _itemNameKey);
            playerCanvas.AddItem(this);
        }
    } 
}
