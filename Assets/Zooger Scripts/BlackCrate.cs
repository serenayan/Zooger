using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BlackCrate : MonoBehaviour {

	public LayerMask FrogMask; 
	public Sprite redCapture;
	public Sprite greenCapture;
	public AudioClip chickenDinner;
	public GameObject frog1;
	public GameObject frog2;
	public GameObject RedWin;
	public GameObject GreenWin;
	SpriteRenderer sr;

	// Use this for initialization
	void Start () {
		sr = GetComponent<SpriteRenderer> ();
	}

	void OnTriggerEnter2D (Collider2D other)
	{

		if (other.gameObject.tag == "frog" || other.gameObject.tag == "frog2") {
			Debug.Log ("Frog On Crate");
			other.gameObject.transform.parent = this.transform;

		}
			
	}
	void OnTriggerExit2D (Collider2D other)
	{
		if (other.gameObject.tag == "frog" || other.gameObject.tag == "frog2") {
			Debug.Log ("Frog Off Crate");
			Vector3 position = this.transform.position;
			GameObject frogy = other.gameObject;
			if (frogy.transform.parent == this.transform)
				frogy.transform.parent = null;
		}
	}
		
}
