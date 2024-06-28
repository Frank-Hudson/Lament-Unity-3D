using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

public class ItemAssets : MonoBehaviour
{
    [SerializeField] private TextAsset _itemsAsset;

    private List<Item> _items;
    public List<Item> Items { get => _items; }

    public Item FindItem(string name) => _items.Find(x => x.name == name);

    private void Awake()
    {
        _items = JsonConvert.DeserializeObject<List<Item>>(_itemsAsset.text);
    }
}
