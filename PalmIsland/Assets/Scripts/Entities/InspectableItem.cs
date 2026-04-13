using Q17pD.PalmIsland.Interface;
using Q17pD.PalmIsland.Player;
using UnityEngine;

namespace Q17pD.PalmIsland.Entities
{
    public class InspectableItem : MonoBehaviour, IObservable, IInterectable
    {
        [SerializeField] private string _itemNameKey, _quoteSubtitle;
        [SerializeField] private AudioClip _quote;
        public string NameKey { get => _itemNameKey; }
        public ObservableType Type { get => ObservableType.Inspect; }

        public void Interact(Inventory inventory = null, Player.Canvas.Canvas playerCanvas = null)
        {
            //play monologue n show subtitle
        }
    } 
}
