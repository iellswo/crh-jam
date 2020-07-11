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

    private Queue<BackloggedMessage> messageBacklog;

    // Start is called before the first frame update
    void Start()
    {
        messageIsVisible = false;
        messageBacklog = new Queue<BackloggedMessage>();
        ShowTutorialMessage(0);
        ShowTutorialMessage(1);
    }

    /// <summary>
    /// Summons the message box when M is pressed
    /// </summary>
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
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
        string messageToShow = GlobalTexts.GetTutorialMessagge(code);
        if (!messageIsVisible)
            ShowMessage(messageToShow, "Alright...");
        else
            messageBacklog.Enqueue(new BackloggedMessage(messageToShow, true));
    }

    /// <summary>
    /// Displays a random messagge
    /// </summary>
    private void ShowRandomMessage()
    {
        string messageToShow = GlobalTexts.GetRandomMessage();
        if (!messageIsVisible)
            ShowMessage(messageToShow, "Go away!");
        else
            messageBacklog.Enqueue(new BackloggedMessage(messageToShow, false));
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

        if (messageBacklog.Count > 0)
        {
            BackloggedMessage nextInQueue = messageBacklog.Peek();
            if (nextInQueue.isTutorial)
                ShowMessage(nextInQueue.text, "Alright...");
            else
                ShowMessage(nextInQueue.text, "Go away!");
            messageBacklog.Dequeue();
        }

    }
}

class BackloggedMessage
{
    public string text;
    public bool isTutorial;

    public BackloggedMessage(string text, bool isTutorial)
    {
        this.text = text;
        this.isTutorial = isTutorial;
    }
}
