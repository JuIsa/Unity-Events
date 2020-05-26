using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateCubes : MonoBehaviour
{
    public GameObject cubes;
    void Start()
    {
        
        float z = -10;
        for(int i = 0; i < 20; i++) {
            float x = -10;
            for (int j = 0; j < 20; j++) {
                Instantiate(cubes, new Vector3(x, 0, z), Quaternion.identity);
                
                x++;
            }
            z++;
        }
    }

    private void Update() {
        if (Input.GetKey(KeyCode.A)) {
            this.transform.position += Vector3.left * Time.deltaTime*2;
        }else if (Input.GetKey(KeyCode.D)) {
            this.transform.position += Vector3.right * Time.deltaTime*2;
        } else if (Input.GetKey(KeyCode.W)) {
            this.transform.position += Vector3.forward * Time.deltaTime * 2;
        } else if (Input.GetKey(KeyCode.S)) {
            this.transform.position += Vector3.back * Time.deltaTime * 2;
        }
    }


}
