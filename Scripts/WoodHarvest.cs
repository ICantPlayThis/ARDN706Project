using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Sticking with this for my main wood pickup script
public class WoodHarvest : MonoBehaviour
{

    GameObject thisWood;
    private bool isCollected = false;
    public bool harvestWood = false;



    void Start()
    {
        thisWood = transform.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
       if (harvestWood == true && isCollected == false)
        {
            Destroy(thisWood);
            isCollected = true;
        }
    }     
}
