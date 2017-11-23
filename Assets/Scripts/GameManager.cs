using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public string playerPrefab;
	public FollowTarget followTarget;

	// Use this for initialization
	void Start () {
		MusicManager.instance.PlayMusic (MusicManager.MusicNames.GAME);
		GameObject gm = PhotonNetwork.Instantiate (playerPrefab,Vector3.zero,Quaternion.identity,0);
		//gm.GetComponent<SpaceshipMovement>().set
		followTarget.target = gm.transform;
	}
}
