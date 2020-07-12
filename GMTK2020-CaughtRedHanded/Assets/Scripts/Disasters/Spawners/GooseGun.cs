using System.Collections.Generic;
using UnityEngine;

public class GooseGun : MonoBehaviour
{
    public float initInterval;
    public float minInterval;
    public float maxInterval;
    public Goose goose;

    private Goose looseGoose;
    private float interval;

    private SpriteRenderer _spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        _spriteRenderer =new List<SpriteRenderer>(GetComponentsInChildren<SpriteRenderer>()).Find(_rend => _rend.CompareTag($"EngineGoose"));
        interval = initInterval;
    }

    // Update is called once per frame
    void Update()
    {
        if (interval <= 0)
        {
            DisasterHandler.Singleton.AddDisaster(1, LooseTheGoose);
            interval = Random.Range(minInterval, maxInterval);
        }

        interval -= Time.deltaTime;
    }

    public void LooseTheGoose()
    {
        if (!GlobalData.looseGoose)
        {
            Goose newGoose = Instantiate(goose, transform.position, Quaternion.identity);
            newGoose.cagedGoose = _spriteRenderer;
            GlobalData.looseGoose = true;
            _spriteRenderer.enabled = false;
        }
    }
}
