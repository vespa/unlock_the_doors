using UnityEngine;
using System.Collections;
using Assets.Scripts.Commons;

public class CharacterMovement : MouseEvents {
	private bool activeMovement = false;

	private Vector2 start;
	private Vector2 end;
	public float spacesWalkedPerTime = 1f;
	private string direcao = "longe";

	public void DeactiveMovement(){
		activeMovement = false;
		var pos = transform.position;
		pos.x = Mathf.Round(pos.x);
		pos.y = Mathf.Round(pos.y);
		transform.position= pos;
	}
	public void ActiveMovement(){
		activeMovement = true;
		Invoke ("DeactiveMovement", 1);
	}
	public void Movement(){
		end.x = 0f;
		end.y = 0f;

		if(direcao != "longe"){
			if(direcao == "baixo")
				end.y = -1f;

			if(direcao == "cima")
				end.y = 1f;

			if(direcao == "esquerda")
				end.x = -1f;

			if(direcao == "direita")
				end.x = 1f;

			var mov = Vector2.Lerp(start, end, Time.deltaTime * spacesWalkedPerTime);
			transform.Translate(mov);
		}
	}
	void Update () {
		if (Input.GetMouseButtonDown(0) && !activeMovement) {
			Vector3 pos = Input.mousePosition;
			direcao = GetMousePosition(pos);
			ActiveMovement();
		}
		if(activeMovement)
			Movement();
	}
}
