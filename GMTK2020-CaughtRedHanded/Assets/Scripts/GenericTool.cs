using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GenericTool : MonoBehaviour
{
    public float mouseOffset = -30f; //Offset from cursor
    public string toolName; //Name of the tool
    public ToolTray toolTray; //Tool bar
    public int slot; //Tool slot occupied by this tool

    //Audio clips
    public AudioClip pickUpSound;
    public AudioClip putDownSound;
    public AudioClip useSound;

    private AudioSource audioPlayer;
    private Image image;
    //private ParticleSystem particleSys;

    private bool isPickedUp; //Whether the object is currently held by the player
    private int currentClickState; //What the LMB will do to the object when clicked; see CommandSwitch method for explanation
    private Vector3 returnPosition; //What the tool will return to after being put down

    // Start is called before the first frame update
    void Start()
    {
        audioPlayer = GetComponent<AudioSource>();
        image = GetComponent<Image>();
        //particleSys = GetComponent<ParticleSystem>();
        //particleSys.Stop();
        isPickedUp = false;
        currentClickState = 1;
    }

    private void Update()
    {
        if (isPickedUp)
        {
            //Following
            Vector3 offset = new Vector3(mouseOffset, 0);
            Vector3 mousePos = Input.mousePosition;
            transform.position = mousePos + offset;

            if (Input.GetMouseButtonDown(0))
            {
                OnClickReaction();
            }
        }
    }

    /// <summary>
    /// Reaction to being clicked, based on 
    /// </summary>
    public void OnClickReaction()
    {
        switch (currentClickState)
        {
            case 1: PickUpTool(); break;
            case 2: StartUsingTool(); break;
            case 3: PutDownTool(); break;
            default: Debug.Log("Incorrect clickState"); break;
        }
    }

    /// <summary>
    /// "Picks up" the tool, playing the audio and freeing it to follow the cursor; hides the cursor
    /// </summary>
    public void PickUpTool()
    {
        if ((isPickedUp == false) && (toolTray.isHoldingTool == false))
        {
            audioPlayer.PlayOneShot(pickUpSound);
            isPickedUp = true;
            CommandSwitch(3);
            toolTray.SetHeldTool(this);
            Cursor.visible = false;
            image.raycastTarget = false;
        }
    }

    /// <summary>
    /// "Puts down" tool, playing audio and disengaging it from the cursor; makes the cursor visible again
    /// </summary>
    public void PutDownTool()
    {
        audioPlayer.PlayOneShot(putDownSound);
        isPickedUp = false;
        CommandSwitch(1);
        toolTray.UnsetHeldTool();
        SnapToPosition();
        Cursor.visible = true;
        image.raycastTarget = true;
    }

    /// <summary>
    /// Starts playing the audio and particle effects associated with using the tool
    /// </summary>
    public void StartUsingTool()
    {
        audioPlayer.PlayOneShot(useSound);
        //particleSys.Play();
    }

    /// <summary>
    /// Stops playing the audio and particle effects associated with using the tool
    /// </summary>
    public void StopUsingTool()
    {
        audioPlayer.Stop();
        //particleSys.Stop();
    }

    /// <summary>
    /// Passes the tool's name (for interactions with problems)
    /// </summary>
    /// <returns></returns>
    public string GetToolName()
    {
        return toolName;
    }

    /// <summary>
    /// For interactions with ToolTray and clicking; pressing LMB at different points does different things
    /// </summary>
    /// <param name="command">1 for "to be picked up", 2 for "to be used", 3 for "to be put down"</param>
    /// <returns></returns>
    public void CommandSwitch(int command)
    {
        currentClickState = command;
        Debug.Log(toolName + " set to state: " + command);
    }

    /// <summary>
    /// Snaps the item back to its position on the tool bar
    /// </summary>
    public void SnapToPosition()
    {
        GetComponent<RectTransform>().localPosition = returnPosition;
    }

    /// <summary>
    /// Sets the return position (scales with screen size)
    /// </summary>
    /// <param name="xfactor">Position of object on the X axis</param>
    public void SetReturnPosition(float xfactor)
    {
        returnPosition = new Vector3(xfactor, 0);
        SnapToPosition();
    }
}
