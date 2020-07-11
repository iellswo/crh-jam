using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanBreaker : MonoBehaviour
{
    public float minInterlude;

    public float maxInterlude;


    public Problem hazard;

    
    private Rect _rect;
    private float _interlude;
    public Problem _break;

    private FanScript _fanScript;

    // Start is called before the first frame update
    void Start(){
        _fanScript = GetComponentInParent<FanScript>();
        _rect = GetComponent<RectTransform>().rect;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.G)){
            BreakFan();
        }
        else if (GlobalData.maxFires > GlobalData.fireCount && _interlude <= 0){

            _interlude = Random.Range(minInterlude, maxInterlude);
        }
        else{
            _interlude -= Time.deltaTime;
        }
    }

    private void BreakFan(){
        if (_break == null){
            var location = new Vector3(Random.Range(_rect.xMin, _rect.xMax), Random.Range(_rect.yMin, _rect.yMax), 0);
            
            _break = Instantiate(hazard, transform.position, Quaternion.identity);
            _break.transform.parent = transform;
            _break.transform.localPosition = location;
            var breakscript = _break.GetComponent<FanSpark>();
            breakscript.fan = _fanScript;
            _fanScript.Stop();
            breakscript.handler = this;
        }
    }
}
