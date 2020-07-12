using UnityEngine;

public class FanBreaker : MonoBehaviour
{
    public float initInterlude;

    public float minInterlude;

    public float maxInterlude;


    public Problem hazard;

    
    private Rect _rect;
    private float _interlude;
    public Problem _break;

    private FanScript _fanScript;

    // Start is called before the first frame update
    void Start(){
        _interlude = 35;
        _fanScript = GetComponentInParent<FanScript>();
        _rect = GetComponent<RectTransform>().rect;
    }

    // Update is called once per frame
    void Update()
    {

        //if (Input.GetKeyDown(KeyCode.G)){
        //    DisasterHandler.Singleton.AddDisaster(2, BreakFan);
        //}
        //else 
        if (_interlude <= 0)
        {
            DisasterHandler.Singleton.AddDisaster(2, BreakFan);
            _interlude = Random.Range(minInterlude, maxInterlude);
        }
        else
        {
            _interlude -= Time.deltaTime;
        }
    }

    private void BreakFan(){
        if (_break == null){
            //var location = new Vector3(Random.Range(_rect.xMin, _rect.xMax)/_rect.width, Random.Range(_rect.yMin, _rect.yMax)/_rect.height, 0);
            _break = Instantiate(hazard, transform.position, Quaternion.identity);
            var breakscript = _break.GetComponent<FanSpark>();
            breakscript.fan = _fanScript;
            _fanScript.Stop();
            breakscript.handler = this;
            GlobalData.brokenFans++;
        }
    }
}
