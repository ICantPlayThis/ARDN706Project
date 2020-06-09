using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BranchGenerator : MonoBehaviour
{
    public int numberOfObjects;
    public int currentObjects;
    public GameObject branchToPlace;

    private float randomX;
    private float randomZ;

    private Terrain terrain;
    private string lastTerrain;
    private GameObject woodObject; // prefab
    private RaycastHit hit;

    //terrain size
    private int terrainMax = 500;
    private int terrainMin = -500;

    // Start is called before the first frame update
    void Start()
    {
        lastTerrain = null;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentObjects <= numberOfObjects)
        {
            randomX = Random.Range(terrainMin, terrainMax);
            randomZ = Random.Range(terrainMin, terrainMax);

            if (Physics.Raycast(new Vector3(randomX, terrainMax - 5f, randomZ), -Vector3.up, out hit))
            {
                // Did we hit a Terrain?
                if (hit.collider.gameObject.GetComponent<Terrain>() == null)
                    return;

                // Did we click on the same Terrain as last time? (or very first time?)
                if (lastTerrain == null || lastTerrain != hit.collider.name)
                {
                    terrain = hit.collider.gameObject.GetComponent<Terrain>();
                    lastTerrain = terrain.name;
                }

                // Was it the terrain or a terrain tree, based on sampleHeight();
                float groundHeight = terrain.SampleHeight(hit.point);
                if (hit.point.y - .2f > groundHeight)
                {
                    // It's a terrain tree
                }
            }

        }
    }
}
