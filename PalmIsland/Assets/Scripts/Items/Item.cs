using UnityEngine;
namespace Q17pD.PalmIsland.Items
{
    [CreateAssetMenu(fileName = "NewItem", menuName = "Items")]
    public class Item : ScriptableObject
    {
        [Header("Locales")]
        public string ItemNameKey;
        public string ItemDescKey;
        public Sprite ItemIcon;
        [Header("Sounds")]
        public AudioClip ItemSound_Pickup;
        public AudioClip ItemSound_Drop;
        public AudioClip ItemSound_Use;
    }
}