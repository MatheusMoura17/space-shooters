using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon;
using UnityEngine.UI;

public class Network : Photon.PunBehaviour {

	public static Network instance;
	public GameObject panel;
	public Text message;
	public string version = "0.1";

	private bool connected;
	public bool Connected {
		get {
			return connected;
		}
	}

	void Awake(){
		instance = this;
		panel.SetActive (false);
		connected = false;
	}
	
	public void Connect(){
		ShowMessage ("Conectando ao photon...");
		PhotonNetwork.autoJoinLobby = true;
		PhotonNetwork.ConnectUsingSettings (version);
	}

	private void ShowMessage(string text){
		message.text = text;
		panel.SetActive (true);
	}

	private void HideMessage(){
		panel.SetActive(false);
	}

	public override void OnConnectedToPhoton ()
	{
		ShowMessage ("Conectando ao Master Server...");
	}

	public override void OnConnectedToMaster ()
	{
		ShowMessage ("Conectando ao Lobby...");
	}

	public override void OnJoinedLobby ()
	{
		ShowMessage ("Conectando à sala...");
		RoomOptions room = new RoomOptions ();
		room.MaxPlayers = 20;
		PhotonNetwork.JoinOrCreateRoom("room",room,TypedLobby.Default);
	}

	public override void OnCreatedRoom ()
	{
		HideMessage ();
		connected = true;
	}

	public override void OnJoinedRoom ()
	{
		HideMessage ();
		connected = true;
	}

}
