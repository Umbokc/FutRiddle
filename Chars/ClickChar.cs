using UnityEngine;
using System.Collections;

public class ClickChar : MonoBehaviour {

	void OnMouseDown(){
		transform.localScale += new Vector3(0.05f,0.05f,0);
	}

	void OnMouseUp(){
		transform.localScale -= new Vector3(0.05f,0.05f,0);
	}

	void OnMouseUpAsButton (){
		// если нажатых букв было меньше чет длина ответа то true
		if (U.What_button_Enter < U._LEVELS_ANSWER[U.current_level-1].Length){
			// получем символ нажатой буквы
			TextMesh chr = gameObject.GetComponentInChildren<TextMesh>();
			// добаляем символ в поле для ответа
			U._FIELD_ANSWER_CHARS[U.What_button_Enter].gameObject.GetComponentInChildren<TextMesh>().text = chr.text;
			// вызываем проверку символов 
			CharsClickValid.Check_char();
			// увеличаваем номер введенного символа 
			U.What_button_Enter++;
			// удаляем букву 
			Destroy(gameObject);
		}
	}
}
