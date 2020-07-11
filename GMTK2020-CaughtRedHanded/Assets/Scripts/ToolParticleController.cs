using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolParticleController : MonoBehaviour
{
    private ParticleSystem particles;
    private Vector3 mousePosition;
    private float moveSpeed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        particles = GetComponent<ParticleSystem>();
        particles.Stop(true, ParticleSystemStopBehavior.StopEmitting);
    }

    private void Update()
    {
        mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        transform.position = Vector2.Lerp(transform.position, mousePosition, moveSpeed);
    }

    public void BeginEmitting()
    {
        particles.Play(true);
    }

    public void StopEmitting()
    {
        particles.Stop(true, ParticleSystemStopBehavior.StopEmitting);
    }

    public void StopEmittingAndClear()
    {
        particles.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
    }
}
