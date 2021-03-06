using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZOOLavaRandom : MonoBehaviour {

	public AudioClip dying;
	public GameObject Player1;
	public GameObject Player2;
	public bool isLavaOn;
	public bool player1OnLava;
	public bool player2OnLava;


	private GameObject kangaroo1;
	private GameObject kangaroo2;


	// Use this for initialization
	void Start () {
		StartCoroutine (RandomLava());
		gameObject.GetComponent<Animator>().enabled = false;
		isLavaOn = false;
		player1OnLava = false;
		player2OnLava = false;
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.gameObject.tag == "frog") {
			player1OnLava = true;
		}
		if (other.gameObject.tag == "frog2") {
			player2OnLava = true;
		}
	}

	void OnTriggerExit2D (Collider2D other) {
		if (other.gameObject.tag == "frog") {
			player1OnLava = false;
		}
		if (other.gameObject.tag == "frog2") {
			player2OnLava = false;
		}
	}

	IEnumerator RandomLava ()
	{
		while (true) {
			float f = Random.Range(1f, 10f);
			yield return new WaitForSeconds (f);
			gameObject.GetComponent<Animator> ().enabled = true;
			yield return new WaitForSeconds (2.5f);

			isLavaOn = true;

			yield return new WaitForSeconds (3.5f);
			isLavaOn = false;
			yield return new WaitForSeconds (1.0833f);
			gameObject.GetComponent<Animator> ().enabled = false;
		}
	}

	void Update ()
	{
		
		if (isLavaOn && player1OnLava) {
			GameObject newPlayer1 = Instantiate (Player1);
			kangaroo1 = GameObject.FindGameObjectWithTag ("frog");
			AudioSource.PlayClipAtPoint(dying, new Vector2(0, 0));
			Destroy (kangaroo1);
			player1OnLava = false;
		}
		if (isLavaOn && player2OnLava) {
			GameObject newPlayer2 = Instantiate (Player2);
			kangaroo2 = GameObject.FindGameObjectWithTag ("frog2");
			AudioSource.PlayClipAtPoint(dying, new Vector2(0, 0));
			Destroy (kangaroo2);
			player2OnLava = false;
		}
	}
		
}
