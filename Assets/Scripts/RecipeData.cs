using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RecipeData", menuName = "Survival/Recipe")]
public class RecipeData : ScriptableObject
{
   public string name;
   public GameObject preview;
   public GameObject prefab;
   public List<InventoryItem> requirements;
}
