using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceNode : MonoBehaviour
{
    public ItemData item;
    public int amount = 5;

    public void Harvest(Inventory inventory)
    {
        inventory.AddItem(item, amount);
        Destroy(gameObject);
    }
}
