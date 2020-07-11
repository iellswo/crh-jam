using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alarm : MonoBehaviour {
    // Start is called before the first frame update
    public float timer;
    public bool active;
    public float maxInterval = 500;
    public float minInterval = 100;
    private int lightFlip = 0;
    public AlarmLight Alarmlight;
    void Start()
    {
        // GlobalData.alarmCountDown  = Random.Range(minInterval,maxInterval);
        timer  = Random.Range(minInterval,maxInterval);
        active = false;  
    }

    // Update is called once per frame
    void Update()
    {
        if(timer < 0){
            active = true;
        }else{
            timer--;
        }

        if(active){
            lightFlip++;
            if(lightFlip % 30 ==0){
                Alarmlight.flipColor();
                Alarmlight.playAlarm();
            }
        }
       // if(Input.GetMouseButtonDown(0)) Debug.Log("Pressed left click.");
        // Debug.Log("Don't Push");

    }
    public void Clicked() {
        if(active){
            timer = Random.Range(minInterval,maxInterval);
            active = false;
            Alarmlight.resetColor();
        }else{
            Debug.Log("Don't Push");
        }
    }
}
