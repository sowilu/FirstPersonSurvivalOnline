using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

[System.Serializable]
public class LootItem
{
    public GameObject itemPrefab;
    public int amount;
    public float dropChance;
    public bool dropOneOnFailure;
}

public class ResourceNode : MonoBehaviour
{
    public LootItem[] lootItems;
    public int maxHealth = 5;
    public ItemData item;
    public int amount = 5;

    private int health;

    private void Start()
    {
        health = maxHealth;
    }

    public void Harvest(Inventory inventory)
    {
        health--;
        health = Mathf.Clamp(health, 0, maxHealth);

        if (health <= 0)
        {
            if (lootItems.Length > 0)
            {
                foreach (var i in lootItems)
                {
                    if (Random.Range(0f, 1f) <= i.dropChance)
                    {
                        for (int j = 0; j < i.amount; j++)
                        {
                            SpawnLoot(i.itemPrefab);
                        }
                    }
                    else if (i.dropOneOnFailure)
                    {
                        SpawnLoot(i.itemPrefab);
                    }
                }
            }
            else
            {
                inventory.AddItem(item, amount);
            }
            Destroy(gameObject);
        }
        
    }


    void SpawnLoot(GameObject itemPrefab)
    {
        var pos = transform.position;
        pos.x += Random.Range(-1, 1);
        pos.y++;
        pos.z += Random.Range(-1, 1);
                    
        var rot = new Vector3();
        rot.x = Random.Range(0, 360);
        rot.y = Random.Range(0, 360);
        rot.z = Random.Range(0, 360);
                    
        Instantiate(itemPrefab, pos, Quaternion.Euler(rot));
    }
}
