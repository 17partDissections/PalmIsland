using UnityEngine;
using System.Collections.Generic;
using Q17pD.PalmIsland.Items;

namespace Q17pD.PalmIsland.Factories
{
    [CreateAssetMenu(fileName = "New Item Holder", menuName = "Scriptable Objects/ItemHolder")]
    public class ItemHolder : ScriptableObject { public List<InGameItem> Items; }
}
