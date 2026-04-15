using DFTGames.Localization;
using Q17pD.PalmIsland.Interface;
using Q17pD.PalmIsland.Entities;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace Q17pD.PalmIsland.Player.Canvas
{
    public class Canvas : MonoBehaviour
    {
        [HideInInspector] public Image Crosshair;
        [SerializeField] private GameObject _HUD, _inventory;
        [SerializeField] private Subtitles _subtitles;
        [SerializeField] private Sprite _empty, _crosshairInspect, _crosshairInteract;
        [SerializeField] private List<ItemSlot> _itemSlots;
        [SerializeField] private TrashSlot _trashSlot;
        private LocalizeTMPro _itemNameText;
        private PlayerActionMap _actionMap;

        public void Init(PlayerActionMap actionMap, Inventory inventory)
        {
            Crosshair = _HUD.GetComponentInChildren<Image>();
            _itemNameText = _HUD.GetComponentInChildren<LocalizeTMPro>();
            _actionMap = actionMap;
            _actionMap.Player.Inventory.started += OpenOrCloseVisualInventory;
            PointerStorage pointerStorage = new PointerStorage();
            foreach (var slot in _itemSlots) slot.Init(pointerStorage);
            _trashSlot.Init(pointerStorage, inventory);
        }
        public void ChangeCrosshair(ObservableType crosshair = ObservableType.None, string key = "")
        {
            bool type = crosshair == ObservableType.Inspect || crosshair == ObservableType.Interact;
            Crosshair.sprite = type ? (crosshair == ObservableType.Inspect ? _crosshairInspect : _crosshairInteract) : _empty; //dis is insane
            _itemNameText.localizationKey = type ? key : "";
            _itemNameText.UpdateLocale();
        }
        public bool Subtitle(string key, float time) { return _subtitles.Subtitle(key, time); }
        private void OpenOrCloseVisualInventory(InputAction.CallbackContext context)
        {
            if (!_inventory.activeSelf)
            {
                _HUD.gameObject.SetActive(false);
                _inventory.gameObject.SetActive(true);
                Cursor.visible = true; Cursor.lockState = CursorLockMode.None;
                _actionMap.Player.Look.Disable();
                _actionMap.Player.Move.Disable();
            }
            else
            {
                _HUD.gameObject.SetActive(true);
                _inventory.gameObject.SetActive(false);
                Cursor.visible = false; Cursor.lockState = CursorLockMode.Locked;
                _actionMap.Player.Look.Enable();
                _actionMap.Player.Move.Enable();
            }
        }
        public void AddItem(CollectableItem inGameItem)
        {
            ItemSlot freeSlot = _itemSlots.FirstOrDefault(x => x.ItemNameKey.localizationKey == string.Empty);
            freeSlot.ItemNameKey.localizationKey = inGameItem.NameKey;
            freeSlot.ItemDescriptionKey.localizationKey = inGameItem.NameKey + "Desc";
            freeSlot.IconImage.sprite = inGameItem.ItemIcon;
            freeSlot.IconImage.gameObject.SetActive(true);
        }
    }
}
