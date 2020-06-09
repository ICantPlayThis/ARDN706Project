using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// use on GameManager object
public class ResourceManager : MonoBehaviour
{

    // Define List components
    public class Tree
    {
        public string terrainName { get; set; }
        public int treeINDEX { get; set; }
        public float respawnTime { get; set; }
        public Transform marker { get; set; }

        //Constructor

        public Tree(string _terrainName, int _treeINDEX, float _respawnTime, Transform _marker)
        {
            terrainName = _terrainName;
            treeINDEX = _treeINDEX;
            respawnTime = _respawnTime;
            marker = _marker;
        }

    }

    //Tree harvest script access
    public List<Tree> managedTrees = new List<Tree>();

    void Start()
    {
        // Scan for tree to "respawn" (remove cube, make available again) everry 15 seconds
        // Adjust to your needs
        InvokeRepeating("RespawnTree", 15, 15);
    }


    private void RespawnTree()
    {
        if (managedTrees.Count == 0)
            return;

        // Remove the demo cube and allowing tree to be used again
        for (int cnt=0; cnt < managedTrees.Count; cnt++)
        {
            if (managedTrees[cnt].respawnTime < Time.time)
            {
                Destroy(managedTrees[cnt].marker.gameObject);
                managedTrees.RemoveAt(cnt);
                return;
            }
        }
    }

    public void AddTerrainTree(string _terrainName, int _treeIDX, float _respawnTime, Transform _marker)
    {
        managedTrees.Add(new Tree(_terrainName, _treeIDX, _respawnTime, _marker));
    }
}
