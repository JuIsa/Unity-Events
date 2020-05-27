using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aizawa : MonoBehaviour
{

    public float time; 

    private ParticleSystem ps;
    
    private ParticleSystem.Particle[] _particles;
    private int alive;

    private double a = 10;
    private double b = 28;
    private double c = 8/3;
    private double d = 2f;
    private double e = 0.25f;
    private double f = 0.1f;

    double x ;
    double y;
    double z;

    double dx;
    double dy;
    double dz;
    void Start()
    {
        ps = GetComponent<ParticleSystem>();
        
        
    }

    
    void Update()
    {
        _particles = new ParticleSystem.Particle[ps.main.maxParticles];
        alive = ps.GetParticles(_particles);
        
        for(int i = 0; i < alive; i++) {
            x = _particles[i].position.x;
            y =  _particles[i].position.y;
            z =  _particles[i].position.z;
            /* Aizawa
            dx = ((z - b) * x - d * y)*time;
            dy = (d * x + (z - b) * y)*time;
            dz = (c + (a * z) -(( z * z * z) / 3) - (x * x) + f * z * (x * x * x))*time;    
            
            */

            //Lorenz
            dx = x + a * (y - x) * time;
            dy = y + (x * (b - z) - y ) * time;
            dz = z + (x * y - c * z) * time;
            if (i == 1) {
                Debug.Log(dx+" "+dy + " "+dz);
            }
            float xx = Convert.ToSingle(dx);
            float yy = Convert.ToSingle(dy);
            float zz = Convert.ToSingle(dz);
            _particles[i].position = new Vector3(xx, yy, zz);
            //_particles[i].position = Vector3.Lerp(_particles[i].position, new Vector3(xx, yy, zz), time);
        }

        ps.SetParticles(_particles,alive);


    }
}
