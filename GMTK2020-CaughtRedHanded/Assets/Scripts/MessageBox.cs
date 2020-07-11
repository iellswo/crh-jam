using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessageBox : MonoBehaviour
{
    public Text message;
    public Text buttonText;
    public MessageCommanding messageCommander;

    /// <summary>
    /// Dismisses the message box
    /// </summary>
    public void DismissMessage()
    {
        messageCommander.DismissMessage();
    }


}
