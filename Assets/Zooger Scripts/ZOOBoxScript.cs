using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ZOOBoxScript : MonoBehaviour {

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

		GameObject player1 = GameObject.FindGameObjectWithTag ("frog");
		GameObject player2 = GameObject.FindGameObjectWithTag ("frog2");

		if (other.gameObject == player1){
			if (sr.sprite != redCapture) {

				if (sr.sprite == greenCapture) {
					Camera.main.gameObject.GetComponent<ZOOGameController> ().collectedGREEN--;
				}

				sr.sprite = redCapture;
				Destroy (other.gameObject);
				//gameObject.GetComponent<BoxCollider2D>().enabled = false;
				Camera.main.gameObject.GetComponent<ZOOGameController> ().collectedRED++;

				if (Camera.main.gameObject.GetComponent<ZOOGameController> ().collectedRED == 3) {
					AudioSource.PlayClipAtPoint (chickenDinner, new Vector2 (0, 0));
					GameObject newWin = Instantiate (RedWin);
					Invoke ("LoadMain", 3f);
				} else {
					GameObject newFrog = Instantiate (frog1);

				}
			}
		}
		if (sr.sprite != greenCapture) {

			if (sr.sprite == redCapture) {
				Camera.main.gameObject.GetComponent<ZOOGameController> ().collectedRED--;
			}

			if (other.gameObject == player2) {
				sr.sprite = greenCapture;
				Destroy (other.gameObject);
				//gameObject.GetComponent<BoxCollider2D>().enabled = false;
				Camera.main.gameObject.GetComponent<ZOOGameController> ().collectedGREEN++;

				if (Camera.main.gameObject.GetComponent<ZOOGameController> ().collectedGREEN == 3) {
					AudioSource.PlayClipAtPoint (chickenDinner, new Vector2 (0, 0));
					GameObject newWin = Instantiate (GreenWin);
					Invoke ("LoadMain", 3f);
				} else {
					GameObject newFrog = Instantiate (frog2);

				}
			}
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

	public void LoadMain()
	{
		SceneManager.LoadScene ("mainMenu");
	}
}
