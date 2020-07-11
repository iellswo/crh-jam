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
            messageBoxInstance = Instantiate(messageBoxPrefab, new Vector3(0, 0, 0), Quaternion.identity);
            messageBoxInstance.transform.parent = canvas.transform;
            messageBoxInstance.transform.localPosition = new Vector3(0, 0, 0);
            MessageBox messageBoxData = messageBoxInstance.GetComponent<MessageBox>();
            messageBoxData.messageCommander = this;

            messageIsVisible = true;
        }
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
