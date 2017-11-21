using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RayView : MonoBehaviour {

    public float weaponrange = 50;
    public Image mira;
    public Camera mainCamera;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        Vector3 lineOrigin = mainCamera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));
        Debug.DrawLine(lineOrigin, mainCamera.transform.forward * weaponrange, Color.cyan);

        RaycastHit hit;

        if(Physics.Raycast(lineOrigin, mainCamera.transform.forward, out hit, weaponrange))
        {
           if(hit.collider.GetComponent<vidacontroller>())
           {
                mira.color = Color.red;
           }
           else
            {
                mira.color = Color.white;
            }
        }
	}
}
