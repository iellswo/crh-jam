using UnityEngine;

public class FuzeBreaker : MonoBehaviour
{
    public float initInterlude;

    public float minInterlude;

    public float maxInterlude;

    public Sprite normalSprite;
    public Sprite burntOutSprite;

    public BurningFuze hazard;


    private float _interlude;
    public Problem _break;

    private AudioSource _audioSource;
    public AudioClip breakAudio;
    public AudioClip removeAudio;


    // Start is called before the first frame update
    void Start()
    {
        _interlude = initInterlude;
        _audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        //if (Input.GetKeyDown(KeyCode.V)){
        //    DisasterHandler.Singleton.AddDisaster(3, BreakFuze);
        //}
        //else 
        if (_interlude <= 0)
        {
            DisasterHandler.Singleton.AddDisaster(3, BreakFuze);
            _interlude = Random.Range(minInterlude, maxInterlude);
        }
        else{
            _interlude -= Time.deltaTime;
        }
    }

    private void BreakFuze(){
        if (_break == null){
            GetComponent<SpriteRenderer>().sprite = burntOutSprite;
            var fuze = Instantiate(hazard, transform.position, Quaternion.identity);
            fuze.fuzeBreaker  = this;
            _break = fuze;
            GlobalData.blownFuzes++;
            _audioSource.PlayOneShot(breakAudio);
        }
    }

    public void hideFuze(){
        GetComponentInParent<SpriteRenderer>().enabled = false;
    }

    public void showFuze(){
        GetComponentInParent<SpriteRenderer>().enabled = true;
        GetComponent<SpriteRenderer>().sprite = normalSprite;
    }
}
