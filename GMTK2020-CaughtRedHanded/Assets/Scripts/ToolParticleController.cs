using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolParticleController : MonoBehaviour
{
    private ParticleSystem particleSystem;

    // Start is called before the first frame update
    void Start()
    {
        particleSystem = GetComponent<ParticleSystem>();
        particleSystem.Stop(true, ParticleSystemStopBehavior.StopEmitting);
    }
    
    public void BeginEmitting()
    {
        particleSystem.Play(true);
    }

    public void StopEmitting()
    {
        particleSystem.Stop(true, ParticleSystemStopBehavior.StopEmitting);
    }

    public void StopEmittingAndClear()
    {
        particleSystem.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
    }
}
