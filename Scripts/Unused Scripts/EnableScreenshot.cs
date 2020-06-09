using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableScreenshot : MonoBehaviour
{

    public SnapshotCamera snapCam;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F12))
        {
            snapCam.CallTakeSnapshot();
        }
    }
}
