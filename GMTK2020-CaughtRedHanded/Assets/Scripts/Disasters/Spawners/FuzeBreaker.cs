using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuzeBreaker : MonoBehaviour
{
    public float minInterlude;

    public float maxInterlude;


    public BurningFuze hazard;


    private float _interlude;
    public Problem _break;


    // Start is called before the first frame update
    void Start(){
        _interlude = Random.Range(minInterlude, maxInterlude);
    }

    // Update is called once per frame
    void Update(){

        if (Input.GetKeyDown(KeyCode.V)){
            BreakFuze();
        }
        else if (_interlude <= 0){
            BreakFuze();
            _interlude = Random.Range(minInterlude, maxInterlude);
        }
        else{
            _interlude -= Time.deltaTime;
        }
    }

    private void BreakFuze(){
        if (_break == null){
            var fuze = Instantiate(hazard, transform.position, Quaternion.identity);
            fuze.fuzeBreaker  = this;
            _break = fuze;
            GlobalData.blownFuzes++;
        }
    }

    public void hideFuze(){
        GetComponentInParent<SpriteRenderer>().enabled = false;
    }

    public void showFuze(){
        GetComponentInParent<SpriteRenderer>().enabled = true;

    }
}
