using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : Problem
{
    // Start is called before the first frame update
    void Start(){
        GlobalData.fireCount++;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(this.transform.position, 0.5f);
    }

    public void OnMouseEnter()
    {
        if (Input.GetMouseButton(0))
        {
            Debug.Log("repairing with " + GlobalData.activeTool);
            if (SolutionCode == GlobalData.activeTool)
            {
                Repair();
            }
        }
    }

    public override void Repair(){
        //AudioSource.PlayClipAtPoint(RepairSound, transform.position);
        GlobalData.fireCount--;
        Destroy(gameObject);
    }
}
