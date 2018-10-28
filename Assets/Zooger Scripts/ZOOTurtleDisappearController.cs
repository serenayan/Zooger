using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZOOTurtleDisappearController: MonoBehaviour
{
    public LayerMask FrogMask;
    /*public SpriteRenderer sr;
    public Sprite sink;
    public Sprite fl;*/

    // Use this for initialization
    void Start()
    {
        //sr = GetComponent<SpriteRenderer>();
        Invoke("DisableCollider", 2.1666f);

    }
    void EnableCollider()
    {
        gameObject.GetComponent<BoxCollider2D>().enabled = true;
        //sr.sprite = fl;
        Invoke("DisableCollider", 4f);
    }
    void DisableCollider()
    {
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        //sr.sprite = sink;
        Invoke("EnableCollider", 1f);
    }
	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.gameObject.tag == "frog" || other.gameObject.tag == "frog2") {
			Debug.Log ("Frog Entered");
			other.gameObject.transform.parent = this.transform;

		}


	}

	void OnTriggerStay2D (Collider2D other)
	{
		if (other.gameObject.tag == "frog" || other.gameObject.tag == "frog2") {
			if (other.gameObject.transform.parent == null) {
				other.gameObject.transform.parent = this.transform;
				Debug.Log ("Frog Entered");
			}
		}


	}

	void OnTriggerExit2D (Collider2D other)
	{
		if (other.gameObject.tag == "frog" || other.gameObject.tag == "frog2") {
			Debug.Log ("Frog Left");
			Vector3 position = this.transform.position;
			GameObject frogy = other.gameObject;
			if (frogy.transform.parent == this.transform)
				frogy.transform.parent = null;
		}
	}
}

