using UnityEngine;
using System.Collections;

public class FireAssistent : Photon.MonoBehaviour
{

	public GameObject firePrefab;
    public int fireDamage = 5;
    public float fireRate = .25f;
	private float nextFire;

    public Transform spawnfire1;
	public Transform spawnfire2;

	private Sound sound;

    void Start() {
		sound = GetComponent<Sound> ();
    }

    void Update()
    {
		if(Input.GetKey(KeyCode.Space) && Time.time > nextFire && photonView.isMine)
        {
            nextFire = Time.time + fireRate;
			photonView.RPC ("Shoot", PhotonTargets.AllBufferedViaServer);
        }
    }

	[PunRPC]
	public void Shoot(){
		sound.MakePlayerShotSound ();
		Instantiate (firePrefab, spawnfire1.position, spawnfire1.rotation);
		Instantiate (firePrefab, spawnfire2.position, spawnfire2.rotation);
	}
}