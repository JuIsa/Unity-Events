using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    public delegate void ActionClick();
    public static event ActionClick onClick;
    public delegate void Test();
    public static event Test test;
    // Start is called before the first frame update
    public void ButtonClick() {
        if (onClick != null) {
            onClick();
        }
        if (test != null) {
            test();
        }
    }

    // Update is called once per frame

}
