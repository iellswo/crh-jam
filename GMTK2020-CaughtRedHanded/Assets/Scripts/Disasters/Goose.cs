using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Goose : Problem
{
    private int direction = 1;

    public float speed = 20;
    public float maxWidth = 10;
    public float minInterval;
    public float maxInterval;
    public float jumpForce;
    public SpriteRenderer cagedGoose;
    private float interval;
    private Rigidbody2D _rigidbody2D;
    private SpriteRenderer _spriteRenderer;

    // Start is called before the first frame update
    void Start(){
        
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _rigidbody2D.velocity = Vector2.right * speed;
        interval = Random.Range(minInterval, maxInterval);
    }

    // Update is called once per frame
    void Update(){
        var velX = speed * direction;
        var velY = _rigidbody2D.velocity.y;
        if (Math.Abs(transform.position.x) >= maxWidth){
            _rigidbody2D.transform.position = new Vector3((maxWidth-0.5f) * direction, transform.position.y, 0);
            _spriteRenderer.flipX = !_spriteRenderer.flipX;
            direction *= -1;
        }

        if (interval <= 0){
            velY += jumpForce;
            interval = Random.Range(minInterval, maxInterval);
        }
        _rigidbody2D.velocity = new Vector2(velX, velY);
        interval -= Time.deltaTime;
    }

    public override void Repair(){
        cagedGoose.enabled = true;
        GlobalData.looseGoose = false;
        Destroy(gameObject);
    }

    private void OnMouseOver(){
        if (SolutionCode != GlobalData.activeTool){
            Debug.Log("Goose Stole " + GlobalData.activeTool);
            FindObjectOfType<ToolTray>().heldTool.PutDownTool();
        }
    }
}
