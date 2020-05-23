using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Event2 : MonoBehaviour
{
    public event onSPresed onSPressed;
    public delegate void onSPresed(string word);
    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S)) {
            //delegate event call
            onSPressed?.Invoke(this.name);
        }
    }
}
