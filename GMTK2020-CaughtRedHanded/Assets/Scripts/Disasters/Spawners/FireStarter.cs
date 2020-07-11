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
        var location = new Vector3(Random.Range(_rect.xMin, _rect.xMax), Random.Range(_rect.yMin, _rect.yMax), 0);
        Instantiate(hazard, location, Quaternion.identity);
        GlobalData.fireCount++;
    }
}
