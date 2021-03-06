﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AlarmLight : MonoBehaviour
{   
    public Color32 c1 = new Color32(255,0,0,255);
    public Color32 c2 = new Color32(255,255,0,255);
    bool flip = true;
    float cTimer = 0;
    float alarmDelay=1.0f;
    SpriteRenderer sprite;
    public AudioSource audioSource;


    // Start is called before the first frame update
    void Start()
    {
       sprite = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        cTimer += Time.deltaTime;
        if(GlobalData.alarmOn){
            if(  cTimer > alarmDelay){
                if(cTimer > alarmDelay/2){
                    flipColor();
                }
                playAlarm();
                cTimer = 0.0f;
            }
        }else{
            resetColor();
            audioSource.Stop();
        }

    }

    public void flipColor(){
            if(flip){
                sprite.color = c1;
            }else{
                sprite.color = c2;
            }
            flip = !flip;
    }
    public void resetColor(){
        sprite.color = new Color32(255,255,255,255);
    }
    public void playAlarm(){
        audioSource.Play();
    }
}
