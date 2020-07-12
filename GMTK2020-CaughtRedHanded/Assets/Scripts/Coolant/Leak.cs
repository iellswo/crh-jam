using UnityEngine;

public class Leak : Problem
{
    public CoolantController controller;

    public string fixedBy = "tape";

    public GameObject left;
    public GameObject right;

    public float _fillBeforeRepair;
    private bool _flip;
    private CoolantController.TowerSection _section;

    void Start()
    {
        left.SetActive(false);
        right.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(controller.currentLevel > _fillBeforeRepair)
        {
            SolutionCode = "none";
            ActivateSpill(_flip);
        }
        else
        {
            SolutionCode = fixedBy;
            TurnoffSpill();
        }
    }

    public void Setup(CoolantController.TowerSection section, float fillLevel, bool flip)
    {
        _section = section;
        _fillBeforeRepair = fillLevel;
        _flip = flip;
    }

    private void ActivateSpill(bool flip)
    {
        left.SetActive(flip);
        right.SetActive(!flip);
    }

    private void TurnoffSpill()
    {
        left.SetActive(false);
        right.SetActive(false);
    }
    
    public override void Repair()
    {   
        //AudioSource.PlayClipAtPoint(RepairSound, transform.position);
        controller._leak = null;
        controller.ReportFixedLeak(_section);
        GlobalData.activeLeak = false;
        Destroy(gameObject);
    }
}
