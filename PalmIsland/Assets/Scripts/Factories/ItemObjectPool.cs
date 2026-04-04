using Q17pD.PalmIsland.Interface;
using Q17pD.PalmIsland.Items;
using System.Collections.Generic;
using System.Linq;

namespace Q17pD.PalmIsland.Factories
{
    public class ItemObjectPool
    {
        private IFactory _itemFactory;
        public Dictionary<string, List<InGameItem>> Items = new Dictionary<string, List<InGameItem>>();

        public ItemObjectPool(Q17pD.PalmIsland.Interface.IFactory factory, ItemHolder itemHolder, int initObjectCountPerId = 1)
        {
            _itemFactory = factory;
            foreach (var item in itemHolder.Items) { for (int i = 0; initObjectCountPerId > i; i++) { CreateInstance(item.NameKey); } }
        }
        private InGameItem CreateInstance(string itemNameKey)
        {
            InGameItem createdItem = null;

            if (Items.ContainsKey(itemNameKey))
            {
                createdItem = _itemFactory.Create(itemNameKey);
                Items[itemNameKey].Add(createdItem);
            }
            else
            {
                createdItem = _itemFactory.Create(itemNameKey);
                Items.Add(itemNameKey, new List<InGameItem>() { createdItem });
            }
            createdItem.gameObject.SetActive(false);
            return createdItem;
        }

        public InGameItem GetFromPool(string itemNameKey)
        {
            InGameItem inGameItem = Items[itemNameKey].FirstOrDefault(x=>!x.gameObject.activeSelf);
            if (inGameItem == null)
                inGameItem = CreateInstance(itemNameKey);
            inGameItem.gameObject.SetActive(true);
            return inGameItem;
        }
        public void DropBackToPool(InGameItem inGameItem) { inGameItem.gameObject.SetActive(false); }
    }
}
