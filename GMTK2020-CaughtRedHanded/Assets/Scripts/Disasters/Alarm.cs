using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alarm : MonoBehaviour {
    // Start is called before the first frame update
    public float timer;
    public bool active;
    public float maxInterval = 500;
    public float minInterval = 100;
    public AudioSource AS;
    void Start()
    {
        // GlobalData.alarmCountDown  = Random.Range(minInterval,maxInterval);
        timer  = Random.Range(minInterval,maxInterval);
        AS = GetComponent<AudioSource>();
        active = false;  
    }

    // Update is called once per frame
    void Update()
    {
        if(timer < 0){
            GlobalData.alarmOn = true;
        }else{
            timer -= Time.deltaTime;
        }
       // if(Input.GetMouseButtonDown(0)) Debug.Log("Pressed left click.");
        // Debug.Log("Don't Push");

    }
    public void OnMouseDown() {
        AS.Play();
        if(GlobalData.alarmOn){
            timer = Random.Range(minInterval,maxInterval);
            GlobalData.alarmOn = false;
        }else{
            Debug.Log("Don't Push");
        }
    }
}
