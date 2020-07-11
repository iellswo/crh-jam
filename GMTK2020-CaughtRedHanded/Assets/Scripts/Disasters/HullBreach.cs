using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HullBreach : Problem
{
    private bool fading = false;
    public Sprite taped;
    private float fade = 1;
    // Start is called before the first frame update
    void Start(){
    }

    // Update is called once per frame
    void Update(){
        if (fading){
            var rend = GetComponent<SpriteRenderer>();
            var color = rend.color;
            color.a -= Time.deltaTime * fade;
            if (color.a <= 0){
                DespawnMe();
            }
            rend.color = color;
        }
    }

    private void DespawnMe(){
        GlobalData.hullBreaches--;
        Destroy(gameObject);
    }

    public override void Repair(){
        var rend = GetComponent<SpriteRenderer>();
        rend.sprite = taped;
        fading = true;
    }
}