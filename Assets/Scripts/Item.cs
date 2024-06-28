using System;
using System.Collections.Generic;

[Serializable]
public struct Item
{
    public string name;
    public ItemData data;

    public float Weight { get => data.weightKgs; set => data.weightKgs = value; }

    [Serializable]
    public struct ItemData
    {
        public float weightKgs;
        public Rarity rarity;
        public ItemType type;
        public List<Actions.Action> actions;
    }

    [Serializable]
    public enum ItemType { weapon, tool, misc }

    [Serializable]
    public enum Rarity
    {
        common,
        uncommon,
        rare,
        epic,
        legendary,
        artefact,
    }
}
