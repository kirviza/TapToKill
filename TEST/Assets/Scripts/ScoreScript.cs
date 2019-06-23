using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Данный скрипт показывает количество набранных очков
public class ScoreScript : MonoBehaviour {

	public static int Score;

	// Use this for initialization
	void Start () {
		Score = 0;
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<Text>().text = "Score: " + Score.ToString();
		
	}
}
