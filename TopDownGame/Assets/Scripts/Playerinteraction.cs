using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playerinteraction : MonoBehaviour
{

    //public float triggerDistance;

    public GameObject textbox;
    private bool isNearSprite;
    private SpriteRenderer Sr;
    // Start is called before the first frame update
    void Start()
    {
        Sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)

    {

        if (collision.gameObject.CompareTag("Player")) // Check if the colliding object is your desired sprite

        {
            Debug.Log("Hit");

            //isNearSprite = true;

            //gameObject.SetActive(true); // Make the sprite visible
            Sr.enabled = true;

        }

    }


    void OnTriggerExit2D(Collider2D collision)

    {

        if (collision.gameObject.CompareTag("Player"))

        {

            //isNearSprite = false;

            //gameObject.SetActive(false); // Make the sprite invisible
            Sr.enabled = false;

        }

    }


}
