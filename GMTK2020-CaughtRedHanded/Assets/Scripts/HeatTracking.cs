using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeatTracking : MonoBehaviour
{
    public Text heatText;
    public Transform heatBar;
    public Image heatColumn;
    public float heatSpeed = 2f;

    private int heat; //The current amount of heat; player dies at 100

    //Damages dealt by specific issue types:
    public int fireDamage = 10;
    public int fanDamage = 30;
    public int breachDamage = 5;
    public int fuseDamage = 5;
    public int wireDamage = 20;
    public int coolantDamageMax = 35;
    
    void Start()
    {
        heat = 0;
    }

    /// <summary>
    /// Updates health bar and checks if the game should end
    /// </summary>
    void Update()
    {

        heat = CalculateCurrentHeat();
        if (heat >= 100)
        {
            Cursor.visible = true;
            GlobalFunctions.LoadScene("VictoryScene");
        }
        float heatNormal = heat / 100f;
        Vector3 desiredScale = new Vector3(1f, heatNormal);
        heatBar.localScale = Vector3.Lerp(heatBar.localScale, desiredScale, Time.deltaTime * heatSpeed);
        heatColumn.color = new Color(heatColumn.color.r, heatColumn.color.g, heatColumn.color.b, (heatBar.localScale.y+0.2f));
        heatText.text = heat + "";
    }

    /// <summary>
    /// Calculates current heat as a sum of numbers of disasters of given type times damage value for that type
    /// </summary>
    /// <returns></returns>
    private int CalculateCurrentHeat(){
        int heat = GlobalData.fireCount * fireDamage;
        heat += GlobalData.brokenFans * fanDamage;
        heat += GlobalData.hullBreaches * breachDamage;
        heat += GlobalData.blownFuzes * fuseDamage;
        heat += GlobalData.cutWires * wireDamage;
        heat += CalculateCoolantHeat();
        //Other issues should be added here to the count
        return heat;
    }

    private int CalculateCoolantHeat()
    {
        int deficit = 100 - GlobalData.coolantLevel;
        float fDeficit = (deficit * 1.0f) / 100f;
        float fHeat = fDeficit * coolantDamageMax;

        return (int)Mathf.Round(fHeat);
    }

}
