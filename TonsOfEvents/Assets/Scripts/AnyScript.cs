using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnyScript : MonoBehaviour
{
    // Start is called before the first frame update
    private bool changed = false;
    void Start()
    {

        //subscribe methods ChangeColor for event onClick
        Main.test += ChangeColor;
    }

    //Method called each time events detected
    public void ChangeColor() {
        if (changed) {
            GetComponent<MeshRenderer>().material.color = Color.white;
            changed = false;
        } else {
            GetComponent<MeshRenderer>().material.color = Color.red;
            changed = true;
        }
    }
    // Update is called once per frame
    
}
