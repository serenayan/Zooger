using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogScript : MonoBehaviour {

	public LayerMask FrogMask; 

	// Use this for initialization
	void Start () {
		
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.gameObject.tag == "frog" || other.gameObject.tag == "frog2") {
			other.gameObject.transform.parent = this.transform;

		}


	}

	void OnTriggerStay2D (Collider2D other)
	{
		if (other.gameObject.tag == "frog" || other.gameObject.tag == "frog2") {
			if (other.gameObject.transform.parent == null)
				other.gameObject.transform.parent = this.transform;

		}


	}

	/*IEnumerator smallDelay (Collider2D other) {
		yield return new WaitForSeconds (.05f);
		if (other.transform.parent == null) {
			other.gameObject.transform.parent = this.transform;
			Debug.Log ("Frog Entered Delayed");
		}
	}*/

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

	// Update is called once per frame
	void Update () {

	}
}
