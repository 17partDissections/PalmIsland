using Q17pD.PalmIsland.Interface;
using Q17pD.PalmIsland.Player;
using UnityEngine;

namespace Q17pD.PalmIsland.Entities
{
    public class InspectableItem : MonoBehaviour, IObservable, IInterectable
    {
        [SerializeField] private string _itemNameKey, _voicelineSubtitle;
        [SerializeField] private AudioClip _voiceline;
        public string NameKey { get => _itemNameKey; }
        public ObservableType Type { get => ObservableType.Inspect; }

        public void Interact(Inventory inventory = null, Player.Canvas.Canvas playerCanvas = null, AudioHandler audioHandler = null)
        {
            if (playerCanvas.Subtitle(_voicelineSubtitle, (_voiceline.length + 1)))
                audioHandler.PlaySound(SoundType.SFX, _voiceline);
        }
    } 
}
