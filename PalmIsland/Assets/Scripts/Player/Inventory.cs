using UnityEngine;
using System.Collections.Generic;
using System;
using Q17pD;
using Q17pD.PalmIsland.Factories;
using Q17pD.PalmIsland.Items;

namespace Q17pD.PalmIsland.Player
{
    public class Inventory : MonoBehaviour
    {
        [HideInInspector] public int InventoryCapacity;
        public int MaxInventoryCapacity;
        private List<String> _playerInventory = new List<String>();
        private AudioHandler _audioHandler;
        private ItemObjectPool _itemObjectPool;
        public void Init(AudioHandler audioHandler, ItemObjectPool itemObjectPool)
        {
            _audioHandler = audioHandler;
            _itemObjectPool = itemObjectPool;
        }
        public void AddItem(GameObject itemObject, string itemNameKey)
        {
            if (InventoryCapacity + 1 <= MaxInventoryCapacity)
            {
                _playerInventory.Add(itemNameKey);
                itemObject.SetActive(false);
            }
        }
        public void DropItem(string itemNameKey)
        {
            //_audioHandler.PlaySFX(item.ItemSound_Drop, 1);
            InGameItem itemFromPool = _itemObjectPool.GetFromPool(itemNameKey);
            itemFromPool.transform.position = transform.position + transform.TransformDirection(Vector3.fwd);
        }
    }
}
