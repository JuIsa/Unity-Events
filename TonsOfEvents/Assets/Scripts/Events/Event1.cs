using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Event1 : MonoBehaviour
{
    public event EventHandler onSpacePressed;


    public static event EventHandler<OneType> onSpacePressedSecond;
    public class OneType : EventArgs {
        public int EventInt;
    }
    public int i = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            onSpacePressed?.Invoke(this, EventArgs.Empty);
            // code above is the same as below
            //if (onSpacePressed != null) onSpacePressed(this, EventArgs.Empty);

            onSpacePressedSecond?.Invoke(this, new OneType { EventInt = i });
        }
    }
}
