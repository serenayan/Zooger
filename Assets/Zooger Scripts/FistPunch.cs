using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FistPunch : MonoBehaviour
{

	public GameObject Player2;
    // Use this for initialization
    void Start()
	{
        StartCoroutine(SelfD());
    }
    IEnumerator SelfD()
    {
        yield return new WaitForSeconds(0.1f);
        Destroy(gameObject);
    }
    void OnTriggerEnter2D(Collider2D other)
    {

        if(other.gameObject.tag == "frog2")
        {
            Debug.Log("hit you");
            Destroy(other.gameObject);
			GameObject newPlayer2 = Instantiate (Player2);
        }

    }

}