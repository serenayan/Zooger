using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VehicleController : MonoBehaviour {

	public Rigidbody2D rb;
	public float speed;
	public LayerMask FrogMask;
	public GameObject frog1;
	public GameObject frog2;
	public GameObject gameOver;

	public AudioClip death;
	public AudioClip superDead;


	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		Vector3 position = this.transform.position;
		Collider2D[] colliders = Physics2D.OverlapAreaAll (new Vector2(position.x-0.5f,position.y+0.5f), new Vector2(position.x+0.5f, position.y-0.5f),  FrogMask);

		for (int i = 0; i < colliders.Length; i++) {
			Debug.Log (colliders.Length);
			GameObject[] player1 = GameObject.FindGameObjectsWithTag ("frog");
			GameObject[] player2 = GameObject.FindGameObjectsWithTag ("frog2");
			if (colliders[i].gameObject == player1[0]) {
				if (player1[0].transform.parent == null) {
					Debug.Log ("LOOK AT ME IM KILLING YOU");
					Destroy (player1[0]);
					Camera.main.gameObject.GetComponent<GameController> ().life1--;

					if (Camera.main.gameObject.GetComponent<GameController> ().life1 != 0) {
						GameObject newPlayer1 = Instantiate (frog1);
						AudioSource.PlayClipAtPoint (death, new Vector2 (0, 0));
						//Camera.main.gameObject.GetComponent<GameController> ().timeLeft = 60;
					} 
					else {
						AudioSource.PlayClipAtPoint (superDead, new Vector2 (0, 0));
						//GameObject newGameOver = Instantiate (gameOver);
						Debug.Log("Invoking Restart");
						Invoke ("Restart", 3);
					}
				}
			}

			else if (colliders[i].gameObject == player2[0])  {
				if (player2[0].transform.parent == null) {
					Debug.Log ("River Kill P2");
					Destroy (player2[0]);
					Camera.main.gameObject.GetComponent<GameController> ().life2--;

					if (Camera.main.gameObject.GetComponent<GameController> ().life2 != 0) {
						GameObject newPlayer2 = Instantiate (frog2);
						AudioSource.PlayClipAtPoint (death, new Vector2 (0, 0));
						//Camera.main.gameObject.GetComponent<GameController> ().timeLeft = 60;
					} 
					else {
						AudioSource.PlayClipAtPoint (superDead, new Vector2 (0, 0));
						//GameObject newGameOver = Instantiate (gameOver);
						Debug.Log("Invoking Restart");
						Invoke ("Restart", 3);
					}
				}
			}

		}

	}

	// Update is called once per frame
	void FixedUpdate () {

		if (rb.position.x < 5.5f && rb.position.x > -5.5f) {
			Vector3 position = this.transform.position;
			position.x = position.x + speed;
			this.transform.position = position;
		}

		else {
			Destroy (gameObject);
		}

	}
	private void Restart ()
	{
		Debug.Log ("Restarting");
		SceneManager.LoadScene ("level1", LoadSceneMode.Single);
	}

}