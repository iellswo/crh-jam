using UnityEngine;

public class DeadFuze : Problem
{
    public EmptyFuze emptyFuze;

    public FuzeBreaker fuzeBreaker;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void Repair(){
        spawnEmptyFuze();
        Destroy(gameObject);
    }

    private void spawnEmptyFuze(){
        var fuze = Instantiate(emptyFuze, transform.position, Quaternion.identity);
        fuzeBreaker._break = fuze;
        fuze.fuzeBreaker = fuzeBreaker;
    }
}
