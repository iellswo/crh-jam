using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//if you want a group of scripts to have a function with the same name apply the interface after MonoBehavior
//this doesn't define what the functions do but allows you to use objects of type "IActivate" instead of GameObject
//which then lets you reference .Activate(), from there each object handles the call internally.
public interface IActivate
{
    void Activate();
}

public abstract class Problem : MonoBehaviour
{
    public AudioClip RepairSound;
    public string SolutionCode;
    public abstract void Repair();

    public void OnMouseDown(){
            if (SolutionCode == GlobalData.activeTool){
                Repair();
            }
    }
}