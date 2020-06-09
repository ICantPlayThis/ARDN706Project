using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRaycast : MonoBehaviour
{
    // Variables
    RaycastHit hit;
    private Transform myTransform; // cache player transformation
    public int harvestWoodDistance = 10; // min distance from player to wood
    public bool rotatePlayer = true; // should we rotate the player

    public Inventory inventoryScript;
    public float woodIntensity = 20;

void Start()
    {
        myTransform = transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            Debug.DrawRay(ray.origin, ray.direction * 10, Color.red, harvestWoodDistance, false);
            if (Physics.Raycast(ray, out hit, harvestWoodDistance))
            {
                if (hit.collider.CompareTag("wood")) // if ray hits a collider with a wood tag
                    HarvestWood();

                else if (hit.collider.CompareTag("campfire")) // if ray hits a collider with a campfire tag
                    DepositWood();
            }    
        }
    }

    private void HarvestWood()
    {
        Debug.Log("Harvested wood!");
        WoodHarvest woodScript = hit.collider.transform.parent.gameObject.GetComponent<WoodHarvest>();
        woodScript.harvestWood = true;

        // Add wood value to inventory
        inventoryScript.woodCollected++;
    }


    private void DepositWood()
    {
        Debug.Log("Deposited wood!");
        ControlLight lightScript = hit.collider.transform.parent.parent.gameObject.GetComponent<ControlLight>();

        // check if inventory is not 0
        if (inventoryScript.woodCollected > 0)
        {
            // Remove wood value from inventory
            inventoryScript.woodCollected--;

            lightScript.lightIntensityTemp += woodIntensity;
        }
    }
}
