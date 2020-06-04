using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorDetect : MonoBehaviour
{
    
    private float rayDuration = 20;

    private float cell1 = .75f;
    private float cell2 = .0f;
    private float cell3 = -.75f;

    public float y = 0.0f;

    private float distanceFromObject = 2;

    void Start()
    {
        MeshCollider mc = GetComponent<MeshCollider>();

        /*
        Vector3 xtarget = new Vector3(-2.0f,.0f,.0f);
        Vector3 _xtarget = new Vector3(2.0f, .0f, .0f);
        Vector3 ztarget = new Vector3(0.0f, .0f, -2f);
        Vector3 _ztarget = new Vector3(0.0f, .0f, 2f);

        Vector3 xside1 = new Vector3(distanceFromObject, y, cell1);
        Vector3 xside2 = new Vector3(distanceFromObject, y, cell2);
        Vector3 xside3 = new Vector3(distanceFromObject, y, cell3);

        Vector3 _xside1 = new Vector3(-distanceFromObject, y, cell1);
        Vector3 _xside2 = new Vector3(-distanceFromObject, y, cell2);
        Vector3 _xside3 = new Vector3(-distanceFromObject, y, cell3);

        Vector3 zside1 = new Vector3(cell1, y, distanceFromObject);
        Vector3 zside2 = new Vector3(cell2, y, distanceFromObject);
        Vector3 zside3 = new Vector3(cell3, y, distanceFromObject);

        Vector3 _zside1 = new Vector3(cell1, y, -distanceFromObject);
        Vector3 _zside2 = new Vector3(cell2, y, -distanceFromObject);
        Vector3 _zside3 = new Vector3(cell3, y, -distanceFromObject);
        */
        List<List<Vector3>> sides = new List<List<Vector3>>() { new List<Vector3>()
            { 
                new Vector3(distanceFromObject, y, cell1), 
                new Vector3(distanceFromObject, y, cell2), 
                new Vector3(distanceFromObject, y, cell3) 
            },
            new List<Vector3>() {
                new Vector3(-distanceFromObject, y, cell1),
                new Vector3(-distanceFromObject, y, cell2),
                new Vector3(-distanceFromObject, y, cell3)
            },
            new List<Vector3>() {
                new Vector3(cell1, y, distanceFromObject),
                new Vector3(cell2, y, distanceFromObject),
                new Vector3(cell3, y, distanceFromObject)
            },
            new List<Vector3>() {
                new Vector3(cell1, y, -distanceFromObject),
                new Vector3(cell2, y, -distanceFromObject),
                new Vector3(cell3, y, -distanceFromObject)
            },
        };

        List<Vector3> targets = new List<Vector3>() {
            new Vector3(-2.0f,.0f,.0f),
            new Vector3(2.0f, .0f, .0f),
            new Vector3(0.0f, .0f, -2f),
            new Vector3(0.0f, .0f, 2f)
        };


        RaycastHit objectHit;
        Renderer renderer;
        Texture2D texture2D;
        if (Physics.Raycast(new Ray(sides[0][0], targets[0]), out objectHit)) {
            //
            renderer = objectHit.collider.GetComponent<MeshRenderer>();
            texture2D = renderer.material.mainTexture as Texture2D;
            for (int i = 0; i < sides.Count; i++) {
                for (int j = 0; j < sides[0].Count; j++) {
                    if (Physics.Raycast(new Ray(sides[i][j], targets[i]), out objectHit)) {
                        Debug.DrawRay(sides[i][j], targets[i], Color.black, rayDuration);
                        Vector2 pCoord = objectHit.textureCoord;
                        pCoord.x *= texture2D.width;
                        pCoord.y *= texture2D.height;

                        Vector2 tiling = renderer.material.mainTextureScale;
                        Color color = texture2D.GetPixel(Mathf.FloorToInt(pCoord.x * tiling.x), Mathf.FloorToInt(pCoord.y * tiling.y));
                        Debug.Log(color);
                    }
                }

            }

        }
        

        


        /*
        Debug.DrawRay(xside1, xtarget, Color.black, rayDuration);
        Debug.DrawRay(xside2, xtarget, Color.black, rayDuration);
        Debug.DrawRay(xside3, xtarget, Color.black, rayDuration);

        Debug.DrawRay(_xside1, _xtarget, Color.blue, rayDuration);
        Debug.DrawRay(_xside2, _xtarget, Color.blue, rayDuration);
        Debug.DrawRay(_xside3, _xtarget, Color.blue, rayDuration);

        Debug.DrawRay(zside1, ztarget, Color.green, rayDuration);
        Debug.DrawRay(zside2, ztarget, Color.green, rayDuration);
        Debug.DrawRay(zside3, ztarget, Color.green, rayDuration);

        Debug.DrawRay(_zside1, _ztarget, Color.yellow, rayDuration);
        Debug.DrawRay(_zside2, _ztarget, Color.yellow, rayDuration);
        Debug.DrawRay(_zside3, _ztarget, Color.yellow, rayDuration);
        */
        
        /*
        if (Physics.Raycast(new Ray(xside1, xtarget), out objectHit)){
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
        */
    }

    
    
}
