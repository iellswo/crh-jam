using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeatTracking : MonoBehaviour
{
    public Text heatText;
    public Text activeIssuesText;

    private int heat; //The current amount of heat; player dies at 100
    private int activeIssues; //The current number of disasters happening

    //Damages dealt by specific issue types:
    public int fireDamage = 10;

    void Start()
    {
        heat = 0;
        activeIssues = 0;
    }

    void Update()
    {
        activeIssues = CalculateActiveIssues();
        activeIssuesText.text = activeIssues + "";

        heat = CalculateCurrentHeat();
        if (heat >= 100)
        {
            Cursor.visible = true;
            GlobalFunctions.LoadScene("VictoryScene");
        }
        heatText.text = heat + "";
    }

    /// <summary>
    /// Counts how many disasters are currently active
    /// </summary>
    /// <returns></returns>
    private int CalculateActiveIssues()
    {
        int a = GlobalData.fireCount; //Other issues should be added here to the count
        return a;
    }

    private int CalculateCurrentHeat()
    {
        int a = GlobalData.fireCount * fireDamage; //Other issues should be added here to the count
        return a;
    }
}
