using UnityEngine;
using System.Collections;

//[ExecuteInEditMode]
public class WoodRaycast : MonoBehaviour
{

    public Transform tree;
    public int totalTrees = 10;
    public float foliageWidth;
    public float foliageLength;

    // Use this for initialization
    void Start()
    {

        int spawned = 0;

        while (spawned < totalTrees)
        {

            Vector3 position = new Vector3(transform.position.x + Random.value * foliageWidth, transform.position.y, transform.position.z + Random.value * foliageLength);

            RaycastHit hit = new RaycastHit();

            if (Physics.Raycast(position, Vector3.down, out hit))
            {
                Transform newTree = Instantiate(tree, hit.point, Quaternion.Euler(new Vector3(0, Random.Range(0,360), 0)));
                //newTree.transform.SetParent(transform);
                newTree.name = gameObject.name + "_" + spawned;

            }

            spawned++;
        }



    }

    //    // Update is called once per frame
    //    void Update () {
    //
    //
    //    }
}
