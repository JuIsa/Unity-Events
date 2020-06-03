using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorDetect : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        MeshCollider mc = GetComponent<MeshCollider>();

        Vector3 start = new Vector3(20.0f, .0f, .0f);
        Vector3 target = new Vector3(-100.0f, .0f, .0f);

        Debug.DrawRay(start,target, Color.red, 15f);
        RaycastHit objectHit;
        if (Physics.Raycast(new Ray(start, target), out objectHit)){
            Mesh mesh = mc.sharedMesh;

            int index = mesh.triangles[objectHit.triangleIndex * 3];
            int ColorIndex = (int)(mesh.uv[index].x * 16);
            Debug.Log(ColorIndex);
        }
    }

    // Update is called once per frame
    
}
