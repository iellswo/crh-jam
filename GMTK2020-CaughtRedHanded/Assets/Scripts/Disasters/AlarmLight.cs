using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent (typeof (Image))]
public class AlarmLight : MonoBehaviour
{   
    public Color32 c1 = new Color32(255,0,0,255);
    public Color32 c2 = new Color32(255,255,0,255);
    bool flip = true;
    Image image;
    public AudioSource audioSource;


    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void flipColor(){
            if(flip){
                image.color = c1;
            }else{
                image.color = c2;
            }
            flip = !flip;
    }
    public void resetColor(){
        image.color = new Color32(255,255,255,255);
    }
    public void playAlarm(){
        audioSource.Play();
    }
}
