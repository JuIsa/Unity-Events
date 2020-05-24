using Packages.Rider.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfAware : MonoBehaviour
{
    private float x;
    private float z;
    private Vector3 plus = new Vector3(.0f, .5f, .0f);
    private Vector3 minus = new Vector3(.0f, -.5f, .0f);
    void Start()
    {
        
    }

    public void setPos(float posX, float posZ) {
        x = posX;
        z = posZ;
        StartCoroutine(Dance());
    }

    IEnumerator Dance() {
        Vector3 zz = plus;
        while (true) {
            if (this.transform.position.y > 2) {
                zz = minus;
            } else if (this.transform.position.y < -1) {
                zz = plus;
            }
            this.transform.position += zz;
            yield return new WaitForSeconds(0.1f);
        }
    }
    
    
}
