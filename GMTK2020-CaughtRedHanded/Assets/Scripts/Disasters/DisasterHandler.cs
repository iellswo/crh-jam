using System.Collections.Generic;
using UnityEngine;

public class DisasterHandler : MonoBehaviour
{
    public static DisasterHandler Singleton;
    public delegate void SpawnDisaster();

    public class DisasterRequest
    {
        public int priority;
        public SpawnDisaster spawnFunc;
    }

    [System.Serializable]
    public class ProgramStep
    {
        [Tooltip("How long does this step last?")]
        public float length;
        [Tooltip("How many disasters at once do we allow?")]
        public int disastersAllowed;
        [Tooltip("Minimum amount of time between checks/spawns")]
        public float minInterval;
        [Tooltip("Maxmum amount of time between checks/spawns")]
        public float maxInterval;
        [Tooltip("How often should we clear the queue, allowing new disasters a chance? (Leave at 0 for never)")]
        public float clearQueue;
    }

    public float initialInterval = 8f;

    public ProgramStep[] programSteps;

    public ETAText eta;
    public MessageCommanding messageCommanding;
    public AudioClip victJingle;

    private AudioSource audioSource;

    private string victMessage = "Looks like we made it, sport.  And by the skin of our teeth too!  Come on up to the bridge, you've earned some shore leave, first round is on old Niat!";

    private float timeRemaining;

    [Header("Data")]
    [Tooltip("don't edit this, just for information")]
    public int DisastersInQueue;
    [Tooltip("don't edit this, just for information")]
    public int ActiveDisasters;

    private int curStepIndex;
    private ProgramStep curStep;

    private List<DisasterRequest> disasterRequests;

    private float _timeInCurrentStep;
    private float _timeSinceLastCheck;
    private float _timeSinceLastClear;
    private bool _areClearing;
    
    private float _interval;

    private bool _victMessageShown;

    // Start is called before the first frame update
    void Start()
    {
        disasterRequests = new List<DisasterRequest>();
        Singleton = this;
        curStepIndex = 0;
        curStep = programSteps[curStepIndex];
        _timeInCurrentStep = 0f;
        _timeSinceLastCheck = 0f;
        _timeSinceLastClear = 0f;
        _interval = initialInterval;
        _areClearing = curStep.clearQueue > 0f;

        timeRemaining = GetTotalTime();
        _victMessageShown = false;

        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        ActiveDisasters = GlobalData.ActiveDisasterCount();
        _timeInCurrentStep += Time.deltaTime;
        _timeSinceLastCheck += Time.deltaTime;
        _timeSinceLastClear += Time.deltaTime;
        timeRemaining -= Time.deltaTime;
        eta.UpdateETA(Mathf.RoundToInt(timeRemaining));
        if (timeRemaining <= 0 && !_victMessageShown)
        {
            Debug.Log("Victory!");
            Victory();
        }
        else if (timeRemaining <= -0.5f)
        {
            Debug.Log("End");
            Victory();
        }

        if (curStepIndex < programSteps.Length && _timeInCurrentStep > curStep.length)
        {
            curStepIndex++;
            if (curStepIndex < programSteps.Length)
            {
                curStep = programSteps[curStepIndex];
                _timeInCurrentStep = 0f;
                _areClearing = curStep.clearQueue > 0f;
            }
        }

        if (_areClearing && _timeSinceLastClear > curStep.clearQueue)
        {
            Debug.Log("Dump all" + DisastersInQueue + " outstanding requests");
            disasterRequests.Clear();
            DisastersInQueue = 0;
            _timeSinceLastClear = 0f;
        }

        if (_timeSinceLastCheck > _interval)
        {
            _interval = GetNewInterval();
            _timeSinceLastCheck = 0f;
            if (disasterRequests.Count > 0 && (GlobalData.ActiveDisasterCount() < curStep.disastersAllowed || curStep.disastersAllowed < 0))
            {
                Debug.Log("Spawning a new Disaster");
                disasterRequests[0].spawnFunc();
                disasterRequests.RemoveAt(0);
                DisastersInQueue -= 1;
            }
            else if (GlobalData.ActiveDisasterCount() >= curStep.disastersAllowed)
            {
                Debug.Log("Too many disaster, give the player a break");
            }
            else
            {
                Debug.Log("No disasters in queue");
            }
        }
    }

    public void AddDisaster(int priority, SpawnDisaster spawnFunc)
    {
        DisasterRequest newRequest = new DisasterRequest();
        newRequest.priority = priority + Random.Range(-2, 2);
        newRequest.spawnFunc = spawnFunc;

        disasterRequests.Add(newRequest);

        disasterRequests.Sort((a, b) =>
        {
            return a.priority.CompareTo(b.priority);
        });

        DisastersInQueue += 1;
    }

    private void Victory()
    {
        if (!_victMessageShown)
        {
            Debug.Log("Showing victory message");
            audioSource.PlayOneShot(victJingle);
            _victMessageShown = true;
            messageCommanding.ShowOutsiderMessage(victMessage, "Hooray?", true);
        }
        else
        {
            Debug.Log("Going to victory screen");
            Cursor.visible = true;
            GlobalFunctions.LoadScene("RealVictoryScene");
        }
    }

    private float GetNewInterval()
    {
        return Random.Range(curStep.minInterval, curStep.maxInterval);
    }

    private float GetTotalTime()
    {
        float t = 0;
        foreach (ProgramStep step in programSteps)
        {
            t += step.length;
        }

        return t;
    }
}
