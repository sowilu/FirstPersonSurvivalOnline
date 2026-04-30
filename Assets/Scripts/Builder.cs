using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Builder : MonoBehaviour
{
    public RecipeData currentRecipe;
    public float buildDistance = 5;

    private GameObject preview;
    private Inventory inventory;
    private Camera cam;


    void Start()
    {
        inventory = GetComponent<Inventory>();
        cam = Camera.main;
    }


    void Update()
    {
        HandlePreview();

        if (Input.GetKeyDown(KeyCode.B))
        {
            preview.SetActive(!preview.activeSelf);
        }

        if (preview.activeSelf && Input.GetMouseButtonDown(0))
        {
            TryBuild();
        }
    }

    void HandlePreview()
    {
        if (preview == null)
        {
            preview = Instantiate(currentRecipe.preview);
            preview.SetActive(false);
        }

        var pos = cam.transform.position + cam.transform.forward * buildDistance;
        pos.y = 0; //or raycast in non flat world
        preview.transform.position = pos;
    }

    void TryBuild()
    {
        if (inventory.HasItems(currentRecipe.requirements))
        {
            inventory.RemoveItems(currentRecipe.requirements);
            Instantiate(currentRecipe.prefab, preview.transform.position, preview.transform.rotation);
        }
        else
        {
            print("Not enough resources");
        }
    }
}