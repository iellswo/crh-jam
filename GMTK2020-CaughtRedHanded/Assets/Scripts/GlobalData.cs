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
    public static int maxBreaches = 3;

    public static int blownFuzes=0;
    public static int cutWires = 0;

    public static int coolantLevel = 100;
    public static bool activeLeak = false;

    public static string activeTool;
    public static bool looseGoose;


    public static void ClearData()
    {
        fireCount = 0;
        brokenFans = 0;
        hullBreaches = 0;
        blownFuzes = 0;
        cutWires = 0;
        coolantLevel = 100;
        activeLeak = false;
        activeTool = "";
        looseGoose = false;
    }

    public static int ActiveDisasterCount()
    {
        int count = fireCount;
        count += brokenFans;
        count += hullBreaches;
        count += blownFuzes;
        count += cutWires;
        if (activeLeak) count += 1;
        if (looseGoose) count += 1;

        return count;
    }
}
