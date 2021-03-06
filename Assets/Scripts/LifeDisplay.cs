using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeDisplay : MonoBehaviour {

	public SpriteRenderer sr;
	public Sprite two;
	public Sprite one;
	public Sprite zero;

	// Use this for initialization
	void Start () {
		StartCoroutine (checker ());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator checker (){
		while (true) {
			if (Camera.main.gameObject.GetComponent<GameController> ().life1 == 2) {
				sr.sprite = two;
			}
			if (Camera.main.gameObject.GetComponent<GameController> ().life1 == 1) {
				sr.sprite = one;
			}
			if (Camera.main.gameObject.GetComponent<GameController> ().life1 == 0) {
				sr.sprite = zero;
			}
			yield return new WaitForSeconds (.01f);
		}
	}
}
