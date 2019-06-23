using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Данный скрипт обрабатывает нажатие по квадрату
public class ClickOnCubes : MonoBehaviour {

	public GameObject icon;
	public int speed = 1;
	void OnMouseDown()
	{
		ScoreScript.Score += 10*speed;
		print("Press");
		Instantiate(icon, gameObject.transform.position, Quaternion.identity);
		Destroy(gameObject);
	}
	
}
