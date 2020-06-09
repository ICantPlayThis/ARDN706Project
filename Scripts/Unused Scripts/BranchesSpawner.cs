using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.Networking;

public class BranchesSpawner : MonoBehaviour
{

    TreeInstance[] trees;
    private int yourPrototypeIndex = 3;
    public bool collectWood;

    // Player, Range
    public int harvestTreeDistance; // Set min distance from player to Tree
    public bool rotatePlayer = true; // Should we rotate the player?
    public Transform myTransform; // Cache player transform

    // Terrains, Hit
    public Terrain terrain; // Get terrain component
    private RaycastHit hit; // For hit methods
    private string lastTerrain; // To avoid reassignment/ GetComponent on every Terrain click




    void Start()
    {
        lastTerrain = null;
        var terrain = GetComponent<Terrain>();
        trees = terrain.terrainData.treeInstances;
        trees = trees.Where(
            t => t.prototypeIndex == yourPrototypeIndex
            ).ToArray();
        Debug.Log(trees.Length);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 30f))
            {
                // Did we click a Terrain?
                if (hit.collider.gameObject.GetComponent<Terrain>() == null)
                    return;

                // Was it the terrain or a terrain tree, based on SampleHeight();
                float groundHeight = terrain.SampleHeight(hit.point);

                if (hit.point.y - .2f > groundHeight)
                {
                    if (CheckProximity())
                        HarvestWood();
                }
            }
        }
    }
        private bool CheckProximity()
    {
        bool inRange = true;
        float clickDist = Vector3.Distance(myTransform.position, hit.point);
        if (clickDist > harvestTreeDistance)
        {
            Debug.Log("Out of range");
            inRange = false;
        }
        return inRange;
    }

    private void HarvestWood()
    {
        int treeIDX = -1;
        int treeCount = trees.Length;
        float treeDist = harvestTreeDistance;
        Vector3 treePos = new Vector3(0, 0, 0);

        // Loop through every tree in array

        for (int i=0; i < treeCount; i++)
        {
            Vector3 thisTreePos = Vector3.Scale(trees[i].position, terrain.terrainData.size) + terrain.transform.position;
            float thisTreeDist = Vector3.Distance(thisTreePos, hit.point);

            if (thisTreeDist < treeDist)
            {
                treeDist = thisTreeDist;
                treePos = thisTreePos;
                treeIDX = i;
            }
        }

        if (treeIDX == -1)
        {
            Debug.Log("Out of Range");
            return;
        }

        if (collectWood == true)
        {

            GameObject marker = GameObject.CreatePrimitive(PrimitiveType.Cube);
            marker.transform.position = treePos;

            if (rotatePlayer)
            {
                Vector3 lookRot = new Vector3(hit.point.x, myTransform.position.y, hit.point.z);
                myTransform.LookAt(lookRot);
            }
        }
    }
}