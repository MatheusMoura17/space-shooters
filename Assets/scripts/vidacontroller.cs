using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vidacontroller : MonoBehaviour {

    public int currentHeath = 100;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Damage(int damageAnnount)
    {
        currentHeath -= damageAnnount;

        if(currentHeath <= 0)
        {
            Destroy(gameObject);
        }
    }
}
