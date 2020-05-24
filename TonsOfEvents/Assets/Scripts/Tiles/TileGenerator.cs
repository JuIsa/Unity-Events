using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class TileGenerator : MonoBehaviour
{
    public Texture2D sourceTexture;
    public GameObject blockPrefab;

    private int width;
    private int height;
    void Start()
    {
        Color[] colorsInitial = sourceTexture.GetPixels();
        width = sourceTexture.width;
        height = sourceTexture.height;

        List<List<Color>> colorsIn2D = make1DList2D(ref colorsInitial);

        List<List<Color>> colorsTo64 = make512List64(ref colorsIn2D);

        float x, z;
        float start = -32;

        x = start;
        foreach (List<Color> lc in colorsTo64) {
            
            z = start;
            foreach (Color c in lc) {
                Vector3 position = new Vector3(x, 0, z);
                GameObject go = Instantiate(blockPrefab, position, Quaternion.identity);
                go.GetComponent<MeshRenderer>().material.color = c;
                
                z += 1;
            }
            x += 1;
        }


        Debug.Log("new size "+colorsTo64.Count+"x"+colorsTo64[1].Count);
    }

    public List<List<Color>> make1DList2D(ref Color[] colorsInitial) {
        List<List<Color>> newColors = new List<List<Color>>();
        for (int i = 0; i < 512; i ++) {
            List<Color> colors = new List<Color>();
            for(int j = 0; j < 512; j++) {
                colors.Add(new Color(colorsInitial[i * 512 + j].r,
                                     colorsInitial[i * 512 + j].g,
                                     colorsInitial[i * 512 + j].b));
            }
            newColors.Add(colors);
           
        }
        return newColors;
    }

    public List<List<Color>> make512List64(ref List<List<Color>> colorsIn2D) {
        List<List<Color>> colors64 = new List<List<Color>>();

        for(int y = 0; y < 64; y++) {
            List<Color> first = new List<Color>();
            for(int x = 0; x < 64; x++) {
                float sr = 0;
                float sg = 0;
                float sb = 0;
                for (int block_y = 0; block_y < 8; block_y++) {
                    for(int block_x = 0; block_x < 8; block_x++) {
                        sr += colorsIn2D[y * 8 + block_y][x * 8 + block_x].r;
                        sg += colorsIn2D[y * 8 + block_y][x * 8 + block_x].g;
                        sb += colorsIn2D[y * 8 + block_y][x * 8 + block_x].b;
                    }
                }
                first.Add(new Color(sr / 64, sg / 64, sb / 64));

            }
            colors64.Add(first);

        }

        return colors64;
    }


}
