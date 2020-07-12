using UnityEngine;

public class CoolantController : MonoBehaviour
{
    public float drainSpeed = 10;
    public float fillSpeed = 5;
    public float leakSpeed = 2;

    public LevelController levelController;
    public Lever lever;

    private float currentLevel;
    private float error = .05f;

    private enum CoolantState
    {
        Filling,
        Draining,
        Leaking,
        Steady
    }

    private CoolantState curState;

    // Start is called before the first frame update
    void Start()
    {
        lever.ReturnToCenter();
        levelController.AdjustFill(1, 10);
        currentLevel = 100;
    }

    // Update is called once per frame
    void Update()
    {
        CheckLeverState();
        //TODO: Check if there is a leak, this will override the lever state.
        AdjustLevel();
        FollowUp();
    }

    private void CheckLeverState()
    {
        int leverPos = lever.GetDirection();
        if (leverPos > 0)
        {
            curState = CoolantState.Filling;
        }
        else if (leverPos < 0)
        {
            curState = CoolantState.Draining;
        }
        else
        {
            curState = CoolantState.Steady;
        }
    }

    private void AdjustLevel()
    {
        switch(curState)
        {
            case CoolantState.Filling:
                currentLevel = Mathf.MoveTowards(currentLevel, 100, fillSpeed * Time.deltaTime);
                break;
            case CoolantState.Draining:
                currentLevel = Mathf.MoveTowards(currentLevel, 0, drainSpeed * Time.deltaTime);
                break;
        }

        levelController.AdjustFill(currentLevel / 100f, 1);
        GlobalData.coolantLevel = (int)Mathf.Round(currentLevel);
    }

    private void FollowUp()
    { 
        if (Mathf.Abs(currentLevel - 100) < error)
        {
            curState = CoolantState.Steady;
            lever.ReturnToCenter();
        }
        else if (Mathf.Abs(currentLevel) < error)
        {
            curState = CoolantState.Steady;
            lever.ReturnToCenter();
        }
    }
}
