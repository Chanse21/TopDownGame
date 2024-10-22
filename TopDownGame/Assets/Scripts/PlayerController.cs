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

    //audio variables
    public AudioSource soundEffects;
    public AudioClip itemCollect;
    public AudioClip doorEnter;
    public AudioClip[] sounds;

    //public Rigidbody2D rb;
    public static PlayerController instance;

    // Start is called before the first frame update
    void Start()
    {
        soundEffects = GetComponent<AudioSource>();
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
            newPosition.x += .02f;
            //change sprite to right sprite
            sr.sprite = rightSprite;
        }

        if (Input.GetKey("a"))
        {
            //go left
            newPosition.x -= .02f;
            //change sprite to left sprite
            sr.sprite = leftSprite;
        }

        if (Input.GetKey("w"))
        {
            //go up
            newPosition.y += .02f;
            //change sprite to up sprite
            sr.sprite = upSprite;
        }

        if (Input.GetKey("s"))
        {
            //go down
            newPosition.y -= .02f;
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
            soundEffects.PlayOneShot(sounds[0], .7f); //play door sound effect
            SceneManager.LoadScene("Town"); //take to new scene
        }

        if(collision.gameObject.tag.Equals("key"))
        {
            Debug.Log("obtained key");
            soundEffects.PlayOneShot(itemCollect, .7f); //play item collect sound effect
            hasKey = true; //player has the key now
        }

        if(collision.gameObject.tag.Equals("Door2") && hasKey == true)
        {
            Debug.Log("unlocked door");
            soundEffects.PlayOneShot(sounds[1], .7f); //play door sound effect
            SceneManager.LoadScene("Park"); //take to new scene
        }

        if (collision.gameObject.tag.Equals("Door3"))
        {
            SceneManager.LoadScene("Park"); //take to new scene
        }

    }
}
