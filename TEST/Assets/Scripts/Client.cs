using System.Collections;
using UnityEngine;
using System.Net.Sockets;
using System.Net;

//Данный скрипт производит подключение к серверу
public class Client : MonoBehaviour {

	public string serverAddress = "192.168.0.1";
	public const int serverPort = 32111;
	public bool isConnected = false;

	private static Client singleton;
	private Socket sServer;


	// Use this for initialization
	void Awake () {
		sServer = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
		IPAddress remoteIPAddress = IPAddress.Parse(serverAddress);
		IPEndPoint remoteEndPoint = new IPEndPoint(remoteIPAddress, serverPort);
		singleton = this;
		sServer.Connect(remoteEndPoint);
	}
	
	// Update is called once per frame
	void Update () {
		if(isConnected != sServer.Connected)
			isConnected = sServer.Connected;
	}

	void OnApplicationQuit()
	{	
		sServer.Close();
		sServer = null;
	}


}
