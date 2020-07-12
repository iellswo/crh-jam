using UnityEngine;

public class Lever : MonoBehaviour
{
    public Sprite upSprite;
    public Sprite centerSprite;
    public Sprite downSprite;

    public AudioClip kachunkClip;

    public float error = 0.5f;

    private bool isDragging;

    private SpriteRenderer sRenderer;
    private Vector3 mousePosition;

    private enum Position
    {
        down,
        center,
        up
    };

    private Position curPos;

    // Start is called before the first frame update
    void Start()
    {
        isDragging = false;
        sRenderer = GetComponent<SpriteRenderer>();
        sRenderer.sprite = centerSprite;
        curPos = Position.center;
    }

    // Update is called once per frame
    void Update()
    {
        switch(curPos)
        {
            case Position.up:
                sRenderer.sprite = upSprite;
                break;
            case Position.center:
                sRenderer.sprite = centerSprite;
                break;
            case Position.down:
                sRenderer.sprite = downSprite;
                break;
        }
    }

    public int GetDirection()
    {
        switch (curPos)
        {
            case Position.up:
                return 1;
            case Position.center:
                return 0;
            case Position.down:
                return -1;
        }

        return 0;
    }

    public void ReturnToCenter()
    {
        if (!isDragging)
            ChangePosition(Position.center);
    }

    private void OnMouseDown()
    {
        isDragging = true;
    }

    private void OnMouseDrag()
    {
        if (isDragging)
        {
            mousePosition = Input.mousePosition;
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

            float diff = mousePosition.y - transform.position.y;

            if (Mathf.Abs(diff) <= error)
            {
                ChangePosition(Position.center);
            }
            else if (diff > error)
            {
                ChangePosition(Position.up);
            }
            else
            {
                ChangePosition(Position.down);
            }
        }
    }

    private void OnMouseUp()
    {
        isDragging = false;
    }

    private void ChangePosition(Position newPos)
    {
        if (newPos != curPos)
        {
            curPos = newPos;
            GetComponent<AudioSource>().PlayOneShot(kachunkClip);
        }
    }
}
