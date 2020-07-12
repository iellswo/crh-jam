using UnityEngine;

public class TowerSpriteManager : MonoBehaviour
{
    [System.Serializable]
    public class TowerSection
    {
        public Sprite Whole;
        public Sprite Cracked;
        public Sprite Repaired;
    }

    [Header("Renderers")]
    public SpriteRenderer topRender;
    public SpriteRenderer middleRender;
    public SpriteRenderer bottomRender;

    [Header("Sprites")]
    public TowerSection top;
    public TowerSection middle;
    public TowerSection bottom;

    // Start is called before the first frame update
    void Start()
    {
        topRender.sprite = top.Whole;
        middleRender.sprite = middle.Whole;
        bottomRender.sprite = bottom.Whole;
    }

    public void Break(CoolantController.TowerSection section)
    {
        switch(section)
        {
            case CoolantController.TowerSection.Top:
                topRender.sprite = top.Cracked;
                break;
            case CoolantController.TowerSection.Middle:
                middleRender.sprite = middle.Cracked;
                break;
            case CoolantController.TowerSection.Bottom:
                bottomRender.sprite = bottom.Cracked;
                break;
        }
    }

    public void Repair(CoolantController.TowerSection section)
    {
        switch (section)
        {
            case CoolantController.TowerSection.Top:
                topRender.sprite = top.Repaired;
                break;
            case CoolantController.TowerSection.Middle:
                middleRender.sprite = middle.Repaired;
                break;
            case CoolantController.TowerSection.Bottom:
                bottomRender.sprite = bottom.Repaired;
                break;
        }
    }
}
