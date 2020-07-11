using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptyFuze : Problem
{
    public FuzeBreaker fuzeBreaker;

    // Start is called before the first frame update
    void Start(){
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void Repair(){
        //AudioSource.PlayClipAtPoint(RepairSound, transform.position);
        fuzeBreaker._break = null;
        GlobalData.blownFuzes--;
        Destroy(gameObject);
    }

}
