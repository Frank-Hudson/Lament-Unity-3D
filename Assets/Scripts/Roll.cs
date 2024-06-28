using System;
using System.Collections.Generic;

[Serializable]
public struct Roll
{
    public List<Dice> dice;

    [Serializable]
    public struct Dice
    {
        public uint count;
        public DiceSides sides;
    }

    [Serializable]
    public enum DiceSides
    {
        D2 = 2,
        D4 = 4,
        D6 = 6,
        D8 = 8,
        D10 = 10,
        D12 = 12,
        D20 = 20,
        D100 = 100,
    }
}
