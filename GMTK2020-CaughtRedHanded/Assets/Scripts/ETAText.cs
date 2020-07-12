using UnityEngine;
using UnityEngine.UI;

public class ETAText : MonoBehaviour
{
    private Text text;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponentInChildren<Text>();

        text.text = "ETA ?:??";
    }
    
    public void UpdateETA(int seconds)
    {
        if (seconds < 0)
        {
            text.text = "ETA 3RR0R";
            return;
        }

        int min = seconds / 60;
        int sec = seconds % 60;
        text.text = string.Format("ETA {0}:{1:00}", min, sec);
    }
}
