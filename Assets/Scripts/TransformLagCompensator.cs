using UnityEngine;
using System.Collections;

public class TransformLagCompensator : Photon.MonoBehaviour {

	private Quaternion lastRotation=Quaternion.identity;
	private Quaternion realRotation=Quaternion.identity;

	private Vector3 lastPosition=Vector3.zero;
	private Vector3 realPosition=Vector3.zero;

	private double currentTimePosition = 0;
	private double currentPacketTimePosition=0;
	private double lastPacketTimePosition=0;

	private double currentTimeRotation = 0;
	private double currentPacketTimeRotation=0;
	private double lastPacketTimeRotation=0;

	public bool translate;
	public bool rotate;

	// Update is called once per frame
	void LateUpdate () {
		if (!photonView.isMine) {
			if (translate) {
				double speedPosition = currentPacketTimePosition - lastPacketTimePosition;
				currentTimePosition += Time.deltaTime;
				transform.position = Vector3.Lerp (lastPosition, realPosition, (float)(currentTimePosition / speedPosition));
			}

			if (rotate) {
				double speedRotation = currentPacketTimeRotation - lastPacketTimeRotation;
				currentTimeRotation += Time.deltaTime;
				transform.rotation = Quaternion.Lerp (lastRotation, realRotation, (float)(currentTimeRotation / speedRotation));
			}
		}
	}

	void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info){
		if (stream.isWriting) {
			if(translate)
				stream.SendNext (transform.position);
			if(rotate)
				stream.SendNext (transform.rotation);
		} else {
			if (translate) {
				lastPosition = transform.position;
				currentTimePosition = 0;
				realPosition = (Vector3)stream.ReceiveNext ();
				lastPacketTimePosition = currentPacketTimePosition;
				currentPacketTimePosition = info.timestamp;
			}

			if (rotate) {
				lastRotation = transform.rotation;
				currentTimeRotation = 0;
				realRotation = (Quaternion)stream.ReceiveNext ();
				lastPacketTimeRotation = currentPacketTimeRotation;
				currentPacketTimeRotation = info.timestamp;
			}
		}
	}
}