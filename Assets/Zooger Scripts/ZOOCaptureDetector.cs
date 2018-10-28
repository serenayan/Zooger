using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZOOCaptureDetector : MonoBehaviour {

	public LayerMask FrogMask; 
	public Sprite complete;
	public AudioClip chickenDinner;
	public GameObject frog1;
	public GameObject frog2;
	//public Text winText;
	SpriteRenderer sr;

	// Use this for initialization
	void Start () {
		sr = GetComponent<SpriteRenderer> ();
		//winText.GetComponent<Text> ().enabled = false;
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		GameObject[] player1 = GameObject.FindGameObjectsWithTag ("frog");
		GameObject[] player2 = GameObject.FindGameObjectsWithTag ("frog2");
		Vector3 position = this.transform.position;
		Collider2D[] colliders = Physics2D.OverlapAreaAll (new Vector2(position.x-5f,position.y+1.2f), new Vector2(position.x+5f, position.y-1.2f),  FrogMask);

		if (colliders[0].gameObject == player1[0]){
			Debug.Log ("should be changing sprite");
			sr.sprite = complete;
			Destroy (colliders [0].gameObject);
			gameObject.GetComponent<BoxCollider2D>().enabled = false;
			Camera.main.gameObject.GetComponent<GameController>().collected++ ;

			if (Camera.main.gameObject.GetComponent<GameController> ().collected == 5) {
				AudioSource.PlayClipAtPoint (chickenDinner, new Vector2(0,0));
				//winText.GetComponent<Text> ().enabled = true;
			} else {
				GameObject newFrog = Instantiate (frog1);

			}
		}
		if (colliders[0].gameObject == player2[0]){
			Debug.Log ("should be changing sprite");
			sr.sprite = complete;
			Destroy (colliders [0].gameObject);
			gameObject.GetComponent<BoxCollider2D>().enabled = false;
			Camera.main.gameObject.GetComponent<GameController>().collected++ ;

			if (Camera.main.gameObject.GetComponent<GameController> ().collected == 5) {
				AudioSource.PlayClipAtPoint (chickenDinner, new Vector2(0,0));
				//winText.GetComponent<Text> ().enabled = true;
			} else {
				GameObject newFrog = Instantiate (frog2);

			}
		}

	}

	// Update is called once per frame
	void Update () {

	}
}
