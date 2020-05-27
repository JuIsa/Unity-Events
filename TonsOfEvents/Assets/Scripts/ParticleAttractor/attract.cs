using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(ParticleSystem))]
public class attract : MonoBehaviour
{
    private ParticleSystem ps;
    private ParticleSystem.Particle[] _particles;

    
    public Transform attractor;
    
    public float speed;
    private int alive;
    private float step;

    void Start()
    {
        ps = GetComponent<ParticleSystem>();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
        _particles = new ParticleSystem.Particle[ps.main.maxParticles];
        alive = ps.GetParticles(_particles);
        step = speed * Time.deltaTime;
        for(int i = 0; i < alive; i++) {
            _particles[i].position = Vector3.Slerp(_particles[i].position, attractor.position, step);
            //Slerp, Lerp
        }
        ps.SetParticles(_particles, alive);
    }
}
