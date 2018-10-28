using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehiclesGoingLeft : MonoBehaviour {

    public Rigidbody2D rb;
	public LayerMask FrogMask;
	public GameObject frog;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        //transform.eulerAngles = new Vector3(0f, 0f, 90f);
    }

	void OnTriggerEnter2D (Collider2D other)
	{
		Debug.Log ("Car Kill");
		Vector3 position = this.transform.position;
		Collider2D[] colliders = Physics2D.OverlapAreaAll (new Vector2(position.x-0.5f,position.y+0.5f), new Vector2(position.x+0.5f, position.y-0.5f),  FrogMask);

		if (colliders.Length > 0){
			GameObject frogy = colliders[0].gameObject;
			Destroy (frogy);
			GameObject newFrog = Instantiate (frog);
		}

	}

	// Update is called once per frame
	void FixedUpdate () {
		if (rb.position.x >= -5) {
			Vector3 position = this.transform.position;
			position.x = position.x - 0.05f;
			this.transform.position = position;
		} else {
			Destroy (gameObject);
		}
	}
}
