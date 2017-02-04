using UnityEngine;
using System.Collections;

public class ClickChar : ClickButton {

	public bool destroyed = false;

	public float the_y;

	void Start(){
		the_y = transform.position.y;
	}

	void OnMouseUpAsButton (){
			TheClick();
	}

	public void TheClick(){
		// если нажатых букв было меньше чет длина ответа то true
		if (U.What_button_Enter < U._LEVELS_ANSWER[U.current_level-1].Length){
			
						
			if(U.HOW_BUTTONS_DONE[U.What_button_Enter]){

				for(int ki = 0; ki < U.HOW_BUTTONS_DONE.Length; ki++)
					if(U.HOW_BUTTONS_DONE[ki]){
						continue;
					} else {
						U.What_button_Enter = ki;
						break;
					}
			}

			// получем символ нажатой буквы
			TextMesh chr = GetComponentInChildren<TextMesh>();
			// добаляем символ в поле для ответа
			U._FIELD_ANSWER_CHARS.transform.GetChild (U.What_button_Enter).gameObject.GetComponentInChildren<TextMesh>().text = chr.text;

			Debug.Log(U.HOW_BUTTONS_DONE[U.What_button_Enter] + ": " + U.What_button_Enter);

			// буква есть
			U.HOW_BUTTONS_DONE[U.What_button_Enter] = true;


			// вызываем проверку символов
			CharsClickValid.check_char = true;

			Destroy_the();
		}
	}

	public void Destroy_the(bool thebool = true){
		
		GetComponent<Rigidbody2D> ().isKinematic = !thebool;
		GetComponent<BoxCollider2D> ().enabled = !thebool;

		float z = 0.2f;
		z *= thebool ? 1 : -1;

		Vector3 t = transform.position;
		t.z -= z;
		transform.position = t;

		destroyed = thebool;

	}
}
