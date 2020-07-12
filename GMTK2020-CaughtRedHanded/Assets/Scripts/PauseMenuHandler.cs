using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenuHandler : MonoBehaviour
{
    public Transform panel;
    private Vector3 restPosition;

    private void Start()
    {
        restPosition = new Vector3(0, Screen.height * -1);
        panel.localPosition = restPosition;
    }

    public void PauseGame()
    {
        panel.localPosition = new Vector3(0, 0);
        Time.timeScale = 0;
    }

    public void UnpauseGame()
    {
        Time.timeScale = 1;
        panel.localPosition = restPosition;
    }

    public void BackToMainMenu()
    {
        GlobalFunctions.LoadScene("TitleScene");
    }


}
