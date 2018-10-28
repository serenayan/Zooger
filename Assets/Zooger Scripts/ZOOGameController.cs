using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ZOOGameController : MonoBehaviour {

	public GameObject Car1;
	public GameObject Car2;
	public GameObject Car3;
	public GameObject Car4;
	public GameObject Log1;
	public GameObject TurtleNormal;
	public GameObject LongLog1;
	public GameObject SmallTurtleNormal;
	public GameObject HugeLog;
    public GameObject TurtleDisappear;
	public GameObject frog1;
    public GameObject frog2;
	public GameObject RedWin;
	public GameObject GreenWin;
	public GameObject Tie;
    public int life1 = 3;
    public int life2 = 3;
    public int collectedRED = 0;
	public int collectedGREEN = 0;
    public float timeLeft;
	public GameObject gameOver;
	public AudioClip death;
	public AudioClip superDead;
	public AudioClip BGM;


	void Start () {
		//Starts spawning the cars
		StartCars ();
		AudioSource.PlayClipAtPoint (BGM, new Vector2(0,0));
	}

	IEnumerator  Timer()
	{
		while (true) {
			timeLeft--;
			Debug.Log (timeLeft);

				if (timeLeft == 0) 
                {
					AudioSource.PlayClipAtPoint (superDead, new Vector2(0,0));
					if (collectedGREEN > collectedRED) {
						GameObject newWin = Instantiate (GreenWin);
					}
					if (collectedRED > collectedGREEN) {
						GameObject newWin = Instantiate (RedWin);
					}
					if (collectedRED == collectedGREEN) {
						GameObject newWin = Instantiate (Tie);
					}
					Invoke ("MainMenu", 3);
					Debug.Log ("Loading Main Menu");
				}
			yield return new WaitForSeconds (1f);
		}
	} 

	void MainMenu() 
	{
			SceneManager.LoadScene ("mainMenu");
	}

    private void StartCars() {
		//use coroutines to spawn cars
		StartCoroutine (Car1Spawn ());
		StartCoroutine (Car2Spawn ());
		StartCoroutine (Car3Spawn ());
		StartCoroutine (Car4Spawn ());
		StartCoroutine (Log1Spawn ());
		StartCoroutine (HugeLogSpawn ());
		StartCoroutine (LongLogSpawn ());
		StartCoroutine (Timer ());
	}
		
	IEnumerator Car1Spawn() {
        while (true) {
			float f = Random.Range(2f, 4.5f);
			GameObject newCar1 = Instantiate (Car1);
			yield return new WaitForSeconds (f);
		}
	}

	IEnumerator Car2Spawn() {
        while (true) {
			float f = Random.Range(2f, 3f);
			GameObject newCar2 = Instantiate (Car2);
			yield return new WaitForSeconds (f);
		}
	}

	IEnumerator Car3Spawn() {
        while (true) {
			float f = Random.Range(2f, 3f);
			GameObject newCar3 = Instantiate (Car3);
			yield return new WaitForSeconds (f);
		}
	}

	IEnumerator Car4Spawn() {
        while (true) {
			float f = Random.Range(2f, 3f);
			GameObject newCar4 = Instantiate (Car4);
			yield return new WaitForSeconds (f);
		}
	}

	IEnumerator Log1Spawn() {
		
		while (true) {
			float f = Random.Range(1.5f, 4.5f);
			GameObject newCar5 = Instantiate (Log1);
			yield return new WaitForSeconds (f);
		}
	}

	IEnumerator LongLogSpawn() {

		while (true) {
			float f = Random.Range(2f, 5f);
			GameObject newLongLog = Instantiate (LongLog1);
			yield return new WaitForSeconds (f);
		}
	}
	IEnumerator HugeLogSpawn() {

		while (true) {
			float f = Random.Range(2f, 5f);
			GameObject newHugeLog = Instantiate (HugeLog);
			yield return new WaitForSeconds (f);
		}
	}
}
