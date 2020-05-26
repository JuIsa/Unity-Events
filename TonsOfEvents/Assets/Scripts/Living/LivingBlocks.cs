using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivingBlocks : MonoBehaviour
{
    public GameObject player;
    public Material _upMaterial;
    public Material _halfMaterail;
    public float livingSpeed ;
    private Material _defaultMaterial;
    private MeshRenderer renderer;
    private float x;
    private float z;
    private Vector3 target;
    private Vector3 half;
    private Vector3 basic;
    void Start()
    {
        player = GameObject.Find("Sphere");
        x = this.transform.position.x;
        z = this.transform.position.z;

        target = new Vector3(transform.position.x, 1.1f, transform.position.z);
        half = new Vector3(transform.position.x, -.1f, transform.position.z);
        basic = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        renderer = this.GetComponent<MeshRenderer>();
        _defaultMaterial = renderer.material;
    }

    // Update is called once per frame
    void Update()
    {
        float x1 = player.transform.position.x;
        float z1 = player.transform.position.z;

        float distanceX = Math.Abs(x - x1);
        float distanceZ = Math.Abs(z - z1);
        if (distanceX < 2 && distanceZ < 2) {
            this.transform.position = Vector3.MoveTowards(transform.position, target, livingSpeed);
            renderer.material = _upMaterial;
        }
        else if (distanceX < 3 && distanceZ < 3) {
            this.transform.position = Vector3.MoveTowards(transform.position, half, livingSpeed);
            renderer.material = _halfMaterail;
        }
        else {
            this.transform.position = Vector3.MoveTowards(transform.position, basic, livingSpeed);
            renderer.material = _defaultMaterial;
        }

    }
}
