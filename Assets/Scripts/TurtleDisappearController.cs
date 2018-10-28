using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurtleDisappearController: MonoBehaviour
{
    public LayerMask FrogMask;
    public SpriteRenderer sr;
    public Sprite sink;
    public Sprite fl;

    // Use this for initialization
    void Start()
    {
        //sr = GetComponent<SpriteRenderer>();
        Invoke("DisableCollider", 2.5f);

    }
    void EnableCollider()
    {
        gameObject.GetComponent<BoxCollider2D>().enabled = true;
        //sr.sprite = fl;
        Invoke("DisableCollider", 2.5f);
    }
    void DisableCollider()
    {
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        //sr.sprite = sink;
        Invoke("EnableCollider", .5f);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        Vector3 position = this.transform.position;
        Collider2D[] colliders = Physics2D.OverlapAreaAll(new Vector2(position.x - 5f, position.y + 1.2f), new Vector2(position.x + 5f, position.y - 1.2f), FrogMask);

        if (colliders.Length > 0)
        {
            if (colliders[0].transform.parent != null)
            {
                Invoke("DelayedEnter", 0f);
                Debug.Log("Delaying");
            }
            else
            {
                Debug.Log("Frog Entered");
                GameObject frogy = colliders[0].gameObject;
                frogy.transform.parent = this.transform;
            }
        }

    }

    void DelayedEnter()
    {
        Debug.Log("Delay Over");
        Vector3 position = this.transform.position;
        Collider2D[] colliders = Physics2D.OverlapAreaAll(new Vector2(position.x - 5f, position.y + 1.2f), new Vector2(position.x + 5f, position.y - 1.2f), FrogMask);
        if (colliders.Length > 0)
        {
            Debug.Log("Frog Entered");
            GameObject frogy = colliders[0].gameObject;
            frogy.transform.parent = this.transform;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("Frog Left");
        Vector3 position = this.transform.position;
        GameObject frogy = other.gameObject;
        frogy.transform.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(GetComponent<BoxCollider2D>().enabled);
    }
}

