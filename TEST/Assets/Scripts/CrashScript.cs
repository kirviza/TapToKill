using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Данный скрипт раскидывает квадраты и спустя время удаляет их
public class CrashScript : MonoBehaviour {

	// Use this for initialization

	Rigidbody2D[] bodies;

	void Start () {
		bodies = GetComponentsInChildren<Rigidbody2D>();
        foreach(Rigidbody2D body in bodies) 
		{
			body.AddForce(new Vector2(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f)) * Random.Range(10.0f, 20.0f), ForceMode2D.Impulse);
		}

		StartCoroutine(CrashObject());

	}
	
	// Update is called once per frame
	IEnumerator CrashObject () {
		yield return new WaitForSeconds(1);
		Destroy(gameObject);
	}
}
