using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenWire : Problem
{
    public WireCutter wireCutter;
    // Start is called before the first frame update
    void Start(){
        GlobalData.cutWires++;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void Repair(){
        //AudioSource.PlayClipAtPoint(RepairSound, transform.position);
        GlobalData.cutWires--;
        wireCutter.showWire();
        Destroy(gameObject);
    }
}
