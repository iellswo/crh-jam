using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessageCommanding : MonoBehaviour
{
    public GameObject messageBoxPrefab;
    public Canvas canvas;
    private GameObject messageBoxInstance;
    private bool messageIsVisible;

    // Start is called before the first frame update
    void Start()
    {
        messageIsVisible = false;
    }

    /// <summary>
    /// Summons the message box when M is pressed
    /// </summary>
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M) && (!messageIsVisible))
        {
            ShowRandomMessage();
        }
    }

    /// <summary>
    /// Displays a specific tutorial message
    /// </summary>
    /// <param name="code">index number of the tutorial message</param>
    private void ShowTutorialMessage(int code)
    {
        ShowMessage(GlobalTexts.GetTutorialMessagge(code), "Alright...");
    }

    /// <summary>
    /// Displays a random messagge
    /// </summary>
    private void ShowRandomMessage()
    {
        ShowMessage(GlobalTexts.GetRandomMessage(), "Go away!");
    }

    /// <summary>
    /// Displays a given message with given button text
    /// </summary>
    /// <param name="message">Text in the text box</param>
    /// <param name="buttonText">Text in the dismiss button</param>
    private void ShowMessage(string message, string buttonText)
    {
        messageBoxInstance = Instantiate(messageBoxPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        messageBoxInstance.transform.parent = canvas.transform;
        messageBoxInstance.transform.localPosition = new Vector3(0, 0, 0);

        MessageBox messageBoxData = messageBoxInstance.GetComponent<MessageBox>();
        messageBoxData.messageCommander = this;
        messageBoxData.message.text = message;
        messageBoxData.buttonText.text = buttonText;

        messageIsVisible = true;
    }

    /// <summary>
    /// Destroys the message window
    /// </summary>
    public void DismissMessage()
    {
        Destroy(messageBoxInstance);
        messageBoxInstance = null;
        messageIsVisible = false;
    }
}
