using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GooseGun : MonoBehaviour
{
    public float minInterval;
    public float maxInterval;
    public Goose goose;

    private Goose looseGoose;
    private float interval;

    private SpriteRenderer _spriteRenderer;

    // Start is called before the first frame update
    void Start(){
        _spriteRenderer =new List<SpriteRenderer>(GetComponentsInChildren<SpriteRenderer>()).Find(_rend => _rend.CompareTag($"EngineGoose"));
        interval = Random.Range(minInterval, maxInterval);
    }

    // Update is called once per frame
    void Update()
    {
        if ((interval <= 0 || Input.GetKeyDown(KeyCode.T)) && GlobalData.looseGoose == false){
            goose = Instantiate(goose, transform.position, Quaternion.identity);
            goose.cagedGoose = _spriteRenderer;
            GlobalData.looseGoose = true;
            _spriteRenderer.enabled = false;
            interval = Random.Range(minInterval, maxInterval);
        }

        interval -= Time.deltaTime;
    }
}
