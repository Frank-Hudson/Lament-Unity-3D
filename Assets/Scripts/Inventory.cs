using System;
using System.Collections.Generic;
using System.Linq;

[Serializable]
public struct Inventory
{
    public List<ItemStack> items;

    public float FullWeight { get => items.Select(x => x.Weight).Sum(); }
}
