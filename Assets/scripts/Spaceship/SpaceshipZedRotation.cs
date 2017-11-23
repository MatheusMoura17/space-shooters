using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipZedRotation : Photon.MonoBehaviour {

	// PS: Não há qualquer tutorial decente na internet sobre movimentação de aviões.
	// PS2: Tomara que eu nunca mais pegue controles de naves 3D.

	public bool isLocal = true;

	public float timeLimit = 0.4f;		// A nave só pode girar no eixo z por no máximo 0.4 segundos
	float rotationTimeLeft = 0.0f;		// Quanto tempo a nave está girando para a esquera
	float rotationTimeRight = 0.0f;		// Quanto tempo a nave está girando para a direita
	bool releasedLeft = false;			// Se true, o jogador soltou o botão de seta para a esquerda
	bool releasedRight = false;			// Se true, o jogador soltou o botão de seta para a direita

	public float rotationAmount = 105.0f;		// Velocidade de rotação no eixo z

	void Start(){
		isLocal = photonView.isMine;
	}

	void LateUpdate()
	{
		if (isLocal) {					// Matheus pediu pra colocar isso
			
			if (Input.GetKey ("left")) {

				if (rotationTimeLeft < timeLimit && releasedRight == false) {		
					releasedLeft = false;											// O jogador só irá rotacionar para a
					transform.Rotate (0, 0, rotationAmount * Time.deltaTime);		// esquerda se ele não acabou de soltar
					rotationTimeLeft += (1 - rotationTimeRight) * Time.deltaTime;	// o botão de seta pra direita. É
																					// necessário para corrigir um bug
					if (rotationTimeLeft > timeLimit) {
						rotationTimeLeft = timeLimit;
					}

				}

			}

			if (Input.GetKey ("right")) {

				if (rotationTimeRight < timeLimit && releasedLeft == false) {		
					releasedRight = false;											// O jogador só irá rotacionar para a
					transform.Rotate (0, 0, -rotationAmount * Time.deltaTime);		// direita se ele não acabou de soltar
					rotationTimeRight += (1 - rotationTimeLeft) * Time.deltaTime;	// o botão de seta pra esquerda. É
																					// necessário para corrigir um bug
					if (rotationTimeRight > timeLimit) {
						rotationTimeRight = timeLimit;
					}
				}

			}


			if (Input.GetKeyUp ("left")) {		// GetKeyUp só ocorre no frame em que a tecla é solta.
				releasedLeft = true;			// No nosso caso, precisamos de um retorno contínuo, e
			}									// as variáveis releasedLeft e releasedRight dão conta

			if (Input.GetKeyUp ("right")) {
				releasedRight = true;
			}
			//

			if (releasedLeft) {

				if (rotationTimeLeft > 0) {											// Ao soltar o botão de seta para a
					transform.Rotate (0, 0, -rotationAmount * Time.deltaTime);		// esquerda, a nave irá desfazer sua
					rotationTimeLeft -= 1 * Time.deltaTime;							// rotação durante um certo tempo, que é
				}																	// definido pela variável rotationTimeLeft

				if (rotationTimeLeft <= 0) {
					rotationTimeLeft = 0;
					releasedLeft = false;
				}

			}

			if (releasedRight) {

				if (rotationTimeRight > 0) {										// Ao soltar o botão de seta para a
					transform.Rotate (0, 0, rotationAmount * Time.deltaTime);		// direita, a nave irá desfazer sua
					rotationTimeRight -= 1 * Time.deltaTime;						// rotação durante um certo tempo, que é
				}																	// definido pela variável rotationTimeRight

				if (rotationTimeRight <= 0) {
					rotationTimeRight = 0;
					releasedRight = false;
				}

			}

			// Debug.Log (rotationTimeLeft + " - " + rotationTimeRight);			// Confirmando o tempo de rotação restante

		}
	}
}
