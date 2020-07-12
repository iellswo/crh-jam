using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GooseGun : MonoBehaviour
{
    public float minInterval;
    public float maxInterval;
    public Goose goose;

    private float interval;
    // Start is called before the first frame update
    void Start(){
        interval = Random.Range(minInterval, maxInterval);
    }

    // Update is called once per frame
    void Update()
    {
        if (interval <= 0){
            Instantiate(goose, transform.position, Quaternion.identity);
            interval = Random.Range(minInterval, maxInterval);
        }

        interval -= Time.deltaTime;
    }
}
