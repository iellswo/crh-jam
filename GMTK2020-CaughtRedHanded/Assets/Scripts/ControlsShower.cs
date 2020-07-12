using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlsShower : MonoBehaviour
{
    public GameObject controlsPrefab;
    private bool controlsOpen;
    private GameObject controlsInstance;

    public Transform canvas;
    public Transform hideButton;

    private void Start()
    {
        controlsOpen = false;
        controlsInstance = null;
        hideButton.localPosition = new Vector3(Screen.width * -1, 0);
    }

    public void ShowControls()
    {
        if (!controlsOpen)
        {
            controlsOpen = true;
            controlsInstance = Instantiate(controlsPrefab, canvas, false);
            controlsInstance.transform.localPosition = new Vector3(200, 0);

            hideButton.localPosition = new Vector3(0, 0);
        }
    }

    public void HideControls()
    {
        Destroy(controlsInstance);
        controlsInstance = null;

        hideButton.localPosition = new Vector3(Screen.width * -1, 0);

        controlsOpen = false;
    }
}
