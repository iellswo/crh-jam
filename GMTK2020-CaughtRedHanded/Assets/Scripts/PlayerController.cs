using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Vector2 m_Move;

    private Vector2 m_Look;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    
    //example functions from the input system controls.
    //the PlayerInputs object handles the mapping of the keys and calls these functions with the proper inputs
    public void OnMove(InputValue value)
    {
        m_Move = value.Get<Vector2>();
        //probably set vector
    }
 
    public void OnLook(InputValue value)
    {
        m_Look = value.Get<Vector2>();
        //probably adjust relative camera location and or viewcone of player if it exists
    }
 
    public void OnFire()
    {
        //do something
    }
}
