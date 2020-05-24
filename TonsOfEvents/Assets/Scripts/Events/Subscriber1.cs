using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Subscriber1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //subscribe
        GameObject go = GameObject.Find("Event1");//gameobject with attached script
        Event1 event1 = go.GetComponent<Event1>();
        Event1.onSpacePressedSecond += localFunctionSecond;
        event1.onSpacePressed += localFunction;

        //event1.onSpacePressedSecond += localFunctionSecond;
    }


    public void localFunction(object sender, EventArgs e) {
        Debug.Log("Received Event");

        /* unsubscribe 
        Event1 event1 = GetComponent<Event1>();
        event1.onSpacePressed -= localFunction;
        */
    }

    public void localFunctionSecond(object sender, Event1.OneType num) {
        Debug.Log("Second int: " + num.EventInt+" "+this.name);
    }
    
}
