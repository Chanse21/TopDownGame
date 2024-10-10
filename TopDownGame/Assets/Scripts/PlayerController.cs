using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //importing SceneManagement Library

public class PlayerController : MonoBehaviour
{
    public float speed;
    private SpriteRenderer sr;
    public bool hasKey = false;

    //sprite variables
    public Sprite upSprite;
    public Sprite frontSprite;
    public Sprite rightSprite;
    public Sprite leftSprite;

    //public Rigidbody2D rb;
    public static PlayerController instance;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        if (instance != null) //if another instance of the player is in the scene
        {
            Destroy(gameObject); //then destroy it
        }
        instance = this; //reassign the instance to the current player
        GameObject.DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPosition = transform.position;

        if (Input.GetKey("d")) 
        {
            //go right
            newPosition.x += .01f;
            //change sprite to right sprite
            sr.sprite = rightSprite;
        }

        if (Input.GetKey("a"))
        {
            //go left
            newPosition.x -= .01f;
            //change sprite to left sprite
            sr.sprite = leftSprite;
        }

        if (Input.GetKey("w"))
        {
            //go up
            newPosition.y += .01f;
            //change sprite to up sprite
            sr.sprite = upSprite;
        }

        if (Input.GetKey("s"))
        {
            //go down
            newPosition.y -= .01f;
            sr.sprite = frontSprite;
        }

        transform.position = newPosition;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //check if colliding with a game object with specific tag
        if(collision.gameObject.tag.Equals("Door1"))
        {
            Debug.Log("change scene");
            SceneManager.LoadScene("Town");
        }

        if(collision.gameObject.tag.Equals("key"))
        {
            Debug.Log("obtained key");
            hasKey = true; //player has the key now
        }

        if(collision.gameObject.tag.Equals("Door2") && hasKey == true)
        {
            Debug.Log("unlocked door");
            //take to new scene
            SceneManager.LoadScene("Park");
        }

    }
}
