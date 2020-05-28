using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Aizawa : MonoBehaviour
{

    public double time;

    public enum AttractorOf { Aizawa, Lorenz, Rossler};

    public AttractorOf chooseAttractor;

    private ParticleSystem ps;
    
    private ParticleSystem.Particle[] _particles;
    private int alive;

    private double a = 0.95;
    private double b = 0.7;
    private double c = 0.6;
    private double d = 2;
    private double e = 0.25;
    private double f = 0.1;

    double x ;
    double y;
    double z;

    double dx;
    double dy;
    double dz;

    float xx;
    float yy;
    float zz;

    void Start()
    {
        //set x = 0.1 , y,z = 0
        ps = GetComponent<ParticleSystem>();
        if(chooseAttractor == AttractorOf.Lorenz) {
            a = 10;
            b = 28;
            c = 8/3;
        }
        else if(chooseAttractor == AttractorOf.Aizawa) {
            a = 0.95;
            b = 0.8;
            c = 0.6;
            d = 3.7;
            e = 0.25;
            f = 0.1;
            time = 0.01f;
        }
        else if(chooseAttractor == AttractorOf.Rossler) {
            a = 0.2;
            b = 0.2;
            c = 5.7;
        }
    }

    
    void Update()
    {
        _particles = new ParticleSystem.Particle[ps.main.maxParticles];
        alive = ps.GetParticles(_particles);

        if (chooseAttractor == AttractorOf.Aizawa) {
            for (int i = 0; i < alive; i++) {
                x = _particles[i].position.x;
                y = _particles[i].position.y;
                z = _particles[i].position.z;

                dx = (((z - b) * x) - (d * y)) * time;
                dy = ((d * x) + ((z - b) * y)) * time;
        //        dz = (c + (a * z) - (Math.Pow(z,3) / 3) - (Math.Pow(x,2)) + (Math.Pow(y, 2)) *(1 + e * z)+ f * z * (Math.Pow(x, 3))) * time;
                dz = c + a * z - (Math.Pow(z, 3) / 3) - (Math.Pow(x, 2) + Math.Pow(y, 2)) * (1 + e * z) + f * z * (Math.Pow(x, 3));
                dz *= time;
                
                xx = Convert.ToSingle(dx);
                yy = Convert.ToSingle(dy);
                zz = Convert.ToSingle(dz);
                _particles[i].position += new Vector3(xx, yy, zz);
            }
        } 
        else if (chooseAttractor == AttractorOf.Lorenz) {
            for (int i = 0; i < alive; i++) {
                x = _particles[i].position.x;
                y = _particles[i].position.y;
                z = _particles[i].position.z;
               
                dx = x + a * (y - x) * time;
                dy = y + (x * (b - z) - y) * time;
                dz = z + (x * y - c * z) * time;
                
                xx = Convert.ToSingle(dx);
                yy = Convert.ToSingle(dy);
                zz = Convert.ToSingle(dz);
                _particles[i].position = new Vector3(xx, yy, zz);
            }
        }
        else if(chooseAttractor == AttractorOf.Rossler) {
            for(int i = 0; i < alive; i++) {
                x = _particles[i].position.x;
                y = _particles[i].position.y;
                z = _particles[i].position.z;

                dx = (-y - z)*time;
                dy = (x + a * y)*time;
                dz = (b + z * (x - c))*time;
                Debug.Log(dx + "----" + dy + "----" + dz);
                float xx = Convert.ToSingle(dx);
                float yy = Convert.ToSingle(dy);
                float zz = Convert.ToSingle(dz);
                _particles[i].position += new Vector3(xx, yy, zz);
            }
        }
        ps.SetParticles(_particles,alive);


    }
}
