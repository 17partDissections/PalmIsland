using Q17pD.PalmIsland.Items;
using System.Collections.Generic;
using System.Linq;

namespace Q17pD.PalmIsland.Factories
{
    public class ItemObjectPool
    {
        public Dictionary<string, InGameItem> Items = new Dictionary<string, InGameItem>();
        public void AddToPool(InGameItem inGameItem) { Items.Add(inGameItem.NameKey, inGameItem); }
        public InGameItem GetFromPool(string itemNameKey)
        {
            if (!Items.ContainsKey(itemNameKey)) return null;
            InGameItem inGameItem = Items[itemNameKey];
            if (inGameItem == null) return null;
            inGameItem.gameObject.SetActive(true);
            return inGameItem;
        }
        public void DropBackToPool(InGameItem inGameItem) { if (inGameItem != null) inGameItem.gameObject.SetActive(false); }
    }
}
