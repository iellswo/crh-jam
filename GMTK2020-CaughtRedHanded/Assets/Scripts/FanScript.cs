using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanScript : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;

    public float fanSpeed;
    // Start is called before the first frame update
    void Start(){
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _rigidbody2D.angularVelocity = fanSpeed;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Stop(){
        _rigidbody2D.angularVelocity = 0;
    }

    public void Spin(){
        _rigidbody2D.angularVelocity = fanSpeed;
    }
}
