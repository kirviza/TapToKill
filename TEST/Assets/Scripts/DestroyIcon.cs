using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Данный скрипт удаляет всплывающие иконки при правильном и не правильном нажатие
public class DestroyIcon : MonoBehaviour {

	float speed = 7.0f;

	// Use this for initialization
	void Start () {
		StartCoroutine(CrashObj());
		
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.transform.Translate(new Vector3(0, 1*Time.deltaTime * speed, 0));
	}

	IEnumerator CrashObj()
	{
		yield return new WaitForSeconds(0.7f);
		Destroy(gameObject);
	}
}
