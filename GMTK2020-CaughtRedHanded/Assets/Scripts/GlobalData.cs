using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class is always loaded sine MonoBehabior is removed, I doubt timed functions like Start()/Update() work
//Use this to store variables that we don't want to change/lose on scene loading or that we want to reference in lots of classes.

public class GlobalData
{
    public Vector2 StartPosition;
    public static int fireCount = 0;
    public static int maxFires = 5;

    public static int brokenFans = 0;

    public static int hullBreaches = 0;
    public static int maxBreaches = 10;

    public static int blownFuzes=0;
    public static int cutWires = 0;

    public static string activeTool;
}
