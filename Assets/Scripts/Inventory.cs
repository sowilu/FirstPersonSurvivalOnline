using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class InventoryItem
{
    public ItemData item;
    public int amount;

    public InventoryItem(ItemData item, int amount)
    {
        this.item = item;
        this.amount = amount;
    }
}

public class Inventory : MonoBehaviour
{
    public List<InventoryItem> items;

    public void AddItem(ItemData item, int amount)
    {
        var foundItem = items.Find(ii => ii.item.name == item.name);

        if (foundItem != null)
        {
            foundItem.amount += amount;
        }
        else
        {
            items.Add(new InventoryItem(item, amount));
        }
    }


    public bool HasItem(ItemData item, int amount)
    {
        var foundItem = items.Find(ii => ii.item.name == item.name);
        return foundItem != null && foundItem.amount >= amount;
    }


    public void RemoveItem(ItemData item, int amount)
    {
        var foundItem = items.Find(ii => ii.item.name == item.name);

        if (foundItem != null)
        {
            foundItem.amount -= amount;

            if (foundItem.amount <= 0)
            {
                items.Remove(foundItem);
            }
        }
    }


    public bool HasItems(List<InventoryItem> requirements)
    {
        foreach (var r in requirements)
        {
            if(!HasItem(r.item, r.amount))
                return false;
        }
        return true;
    }


    public void RemoveItems(List<InventoryItem> requirements)
    {
        foreach (var r in requirements)
        {
            RemoveItem(r.item, r.amount);
        }
    }
}
