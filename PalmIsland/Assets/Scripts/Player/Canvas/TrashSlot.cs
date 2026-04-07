using UnityEngine;
using UnityEngine.EventSystems;

namespace Q17pD.PalmIsland.Player.Canvas
{
    public class TrashSlot : MonoBehaviour, IDropHandler
    {
        private Inventory _inventory;
        private PointerStorage _pointerStorage;

        public void Init(PointerStorage pointerStorage, Inventory inventory) { _pointerStorage = pointerStorage; _inventory = inventory; }
        public void OnDrop(PointerEventData eventData)
        {
            if (_pointerStorage.ItemSlot != null)
            {
                _inventory.DropItem(_pointerStorage.ItemSlot.ItemNameKey.localizationKey);
                _pointerStorage.ItemSlot.ItemNameKey.localizationKey = string.Empty;
                _pointerStorage.ItemSlot.ItemDescriptionKey.localizationKey = string.Empty;
                _pointerStorage.ItemSlot.IconImage.sprite = _pointerStorage.ItemSlot.EmptyIconSprite;
                _pointerStorage.ItemSlot = null;
            }
        }
    }
}
