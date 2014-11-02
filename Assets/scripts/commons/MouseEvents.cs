using UnityEngine;
using System.Collections;
namespace Assets.Scripts.Commons
{
	public class MouseEvents : MonoBehaviour {
		public float distance = 2f;
		public string GetMousePosition(Vector3 mousePosition){
			var pos = Camera.main.ScreenToWorldPoint(mousePosition);
			var stat  = transform.position;

			string posx = "";
			string posy = "";
			string direcao = "";
			float horizontal = stat.x - pos[0];
			float vertical = stat.y - pos[1];
			if((vertical> -distance && vertical< distance) && (horizontal> -distance && horizontal< distance)){
				posx = (horizontal > 0)? "esquerda":"direita";
				posy = (vertical < 0)? "cima":"baixo";
				horizontal = (horizontal > 0)? horizontal : -horizontal;
				vertical = (vertical > 0)? vertical : -vertical;
				direcao = (horizontal < vertical)?posy:posx;
				return direcao;
			}else {
				return "longe";
			}
		}

	}
}
