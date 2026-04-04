using Q17pD.PalmIsland.Items;
using Zenject;

namespace Q17pD.PalmIsland.Factories
{
    public class ItemFactory : IFactory
    {
        private ItemHolder _itemHolder;
        private DiContainer _container;

        public ItemFactory(ItemHolder itemHolder, DiContainer container)
        {
            _itemHolder = itemHolder;
            _container = container;
        }
        public InGameItem Create(string itemNameKey)
        {
            InGameItem neededItem = null;//GameObject.Instantiate(_itemHolder.Items.FirstOrDefault(x=>x.ItemID == itemID));
            if (neededItem != null)
            {
                _container.Inject(neededItem);
                return neededItem;
            }
            else 
                throw new System.Exception("theres no item with that ItemID: " + itemNameKey);
                
        }
    }
}


