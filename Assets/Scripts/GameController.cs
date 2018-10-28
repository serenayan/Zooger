using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	public GameObject Car1;
	public GameObject Car2;
	public GameObject Car3;
	public GameObject Car4;
	public GameObject Car5;
	public GameObject Log1;
	public GameObject TurtleNormal;
	public GameObject LongLog1;
	public GameObject SmallTurtleNormal;
	public GameObject HugeLog;
    public GameObject TurtleDisappear;
	public GameObject frog1;
    public GameObject frog2;
    public int life1 = 3;
    public int life2 = 3;
    public int collected = 0;
    public float timeLeft = 60f;
	public GameObject gameOver;
	public AudioClip death;
	public AudioClip superDead;
	public AudioClip BGM;

	void Start () {
		//Starts spawning the cars
		StartCars ();
		AudioSource.PlayClipAtPoint (BGM, new Vector2(0,0));
	}

	/*IEnumerator  Timer()
	{
		while (true) {
			timeLeft--;
			Debug.Log (timeLeft);
			if (timeLeft < 0) {
				GameObject[] gameObjects = GameObject.FindGameObjectsWithTag ("frog");
				Debug.Log (gameObjects.Length);
				GameObject.Destroy (gameObjects[0]);
                GameObject.Destroy(gameObjects[1]);
                gameObject.GetComponent<FrogController>().life1--;
                gameObject.GetComponent<Frog2Controller>().life2--;
                timeLeft = 60f;
                if (gameObject.GetComponent<FrogController>().life != 0 && gameObject.GetComponent<Frog2Controller>().life != 0)
                {
                    AudioSource.PlayClipAtPoint(death, new Vector2(0, 0));
                    GameObject newFrog1 = Instantiate(frog1);
                    GameObject newFrog2 = Instantiate(frog2);
                }
                else if (gameObject.GetComponent<FrogController>().life == 0) {
                    //AudioSource.PlayClipAtPoint (death, new Vector2(0,0));
                    //GameObject newFrog1 = Instantiate (frog1);
                    GameObject newGameOver = Instantiate(gameOver);
                    //make something that says frog2 wins
                }
                else if (gameObject.GetComponent<Frog2Controller>().life == 0)
                {
                    //AudioSource.PlayClipAtPoint(death, new Vector2(0, 0));
                    //GameObject newFrog2 = Instantiate(frog2);
                    GameObject newGameOver = Instantiate(gameOver);
                    //make something that says frog1 wins
                }
                else
                {
					AudioSource.PlayClipAtPoint (superDead, new Vector2(0,0));
					GameObject newGameOver = Instantiate(gameOver);
					Invoke ("Restart", 3);
				}

			}
			yield return new WaitForSeconds (1f);
		}
	} */

	void Restart() 
	{
		SceneManager.LoadScene ("level1", LoadSceneMode.Single);
	}

    private void StartCars() {
		//use coroutines to spawn cars
		StartCoroutine (Car1Spawn ());
		StartCoroutine (Car2Spawn ());
		StartCoroutine (Car3Spawn ());
		StartCoroutine (Car4Spawn ());
		StartCoroutine (Car5Spawn ());
		StartCoroutine (Log1Spawn ());
		StartCoroutine (HugeLogSpawn ());
		StartCoroutine (LongLogSpawn ());
		StartCoroutine (TurtleNormalSpawn ());
		StartCoroutine (TurtleSmallNormalSpawn ());
		//StartCoroutine (Timer ());
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

	IEnumerator Car5Spawn() {
        
        while (true) {
			float f = Random.Range(2f, 3.5f);
			GameObject newCar5 = Instantiate (Car5);
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
	IEnumerator TurtleNormalSpawn() {

		while (true) {
			GameObject newTurtleNormal = Instantiate (TurtleNormal);
			yield return new WaitForSeconds (2);
            GameObject newTurtleNormal2 = Instantiate(TurtleNormal);
            yield return new WaitForSeconds(2);
            GameObject newTurtleNormal3 = Instantiate(TurtleNormal);
            yield return new WaitForSeconds(2);
            GameObject newTurtleDisappear = Instantiate(TurtleDisappear);
            yield return new WaitForSeconds(2);
            
        }
	}


    IEnumerator TurtleSmallNormalSpawn() {

		while (true) {
			float f = Random.Range(2f, 4f);
			GameObject newSmallTurtleNormal = Instantiate (SmallTurtleNormal);
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
