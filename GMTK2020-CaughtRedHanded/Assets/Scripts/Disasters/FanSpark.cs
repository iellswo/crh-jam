using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanSpark : Problem
{
    public FanScript fan;

    public FanBreaker handler;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, 0.5f);
    }

    public override void Repair(){
        //AudioSource.PlayClipAtPoint(RepairSound, transform.position);
        fan.Spin();
        handler._break = null;
        Destroy(gameObject);
    }
}
