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

    //Message backlogging
    private Queue<BackloggedMessage> messageBacklog;

    //Tutorial stuff
    /// <summary>
    /// 0 - fire, 1 - hull breach, 2 - broken fuse, 3 - goose, 4 - vent, 5 - wire, 6 - alarm, 7 - coolant tower
    /// </summary>
    private bool[] awaitingFirstEvent = new bool[8];
    private bool canThrowRandoms;

    //Randomness
    public float minInterlude = 15;
    public float maxInterlude = 20;
    private float interlude;

    // Start is called before the first frame update
    void Start()
    {
        messageIsVisible = false;

        messageBacklog = new Queue<BackloggedMessage>();
        ShowTutorialMessage(0);
        ShowTutorialMessage(1);

        canThrowRandoms = false;
        for (int i = 0; i < 8; i++)
            awaitingFirstEvent[i] = true;

        interlude = Random.Range(minInterlude, maxInterlude);
    }

    /// <summary>
    /// Summons the message box when M is pressed
    /// </summary>
    void Update()
    {
        if (!canThrowRandoms)
        {
            //Checking if first fire has appeared
            if ((GlobalData.fireCount > 0) && (awaitingFirstEvent[0]))
            {
                ShowTutorialMessage(2);
                awaitingFirstEvent[0] = false;
            }

            //Checking if first hull breach has appeared
            if ((GlobalData.hullBreaches > 0) && (awaitingFirstEvent[1]))
            {
                ShowTutorialMessage(3);
                awaitingFirstEvent[1] = false;
            }

            //Checking if the fuse broke for the first time
            if ((GlobalData.blownFuzes > 0) && (awaitingFirstEvent[2]))
            {
                ShowTutorialMessage(5);
                awaitingFirstEvent[2] = false;
            }

            //Checking if the goose broke out for the first time
            if ((GlobalData.looseGoose) && (awaitingFirstEvent[3]))
            {
                ShowTutorialMessage(4);
                awaitingFirstEvent[3] = false;
            }

            //Checking if broken vent first appeared
            if ((GlobalData.brokenFans > 0) && (awaitingFirstEvent[4]))
            {
                ShowTutorialMessage(7);
                awaitingFirstEvent[4] = false;
            }

            //Checking if wire has been cut for the first time
            if ((GlobalData.cutWires > 0) && (awaitingFirstEvent[5]))
            {
                ShowTutorialMessage(6);
                awaitingFirstEvent[5] = false;
            }
            

            //ALARM CODE HERE
            awaitingFirstEvent[6] = false;
            /*
             * if ((GlobalData.alarms > 0) && (awaitingFirstEvent[6]))
             * {
             *      ShowTutorialMessage(8);
             *      awaitingFirstEvent[6] = false;
             * }
            */

            //Checking if the coolant tower broke for the first time
            if ((GlobalData.activeLeak) && (awaitingFirstEvent[7]))
            {
                ShowTutorialMessage(9);
                awaitingFirstEvent[7] = false;
            }

            canThrowRandoms = CheckRandomMessagePermit();
        }
        else
        {
            //Random messages
            if ((interlude <= 0) && (!messageIsVisible))
            {
                ShowRandomMessage();
                interlude = Random.Range(minInterlude, maxInterlude);
            }
            else
            {
                interlude -= Time.deltaTime;
            }
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
    /// Destroys the message window, and loads new message from a queue if needed
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

    /// <summary>
    /// Checks if all tutorial messages have already been shown (i. e. if random messages can start popping up)
    /// </summary>
    private bool CheckRandomMessagePermit()
    {
        foreach (bool a in awaitingFirstEvent)
            if (a)
                return false;
        return true;
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
