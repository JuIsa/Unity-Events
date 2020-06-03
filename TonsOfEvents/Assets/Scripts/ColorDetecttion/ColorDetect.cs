using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorDetect : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        MeshCollider mc = GetComponent<MeshCollider>();

        Vector3 start = new Vector3(2.0f, 0.1f, 0.0f);
        Vector3 target = new Vector3(-2.0f,.0f,.0f);

        Debug.DrawRay(start,target, Color.red, 15f);
        RaycastHit objectHit;
        if (Physics.Raycast(new Ray(start, target), out objectHit)){
            Mesh mesh = mc.sharedMesh;

            int index = mesh.triangles[objectHit.triangleIndex * 3];
            int ColorIndex = (int)(mesh.uv[index].x * 16);
            Debug.Log(ColorIndex);
            //
            Renderer renderer = objectHit.collider.GetComponent<MeshRenderer>();
            Texture2D texture2D = renderer.material.mainTexture as Texture2D;
            Vector2 pCoord = objectHit.textureCoord;
            pCoord.x *= texture2D.width;
            pCoord.y *= texture2D.height;

            Vector2 tiling = renderer.material.mainTextureScale;
            Color color = texture2D.GetPixel(Mathf.FloorToInt(pCoord.x * tiling.x), Mathf.FloorToInt(pCoord.y * tiling.y));
            Debug.Log(color);


        }
    }

    // Update is called once per frame
    
}
