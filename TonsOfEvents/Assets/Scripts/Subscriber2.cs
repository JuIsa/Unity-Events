using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Subscriber2 : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        GameObject go = GameObject.Find("Event2");
        Event2 event2 = go.GetComponent<Event2>();
        event2.onSPressed += localPrint;
    }

    public void localPrint(string word) {
        Debug.Log("The word is "+word);
    }

    // Update is called once per frame
   
}
