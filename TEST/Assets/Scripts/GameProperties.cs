using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Данный скрипт является основным
//В нем реализована основная механика и меню игры

public class GameProperties : MonoBehaviour {

	public Text timer;	//Элемент таймера
	public Text score;	//Элемент текущего количества очков
	public Text lastScore;	//Элемент финального количества очков
	public GameObject menuPanel;	// Панель меню

	public GameObject[] listObject = new GameObject[2]; //Массив игровых плиток

	private bool gameState;	//Состояние игры
	private float gameTimer;	//переменная таймера

	private int percentCube = 50;	//вероятность появления одной из двух плиток

	private float timeCreate;	//таймер отсчета перед созданием след плитки

	// Use this for initialization
	void Start () 
	{
		gameState = false;
		timeCreate = 0;

		//Запускаем анимацию всплывающего меню
		if(!menuPanel.GetComponent<Animator>().enabled)
		{
			menuPanel.GetComponent<Animator>().enabled = true;
		}else
		{
			menuPanel.GetComponent<Animator>().SetTrigger("PanelUp");
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(gameState)
		{
			int intTimer;
			gameTimer -= Time.deltaTime;
			intTimer = (int)gameTimer;

			timer.text = "Time left: "+ intTimer.ToString();
			CreateObject();

			if(gameTimer < 0)
			{
				gameState = false;
				timer.enabled = false;
				score.enabled = false;
				menuPanel.GetComponent<Animator>().SetTrigger("PanelUp");
				lastScore.text = "Last score: " + ScoreScript.Score.ToString();
				
				Transform allChildren = GameObject.FindGameObjectWithTag("ParentForCubes").transform;
				foreach(Transform child in allChildren)
				{
					print(child.gameObject);
					Destroy(child.gameObject);
				}	

				allChildren = GameObject.FindGameObjectWithTag("ParentForCrashCubes").transform;
				foreach(Transform child in allChildren)
				{
					Destroy(child.gameObject);
				}	
			}
		}
		
	}

	void PressStartButton()
	{
		if(!menuPanel.GetComponent<Animator>().enabled)
		{
			menuPanel.GetComponent<Animator>().enabled = true;
		}else
		{
			menuPanel.GetComponent<Animator>().SetTrigger("PanelDown");
		}
		StartCoroutine(StartGame());
		print("Press Start game");
	}

	void PressExitButton()
	{
		print("Press Exit game");
		Application.Quit();
	}

	IEnumerator StartGame()
	{
		yield return new WaitForSeconds(1.5f);
		timer.enabled = true;
		score.enabled = true;
		gameTimer = 60.0f;
		ScoreScript.Score = 0;
		gameState = true;
		yield break;
	}

	void CreateObject()
	{
		int typeCube = Random.Range(0, 100);
		if(typeCube > percentCube)
		{
			typeCube = 0;
			if(percentCube <= 95)
				percentCube += 5;
		}else
		{
			typeCube = 1;
			if(percentCube >= 5)
				percentCube -= 5;
		}
		timeCreate += Time.deltaTime;
		if(timeCreate > 0.5)
		{
			GameObject cube = Instantiate(listObject[typeCube], new Vector3(Random.Range(-5.0f, 5.0f), Random.Range(-8.0f, 6.0f), 0), Quaternion.identity) as GameObject;
			cube.transform.parent =  GameObject.FindGameObjectWithTag("ParentForCubes").transform;
			timeCreate = 0;
		}
	}
}
