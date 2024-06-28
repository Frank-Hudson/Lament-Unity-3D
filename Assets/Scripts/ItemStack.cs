using System;

[Serializable]
public struct ItemStack
{
    public Item item;
    public byte count;

    public float Weight { get => item.Weight * (float)count; }
}
