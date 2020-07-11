using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolTray : MonoBehaviour
{
    public GenericTool heldTool;
    public bool isHoldingTool;

    private Animation anim;
    private bool isUp;

    private float[] snapLocks = new float[7];

    // Start is called before the first frame update
    void Start()
    {
        isHoldingTool = false;
        isUp = true;
        SetSnapLocks();
        anim = GetComponent<Animation>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isUp)
            {
                anim.Play("Toobar-Hide");
                isUp = false;
            }
            else
            {
                anim.Play("Toolbar-Unhide");
                isUp = true;
            }
        }
    }

    /// <summary>
    /// Sets currently held tool
    /// </summary>
    /// <param name="tool">GenericTool object that the player is holding; should be "this"</param>
    public void SetHeldTool(GenericTool tool)
    {
        isHoldingTool = true;
        heldTool = tool;
        GlobalData.activeTool = tool.toolName;
    }

    /// <summary>
    /// Makes the toolTray forget which tool was being held when the player releases it
    /// </summary>
    public void UnsetHeldTool()
    {
        isHoldingTool = false;
        heldTool = null;
        GlobalData.activeTool = "";
    }

    /// <summary>
    /// When the player's tool is hovering over the tool tray, left click will put the tool down
    /// </summary>
    public void SetPutDownState()
    {
        Debug.Log("Entered Tray");
        if (isHoldingTool)
        {
            heldTool.CommandSwitch(3);
        }
    }

    /// <summary>
    /// When the player's cursor leaves the tool tray, left click will no longer put the tool down
    /// </summary>
    public void UnsetPutdownState()
    {
        Debug.Log("Exited Tray");
        if (isHoldingTool)
            heldTool.CommandSwitch(2);
    }

    /// <summary>
    /// Returns the X value that the GenericTool can snap to
    /// </summary>
    /// <param name="i">the number of tool "slot", counting from the left</param>
    public float GetSnapLock(int i)
    {
        return snapLocks[i];
    }

    /// <summary>
    /// Sets locations for tool positions in accordance with screen size
    /// </summary>
    private void SetSnapLocks()
    {
        float snapLockStep = Screen.width / 8;
        snapLocks[0] = snapLockStep * -3;
        snapLocks[1] = snapLockStep * -2;
        snapLocks[2] = snapLockStep * -1;
        snapLocks[3] = 0;
        snapLocks[4] = snapLockStep;
        snapLocks[5] = snapLockStep * 2;
        snapLocks[6] = snapLockStep * 3;
        
        GenericTool[] toolsToLock = GetComponentsInChildren<GenericTool>();
        foreach (GenericTool a in toolsToLock)
        {
            a.SetReturnPosition(snapLocks[a.slot]);
        }
    }
}
