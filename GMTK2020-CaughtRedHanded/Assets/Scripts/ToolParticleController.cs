using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolParticleController : MonoBehaviour
{
    private ParticleSystem particles;
    private Vector3 mousePosition;
    private float moveSpeed = 10f;

    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        particles = GetComponent<ParticleSystem>();
        particles.Stop(true, ParticleSystemStopBehavior.StopEmitting);

        audioSource = GetComponent<AudioSource>();
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

        audioSource.Play();
    }

    public void StopEmitting()
    {
        particles.Stop(true, ParticleSystemStopBehavior.StopEmitting);

        audioSource.Stop();
    }

    public void StopEmittingAndClear()
    {
        particles.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);

        audioSource.Stop();
    }
}
