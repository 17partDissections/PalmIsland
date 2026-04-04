using DFTGames.Localization;
using Q17pD.PalmIsland.Items;
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
        [HideInInspector] public LocalizeTMPro ItemNameText;
        [SerializeField] private GameObject _HUD;
        [SerializeField] private GameObject _inventory;
        [SerializeField] private List<ItemSlot> _itemSlots;
        private PlayerActionMap _actionMap;

        public void Init(PlayerActionMap actionMap)
        {
            Crosshair = _HUD.GetComponentInChildren<Image>();
            ItemNameText = _HUD.GetComponentInChildren<LocalizeTMPro>();
            _actionMap = actionMap;
            _actionMap.Player.Inventory.started += OpenOrCloseVisualInventory;
        }
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
        public void AddItem(InGameItem inGameItem)
        {
            ItemSlot freeSlot = _itemSlots.FirstOrDefault(x => x.ItemNameKey.localizationKey == "Empty");
            freeSlot.ItemNameKey.localizationKey = inGameItem.NameKey;
            freeSlot.ItemDescriptionKey.localizationKey = inGameItem.NameKey + "Desc";
            freeSlot.IconImage.sprite = inGameItem.ItemIcon;
            freeSlot.IconImage.gameObject.SetActive(true);
        }
    }
}
