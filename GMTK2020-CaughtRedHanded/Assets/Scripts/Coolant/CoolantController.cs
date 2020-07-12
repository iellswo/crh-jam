using UnityEngine;

public class CoolantController : MonoBehaviour
{
    [System.Serializable]
    public class LeakDefinition
    {
        public float xPos;
        public float yPos;
        public float fillLevel;
        public bool flip;
    }

    public float drainSpeed = 10;
    public float fillSpeed = 5;
    public float leakSpeed = 2;

    public LevelController levelController;
    public Lever lever;

    public float initInterlude;

    public float minInterlude = 60;

    public float maxInterlude = 180;

    public LeakDefinition upperLeak;
    public LeakDefinition middleLeak;
    public LeakDefinition lowerLeak;

    public Leak leakPrefab;

    [HideInInspector]
    public float currentLevel;
    private float error = .05f;
    
    private float _interlude;
    [HideInInspector]
    public Leak _leak;

    private TowerSpriteManager towerSpriteManager;

    private AudioSource _audioSource;
    public AudioSource leakageAudioSource;

    private enum CoolantState
    {
        Filling,
        Draining,
        Leaking,
        Steady
    }

    public enum TowerSection
    {
        Top,
        Middle,
        Bottom
    }

    private CoolantState curState;

    // Start is called before the first frame update
    void Start()
    {
        towerSpriteManager = GetComponent<TowerSpriteManager>();

        lever.ReturnToCenter();
        levelController.AdjustFill(1, 10);
        currentLevel = 100;
        _interlude = initInterlude;

        _audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckLeverState();
        CheckLeakState();
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

    private void CheckLeakState()
    {
        //if (Input.GetKeyDown(KeyCode.L) && !GlobalData.activeLeak)
        //{
        //    QueueLeak();
        //    _interlude = Random.Range(minInterlude, maxInterlude);
        //}
        //else 
        if (!GlobalData.activeLeak && _interlude <=0)
        {
            QueueLeak();
            _interlude = Random.Range(minInterlude, maxInterlude);
        }
        else if (_interlude <= 0)
        {
            _interlude = Random.Range(minInterlude, maxInterlude);
        }
        else
        {
            _interlude -= Time.deltaTime;
        }
        
        if (GlobalData.activeLeak)
        {
            if (currentLevel > (_leak._fillBeforeRepair - .5f) && curState != CoolantState.Draining)
            {
                curState = CoolantState.Leaking;
            }
        }
    }

    private void QueueLeak()
    {
        DisasterHandler.Singleton.AddDisaster(1, SpringLeak);
    }

    private void SpringLeak()
    {
        GlobalData.activeLeak = true;
        int pos = Mathf.FloorToInt(Random.Range(0, 2.99f));

        switch(pos)
        {
            case 0:
                towerSpriteManager.Break(TowerSection.Top);
                CreateLeak(TowerSection.Top, upperLeak);
                break;
            case 1:
                towerSpriteManager.Break(TowerSection.Middle);
                CreateLeak(TowerSection.Middle, middleLeak);
                break;
            case 2:
                towerSpriteManager.Break(TowerSection.Bottom);
                CreateLeak(TowerSection.Bottom, lowerLeak);
                break;
        }

        _audioSource.Play();
        leakageAudioSource.Play();
    }

    private void CreateLeak(TowerSection section, LeakDefinition definition)
    {
        if (_leak == null)
        {
            Vector3 offset = new Vector3(definition.xPos, definition.yPos, 0);
            _leak = Instantiate(leakPrefab, transform.position + offset, Quaternion.identity);
            _leak.Setup(section, definition.fillLevel, definition.flip);
            _leak.controller = this;
        }
    }

    public void ReportFixedLeak(TowerSection section)
    {
        towerSpriteManager.Repair(section);
        leakageAudioSource.Stop();
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
            case CoolantState.Leaking:
                currentLevel = Mathf.MoveTowards(currentLevel, 0, leakSpeed * Time.deltaTime);
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
