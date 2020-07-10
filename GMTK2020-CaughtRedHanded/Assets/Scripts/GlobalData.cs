using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class is always loaded sine MonoBehabior is removed, I doubt timed functions like Start()/Update() work
//Use this to store variables that we don't want to change/lose on scene loading or that we want to reference in lots of classes.

public class GlobalData
{
    public Vector2 StartPosition;
}
