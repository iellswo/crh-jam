using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlsShower : MonoBehaviour
{
    public GameObject controlsPrefab;
    private bool controlsOpen;
    private GameObject controlsInstance;

    public GameObject creditsPrefab;
    private bool creditsOpen;
    private GameObject creditsInstance;

    public Transform canvas;
    public Transform hideButton;
    public Transform hideCreditsButton;

    private void Start()
    {
        controlsOpen = false;
        controlsInstance = null;
        hideButton.localPosition = new Vector3(Screen.width * -1, 0);
        hideCreditsButton.localPosition = new Vector3(Screen.width * -1, 0); 
    }

    public void ShowControls()
    {
        if (!controlsOpen)
        {
            if (creditsOpen)
                HideCredits();

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

    public void ShowCredits()
    {
        if (!creditsOpen)
        {
            if (controlsOpen)
                HideControls();

            creditsOpen = true;
            creditsInstance = Instantiate(creditsPrefab, canvas, false);
            creditsInstance.transform.localPosition = new Vector3(200, 0);

            hideCreditsButton.localPosition = new Vector3(0, 0);
        }
    }

    public void HideCredits()
    {
        Destroy(creditsInstance);
        creditsInstance = null;

        hideCreditsButton.localPosition = new Vector3(Screen.width * -1, 0);

        creditsOpen = false;
    }
}
