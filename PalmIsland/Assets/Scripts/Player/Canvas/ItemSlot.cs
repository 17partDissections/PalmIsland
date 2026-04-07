using DFTGames.Localization;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Q17pD.PalmIsland.Player.Canvas
{
    public class ItemSlot : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IDropHandler
    {
        public Image BgImage;
        public Image OutlineImage;
        public Image IconImage;
        public Sprite EmptyIconSprite;
        public LocalizeTMPro ItemNameKey;
        public LocalizeTMPro ItemDescriptionKey;

        private int _clicks;
        private PointerStorage _pointerStorage;

        public void Init(PointerStorage pointerStorage) { _pointerStorage = pointerStorage; ItemDescriptionKey.gameObject.SetActive(false); }

        public void OnPointerEnter(PointerEventData eventData) { ItemDescriptionKey.gameObject.SetActive(true); }
        public void OnPointerExit(PointerEventData eventData) { ItemDescriptionKey.gameObject.SetActive(false); }
        public void OnPointerClick(PointerEventData eventData)
        {
            _clicks++;
            if(_clicks == 2)
            {
                if (!OutlineImage.enabled)
                    OutlineImage.enabled = true;
                else
                    OutlineImage.enabled = false;
                _clicks = 0;
            }
        }
        public void OnPointerDown(PointerEventData eventData)
        {
            _pointerStorage.ItemSlot = this;
        }
        public void OnDrop(PointerEventData eventData)
        {
            if (_pointerStorage.ItemSlot != null && ItemNameKey.localizationKey == string.Empty)
            {
                ItemNameKey.localizationKey = _pointerStorage.ItemSlot.ItemNameKey.localizationKey;
                ItemDescriptionKey.localizationKey = _pointerStorage.ItemSlot.ItemDescriptionKey.localizationKey;
                ItemNameKey.UpdateLocale(); ItemDescriptionKey.UpdateLocale();
                IconImage.sprite = _pointerStorage.ItemSlot.IconImage.sprite;
                _pointerStorage.ItemSlot.ItemNameKey.localizationKey = string.Empty;
                _pointerStorage.ItemSlot.ItemDescriptionKey.localizationKey = string.Empty;
                _pointerStorage.ItemSlot.ItemNameKey.UpdateLocale(); _pointerStorage.ItemSlot.ItemDescriptionKey.UpdateLocale();
                _pointerStorage.ItemSlot.IconImage.sprite = _pointerStorage.ItemSlot.EmptyIconSprite;
                _pointerStorage.ItemSlot = null;
            }
        }
    }
}
