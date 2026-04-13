using Q17pD.PalmIsland.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Q17pD.PalmIsland.Factories
{
    public class ItemObjectPool
    {
        public Dictionary<string, CollectableItem> Items = new Dictionary<string, CollectableItem>();
        public void AddToPool(CollectableItem inGameItem) { Items.Add(inGameItem.NameKey, inGameItem); }
        public CollectableItem GetFromPool(string itemNameKey)
        {
            if (!Items.ContainsKey(itemNameKey)) return null;
            CollectableItem inGameItem = Items[itemNameKey];
            if (inGameItem == null) return null;
            inGameItem.gameObject.SetActive(true);
            return inGameItem;
        }
        public void DropBackToPool(CollectableItem inGameItem) { if (inGameItem != null) inGameItem.gameObject.SetActive(false); }
    }
}
