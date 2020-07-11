using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireStarter : MonoBehaviour
{
    public float minInterlude;

    public float maxInterlude;


    public GameObject hazard;

    
    private Rect _rect;
    private float _interlude;

    // Start is called before the first frame update
    void Start(){
        _rect = GetComponent<RectTransform>().rect;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.F)){
            SpawnFire();
        }
        
        if (GlobalData.maxFires > GlobalData.fireCount && _interlude <= 0){
            SpawnFire();
            _interlude = Random.Range(minInterlude, maxInterlude);
        }
        else{
            _interlude -= Time.deltaTime;
        }
    }

    private void SpawnFire(){
        
        float xBuffer = (_rect.xMax - _rect.xMin)/10;
        float yBuffer = (_rect.yMax - _rect.yMin)/10;
        var location = new Vector3(Random.Range(_rect.xMin+xBuffer, _rect.xMax-xBuffer), Random.Range(_rect.yMin+yBuffer, _rect.yMax+yBuffer), 0);
        // var location = new Vector3(_rect.xMax/2, _rect.yMax/2, 0);
        Instantiate(hazard, location, Quaternion.identity);
        GlobalData.fireCount++;
    }
}
