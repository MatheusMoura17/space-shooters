using UnityEngine;
using System.Collections;

public class firecontroller : MonoBehaviour
{
    public float fireDamage = 5;
    public float fireRate = .25f;
    public float weapoRange = 50;
    public float hitForce = 10;

    public Transform spawnfire1;
    public Transform spawnfire2;

    private WaitForSeconds durationFire = new WaitForSeconds(5f);
    private AudioSource fireAudio;
    private LineRenderer laserLine;
    private float nextFire;
    private Camera naveCamera;

    void Start() {

        laserLine = GetComponent<LineRenderer>();
        fireAudio = GetComponent<AudioSource>();
    }

    void Update()
    {
        if(Input.GetButtonDown("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            StartCoroutine(FireEffects());

            Vector3 rayOrigin = naveCamera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));
            RaycastHit hit;
            laserLine.SetPosition(0, spawnfire1.position);
            laserLine.SetPosition(0, spawnfire2.position);

            if(Physics.Raycast(rayOrigin, naveCamera.transform.forward, out hit, weapoRange))
            {
                laserLine.SetPosition(1, hit.point);
            }
            else
            {
                laserLine.SetPosition(1, rayOrigin + (naveCamera.transform.forward * weapoRange));
            }
        }
    }

    private IEnumerator FireEffects()
    {
        fireAudio.Play();
        laserLine.enabled = true;
        yield return durationFire;
        laserLine.enabled = false;
    }
}