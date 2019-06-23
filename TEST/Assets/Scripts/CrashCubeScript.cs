using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Данный скрипт удаляет квадрад спустя 2 секунды после появления квадрата
//А на его место устанавливает префаб из 4-х маленьких квадратов
public class CrashCubeScript : MonoBehaviour {

	public GameObject crashCubeObject;
	// Use this for initialization
	void Start () {
		StartCoroutine(Crash());
		
	}

	IEnumerator Crash()
	{
		yield return new WaitForSeconds(2.0f);
		GameObject obj = Instantiate(crashCubeObject, transform.position, transform.rotation) as GameObject;
		obj.transform.parent = GameObject.FindGameObjectWithTag("ParentForCrashCubes").transform;
		Destroy(gameObject);
	}
}
