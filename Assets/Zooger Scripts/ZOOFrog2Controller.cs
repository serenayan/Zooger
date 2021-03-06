using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ZOOFrog2Controller : MonoBehaviour {

	public Rigidbody2D rb;
	public AudioClip hop;
	public GameObject gameOver;
	public AudioClip death;
	public AudioClip superDead;
	public LayerMask vehicleMask;
	public GameObject frog2;
	public GameObject fist2;

	public GameObject kangaroo2;

	public SpriteRenderer sr;
	public Sprite punchMode;
	public Sprite normal;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		sr = GetComponent<SpriteRenderer>();
	}

	// Update is called once per frame
	void Update()
	{

		GameObject[] deadFrogs = GameObject.FindGameObjectsWithTag ("frog");
		for (int i = 0; i < deadFrogs.Length; i++) {
			if (deadFrogs [i].GetComponent<BoxCollider2D> ().enabled == false)
				Destroy (deadFrogs [i]);
		}

		if (Input.GetKeyDown(KeyCode.LeftArrow))
		{
			transform.eulerAngles = new Vector3(0f, 0f, 90f);
			Vector3 position = this.transform.position;

			if (position.x > -4.0235f)
			{
				position.x = position.x - .6190f;
				this.transform.position = position;
				AudioSource.PlayClipAtPoint(hop, new Vector2(0, 0));
			}

		}

		if (Input.GetKeyDown(KeyCode.RightArrow))
		{
			transform.eulerAngles = new Vector3(0f, 0f, -90f);
			Vector3 position = this.transform.position;

			if (position.x < 4.0235f)
			{
				position.x = position.x + .6190f;
				this.transform.position = position;
				AudioSource.PlayClipAtPoint(hop, new Vector2(0, 0));
			}

		}
		if (Input.GetKeyDown(KeyCode.UpArrow))
		{
			transform.eulerAngles = new Vector3(0f, 0f, 0f);
			Vector3 position = this.transform.position;

			if (position.y < 4.5f)
			{
				position.y = position.y + .63f;
				this.transform.position = position;
				AudioSource.PlayClipAtPoint(hop, new Vector2(0, 0));
			}

		}
		if (Input.GetKeyDown(KeyCode.DownArrow))
		{
			transform.eulerAngles = new Vector3(0f, 0f, 180f);
			Vector3 position = this.transform.position;

			if (position.y > -4.00f)
			{
				position.y = position.y - .63f;
				this.transform.position = position;
				AudioSource.PlayClipAtPoint(hop, new Vector2(0, 0));
			}



		}
		if (Input.GetKeyDown(KeyCode.L))
		{
			sr.sprite = punchMode;
			Invoke("back", 0.1f);
			//Debug.Log(transform.rotation.z);
			if (transform.rotation.z < -0.70 && transform.rotation.z > -0.71)
			{
				//Debug.Log("facing right");
				Instantiate(fist2, transform.position + new Vector3(0.48f, 0f, 0f), Quaternion.Euler(0f, 0f, -90f));
			}
			if (transform.rotation.z > 0.70 && transform.rotation.z < 0.71)
			{
				Instantiate(fist2, transform.position + new Vector3(-.48f, 0f, 0f), Quaternion.Euler(0f, 0f, 90f));
			}
			if (transform.rotation.z == 0)
			{
				//Debug.Log("facing up");
				Instantiate(fist2, transform.position + new Vector3(0f, 0.48f, 0f), new Quaternion(0f, 0f, 0f, 0f));
			}
			if (transform.rotation.z == -1)
			{
				//Debug.Log("down");
				Instantiate(fist2, transform.position + new Vector3(0f, -0.48f, 0f), new Quaternion(0f, 0f, -1f, 0f));
			}
		}
	}

	void back()
	{
		sr.sprite = normal;
	}
	void LateUpdate()
	{
		Vector3 position2 = this.transform.position;
		if (position2.x < 6.5f && position2.x > -6.5f && position2.y > 1.4f && position2.y < 4.4f) {
			riverKill ();
		}
	}


	void riverKill () {

		Vector3 position2 = this.transform.position;
		if (position2.x < 6.5f && position2.x > -6.5f && position2.y > 1.4f && position2.y < 4.4f) {
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

			AudioSource.PlayClipAtPoint (death, new Vector2 (0, 0));
			kangaroo2 = GameObject.FindGameObjectWithTag ("frog2");

			GameObject newPlayer1 = Instantiate (frog2, new Vector3 (2.1665f, -4.07f, 0), Quaternion.Euler (0,0,0));
			Destroy (kangaroo2);
		}
	}

}