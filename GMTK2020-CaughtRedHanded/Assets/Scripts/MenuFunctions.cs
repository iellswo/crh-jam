using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MenuFunctions : MonoBehaviour
{
    public void Quit(){
        Application.Quit();
    }

    public void NewGame(){
        GlobalFunctions.LoadScene("MainScene");
    }

    public void OpenControls(){
//        Instantiate(ControlsMenu, Vector3.zero, Quaternion.identity);
    }
}
