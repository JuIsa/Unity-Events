using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject cube;
    public int grid;
    public float speed;


    private Rigidbody rb;
    
    void Start()
    {
        
        rb = GetComponent<Rigidbody>();
        float z = -grid/2;
        for (int i = 0; i < grid; i++) {
            float x = -grid/2;
            for (int j = 0; j < grid; j++) {
                Instantiate(cube, new Vector3(x, -2, z), Quaternion.identity);
                x++;
            }
            z++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W)) {
            rb.AddForce(Vector3.forward * speed);
        } else if (Input.GetKey(KeyCode.S)) {
            rb.AddForce(Vector3.back * speed);
        } else if (Input.GetKey(KeyCode.A)) {
            rb.AddForce(Vector3.left * speed);
        } else if (Input.GetKey(KeyCode.D)) {
            rb.AddForce(Vector3.right * speed);
        }
    }
}
