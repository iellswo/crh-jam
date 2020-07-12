using UnityEngine;

public class WireCutter : MonoBehaviour
{
    public float initInterlude;

    public float minInterlude;

    public float maxInterlude;


    public BrokenWire hazard;


    private float _interlude;
    public Problem _break;
    private SpriteRenderer _spriteRenderer;


    // Start is called before the first frame update
    void Start(){
        _spriteRenderer = GetComponentInParent<SpriteRenderer>();
        _interlude = initInterlude;
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.C)){
        //    CutWire();
        //}
        //else 
        if (_interlude <= 0)
        {
            DisasterHandler.Singleton.AddDisaster(4, CutWire);
            _interlude = Random.Range(minInterlude, maxInterlude);
        }
        else
        {
            _interlude -= Time.deltaTime;
        }
    }

    private void CutWire()
    {
        if (_break == null){
            var wire = Instantiate(hazard, transform.position, Quaternion.identity);
            wire.wireCutter  = this;
            hideWire();
            _break = wire;
        }
    }

    public void hideWire(){
        _spriteRenderer.enabled = false;
    }

    public void showWire(){
        _spriteRenderer.enabled = true;
    }
}
