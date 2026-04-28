using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public float interactDistance = 3;
    public LayerMask interactMask;

    private Camera cam;
    private SurvivalStats stats;
    private Inventory inventory;
    
    void Start()
    {
        cam = Camera.main;
        stats = GetComponent<SurvivalStats>();
        inventory = GetComponent<Inventory>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));

            if (Physics.Raycast(ray, out RaycastHit hit, interactDistance, interactMask))
            {
                var consumable = hit.collider.GetComponent<Consumable>();

                if (consumable != null)
                {
                    stats.Eat(consumable.hungerRestore);
                    stats.Drink(consumable.thirstRestore);

                    if (consumable.destructAfterUse)
                    {
                        Destroy(consumable.gameObject);
                    }
                }
                
                var node = hit.collider.GetComponent<ResourceNode>();
                if (node != null && inventory != null)
                {
                    node.Harvest(inventory);
                }
                
            }
        }
    }
}
