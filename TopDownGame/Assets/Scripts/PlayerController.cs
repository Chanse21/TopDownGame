using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    private SpriteRenderer sr;

    //sprite variables
    public Sprite upSprite;
    public Sprite downSprite;
    public Sprite rightSprite;
    public Sprite leftSprite;
    
    //public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPosition = transform.position;

        if (Input.GetKey("d")) 
        {
            newPosition.x += .01f;
        }

        if (Input.GetKey("a"))
        {
            newPosition.x -= .01f;
        }

        if (Input.GetKey("w"))
        {
            newPosition.y += .01f;
        }

        if (Input.GetKey("s"))
        {
            newPosition.y -= .01f;
        }

        transform.position = newPosition;

    }
}
