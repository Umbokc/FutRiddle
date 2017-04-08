using UnityEngine;
using System.Collections;

public class Click_add : MonoBehaviour {

	void OnMouseDown(){
		transform.localScale += new Vector3(0.05f,0.05f,0);
	}

	void OnMouseUp(){
		transform.localScale -= new Vector3(0.05f,0.05f,0);
	}

	void OnMouseUpAsButton (){
		if(U.PP_Money >= 100){
			Camera.main.GetComponent<AudioSource> ().Play ();
			Add();
		}
	}

	void Edid_field(){

		bool ok = false;
		// получаем колличество символов ответа
		int len_word = U._LEVELS_ANSWER[U.Global_Level-1,U.current_level-1].Length;

		for(int k = 0; k < U._FIELD_ANSWER_CHARS.transform.GetChild (len_word-3).gameObject.transform.childCount; k++ ){
			if(U._FIELD_ANSWER_CHARS.transform.GetChild (len_word-3).gameObject.transform.GetChild (k).gameObject.GetComponentInChildren<TextMesh>().text == ""){
				U.What_button_Enter = k;
				break;
			}
		}

		// беру следующую букву
		string chr = U._LEVELS_ANSWER[U.Global_Level-1,U.current_level-1][U.What_button_Enter].ToString().ToUpper();
		
		GameObject go;

		// ищю букву и имитируем нажатие
		for(int i = 0; i < U._ENTER_CHARS.transform.childCount; i++ ){

			go = U._ENTER_CHARS.transform.GetChild (i).gameObject;

			if(go.GetComponentInChildren<TextMesh>().text.ToString().ToUpper() == chr && !go.GetComponent<ClickChar>().destroyed){
				go.GetComponent<ClickChar>().TheClick();
				// отнимаю 100 монет
				U.PP_Money -= 15;
				ok = true;
				break;
			}
		}

		if (!ok) {
			for(int i = 0; i < U._FIELD_ANSWER_CHARS.transform.GetChild (len_word-3).gameObject.transform.childCount; i++ ){
				go = U._FIELD_ANSWER_CHARS.transform.GetChild (len_word-3).gameObject.transform.GetChild (i).gameObject;

				if (go.GetComponentInChildren<TextMesh>().text == chr && !Check_char_pos_in_field(go.GetComponentInChildren<TextMesh>().text, i)) {
					go.GetComponent<ClickField>().Retry_chr();
					Edid_field();
				}
			}
		}
	}

	void Edid_field2(int WbE){
		// получаем колличество символов ответа
		int len_word = U._LEVELS_ANSWER[U.Global_Level-1,U.current_level-1].Length;

		GameObject go, go2;
		go2 = U._FIELD_ANSWER_CHARS.transform.GetChild (len_word-3).gameObject.transform.GetChild (WbE).gameObject;
		go2.GetComponent<ClickField>().Retry_chr();

		Edid_field();
	}

	void Add(){
		// получаем колличество символов ответа
		int len_word = U._LEVELS_ANSWER[U.Global_Level-1,U.current_level-1].Length;

		// проходим по всем полям
		for(int k = 0; k < U._FIELD_ANSWER_CHARS.transform.GetChild (len_word-3).gameObject.transform.childCount; k++ ){
			// берем букву из поля
			string s = U._FIELD_ANSWER_CHARS.transform.GetChild (len_word-3).gameObject.transform.GetChild (k).gameObject.GetComponentInChildren<TextMesh>().text;
			// если есть буква, то идем дальше
			if(s != ""){
				// если найдена ошибка, останавливаем цикл
				if(s != U._LEVELS_ANSWER[U.Global_Level-1,U.current_level-1][k].ToString().ToUpper()){
					Edid_field2(k);
					break;
				}
			} else {
				Edid_field();
				break;
			}
		}
	}
	
	bool Check_char_pos_in_field(string s, int p) {
		return s == U._LEVELS_ANSWER[U.Global_Level-1,U.current_level-1][p].ToString().ToUpper();
	}

}
