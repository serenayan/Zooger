using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Frog2Controller : MonoBehaviour {

	public Rigidbody2D rb;
	public AudioClip hop;
	public GameObject gameOver;
	public AudioClip death;
	public AudioClip superDead;
	public LayerMask vehicleMask;
	public GameObject frog2;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();

	}

	// Update is called once per frame
	void Update ()
	{

		if (Input.GetKeyDown(KeyCode.LeftArrow))
		{
			transform.eulerAngles = new Vector3(0f, 0f, 90f);
			Vector3 position = this.transform.position;

			if (position.x > -4.0235f) {
				position.x = position.x - .6190f;
				this.transform.position = position;
				AudioSource.PlayClipAtPoint (hop, new Vector2(0,0));
			}

		}

		if (Input.GetKeyDown(KeyCode.RightArrow))
		{
			transform.eulerAngles = new Vector3(0f, 0f, -90f);
			Vector3 position = this.transform.position;

			if (position.x < 4.0235f) {
				position.x = position.x + .6190f;
				this.transform.position = position;
				AudioSource.PlayClipAtPoint (hop, new Vector2(0,0));
			}

		}
		if (Input.GetKeyDown(KeyCode.UpArrow))
		{
			transform.eulerAngles = new Vector3(0f, 0f, 0f);
			Vector3 position = this.transform.position;

			if (position.y < 4.5f) {
				position.y = position.y + .6603f;
				this.transform.position = position;
				AudioSource.PlayClipAtPoint (hop, new Vector2(0,0));
			}

		}
		if (Input.GetKeyDown(KeyCode.DownArrow))
		{
			transform.eulerAngles = new Vector3(0f, 0f, 180f);
			Vector3 position = this.transform.position;

			if (position.y > -4.00f) {
				position.y = position.y - .6603f;
				this.transform.position = position;
				AudioSource.PlayClipAtPoint (hop, new Vector2(0,0));
			}



		}




	}
	void LateUpdate()
	{
		Vector3 position2 = this.transform.position;
		if (position2.x < 6.5f && position2.x > -6.5f && position2.y > 0.5f && position2.y < 5f) {
			riverKill ();
		}
	}


	void riverKill () {

		Vector3 position2 = this.transform.position;
		if (position2.x < 6.5f && position2.x > -6.5f && position2.y > 0.5f && position2.y < 5f) {
			if (transform.parent == null) {
				Invoke ("delayedKill", Time.deltaTime * 5);
				Debug.Log ("River Kill");

			}
		}
	}

	void delayedKill()
	{
		if (transform.parent == null) {
			Debug.Log ("Delayed Kill P2");
			Camera.main.gameObject.GetComponent<GameController> ().life2--;


			if (Camera.main.gameObject.GetComponent<GameController> ().life2 != 0) {
				GameObject newPlayer2 = Instantiate (frog2, new Vector3 (2.1665f, -4.01f, 0), Quaternion.Euler (0, 0, 0));

				AudioSource.PlayClipAtPoint (death, new Vector2 (0, 0));
				Destroy (gameObject);

				//Camera.main.gameObject.GetComponent<GameController> ().timeLeft = 60;
			} else {
				
				Debug.Log("should be invoking restart");
				Invoke ("Restart", 3f);
				Destroy (gameObject);
				AudioSource.PlayClipAtPoint (superDead, new Vector2 (0, 0));
				//GameObject newGameOver = Instantiate (gameOver);

			}
		}
	}

	private void Restart ()
	{
		Debug.Log ("actually restarting");
		SceneManager.LoadScene ("level1", LoadSceneMode.Single);
	}

}