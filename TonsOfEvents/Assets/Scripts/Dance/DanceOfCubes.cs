using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DanceOfCubes : MonoBehaviour
{
    public GameObject pref;
    public Material _mat;

    private static List<List<GameObject>> cubes = new List<List<GameObject>>();
    
    void Start()
    {
        
        float x = -10;
        
        for(int i = 0; i < 20; i++) {
            float z = -10;
            List<GameObject> list1 = new List<GameObject>();
            for (int j = 0; j < 20; j++) {
                GameObject go = Instantiate(pref, new Vector3(x, 0, z), Quaternion.identity);
                go.GetComponent<MeshRenderer>().material = _mat;
                
                list1.Add(go);
                
                z+=1.0f;
            }
            cubes.Add(list1);
            x+=1.0f;
        }

        StartCoroutine(shiftEverything());
    }

    IEnumerator shiftEverything() {
        //Vector3 x = plus;
        while (true) {
            
            for(int i = 0; i < 20; i++) {
                for(int j = 0; j < 20; j++) {
                    SelfAware sa = cubes[i][j].GetComponent<SelfAware>();
                    sa.setPos(1, 1);
                    Debug.Log(i+" and "+j);
                    yield return new WaitForSeconds(0.05f);
                }
                
            }
            yield break;
        }
        
    }




   
   
}
