using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanScript : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;

    public float fanSpeed = 120;
    public float brokenSpeed = 60;

    private float forward = 0.3f;
    private float back = 0.1f;
    private float timeInState;
    private bool busted;

    private AudioSource _audioSource;
    public AudioSource breakAudioSource;


    // Start is called before the first frame update
    void Start(){
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _rigidbody2D.angularVelocity = fanSpeed;
        busted = false;

        _audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (busted)
        {
            timeInState += Time.deltaTime;
            if (timeInState >= back + forward)
            {
                timeInState = 0.0f;
                _rigidbody2D.angularVelocity = brokenSpeed * -3;
            }
            else if (timeInState >= back)
            {
                _rigidbody2D.angularVelocity = brokenSpeed;
            }
        }
    }

    public void Stop()
    {
        _rigidbody2D.angularVelocity = brokenSpeed * -3;
        timeInState = 0.0f;
        busted = true;
    }

    public void Spin()
    {
        _rigidbody2D.angularVelocity = fanSpeed;
        busted = false;

        breakAudioSource.Stop();
        _audioSource.Play();
    }
}
