using UnityEngine;
using System.Collections;

public class firecontroller : MonoBehaviour
{
    public GameObject shot1;
    public Transform shotSpawn1;
    public GameObject shot2;
    public Transform shotSpawn2;
    public float fireRate;

    private float nextFire;

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot1, shotSpawn1.position, shotSpawn2.rotation);
            Instantiate(shot2, shotSpawn1.position, shotSpawn2.rotation);
        }
    }
}