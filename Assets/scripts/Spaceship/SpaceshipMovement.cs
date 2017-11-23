using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipMovement : MonoBehaviour {

	public bool isLocal = true;

	public float acceleration = 0.8f;		// Aumente este número para a nave chegar mais rápido na vel. máxima
	public float maxSpeed = 2.0f;			// Aumente este número para a nave ter uma velociade maior
	public float power = 0.0f;				// Tente não mudar isso aqui

	float amountRotation = 2.0f;			// Incremento da rotação da nave
	float verticalSpeed = 0.0f;				// Velocidade de rotação vertical da nave
	float horizontalSpeed = 0.0f;			// Velocidade de rotação horizontal da nave
	float vertRotationLimit = 1.5f;			// Limite da velocidade de rotação vertical da nave
	float horRotationLimit = 1.0f;			// Limite de velocidade de rotação horizontal da nave
	float restoreAnglesDamping=20;

	public static Transform transformSpaceship;

	void Start () {
		transformSpaceship = transform;
	}

	void LateUpdate () {

		if (isLocal) {		// Matheus pediu pra colocar

			// Aceleração e desaceleração da nave
			if (Input.GetKey ("w")) {		// Ao segurar espaço, a velocidade atual (power) irá aumentar gradativamente

				if (power < maxSpeed) {
					power += Time.deltaTime * acceleration;
				} else {
					power = maxSpeed;
				}

				transform.Translate (0, 0, power);

			} else {							// Ao não segurar espaço, a nave irá desacelerar
		
				if (power > 0.0f) {				
					power -= Time.deltaTime * acceleration;
					transform.Translate (0, 0, power);

				} else {				
					power = 0.0f;			
				}
			}


			// Altitude
			// Subindo
			if (Input.GetKey ("down")) {

				if (verticalSpeed > -vertRotationLimit) {
					verticalSpeed -= amountRotation * Time.deltaTime;
				} else {
					verticalSpeed = -vertRotationLimit;
				}
			}


			// Descendo
			if (Input.GetKey ("up")) {

				if (verticalSpeed < vertRotationLimit) {
					verticalSpeed += amountRotation * Time.deltaTime;
				} else {
					verticalSpeed = vertRotationLimit;
				}
			}


			// Resetando a velocidade de rotação vertical
			if (Input.GetKeyUp ("up") || Input.GetKeyUp ("down")) {
				verticalSpeed = 0;
			}


			// Esquerda
			if (Input.GetKey ("left")) {

				if (horizontalSpeed > -horRotationLimit){
					horizontalSpeed -= amountRotation * Time.deltaTime;
				} else {
					horizontalSpeed = -horRotationLimit;
				}
			}


			// Direita
			if (Input.GetKey ("right")) {

				if (horizontalSpeed < horRotationLimit){
					horizontalSpeed += amountRotation * Time.deltaTime;
				} else {
					horizontalSpeed = horRotationLimit;
				}
			}

			// Resetando a velocidade de rotação horizontal
			if (Input.GetKeyUp ("left") || Input.GetKeyUp ("right")) {
				horizontalSpeed = 0;
			}

			transform.Rotate (verticalSpeed, horizontalSpeed, 0);

		}
	}

}