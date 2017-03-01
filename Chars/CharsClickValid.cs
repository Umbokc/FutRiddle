using UnityEngine;
using System.Collections;

public class CharsClickValid : MonoBehaviour {

	public static bool check_char = false;

	void Update(){
		if(check_char){
			check_char = !check_char;
			Check_char();
		}
	}

	void Check_char (){

		int how_btn = 0;
		for(int ki = 0; ki < U.HOW_BUTTONS_DONE.Length; ki++) if(U.HOW_BUTTONS_DONE[ki]) how_btn++;

		// Debug.Log(how_btn);
		// если была введена последняя буква
		if (how_btn == U._LEVELS_ANSWER[U.current_level-1].Length){
			string answ = "";
			GameObject go; 
			for(int k = 0; k < U._FIELD_ANSWER_CHARS.transform.childCount; k++ ){
				go = U._FIELD_ANSWER_CHARS.transform.GetChild (k).gameObject;
				answ += go.GetComponentInChildren<TextMesh>().text.ToString().ToUpper();
			}

			// вызываем функциию в случае правильного ответа
			if(answ == U._LEVELS_ANSWER[U.current_level-1].ToString().ToUpper()){
				// Invoke("TrueAnswer", 2);
				TrueAnswer();
			}
		}

		// увеличаваем номер введенного символа 
		U.What_button_Enter++;
	}

	// введен правильный ответ  
	void TrueAnswer (){

		// обнуляем номер введенной буквы
		U.What_button_Enter = -1;
		// удаляем обьекты предыдущего уровня, если они есть
		for(int i = 0; i < U._ENTER_CHARS.transform.childCount; i++){
			Destroy(U._ENTER_CHARS.transform.GetChild (i).gameObject);
			// U._ENTER_CHARS.transform.GetChild (i).gameObject.GetComponent<ClickChar>().Destroy_the();
		}

		// выбубаем ребус
		U.TheLevel.SetActive (false);

		// переводи в начальный режим 
		U.GAME_STARTED = 0;
		
		// слудующий уровень 
		U.PP_Level = U.current_level+1;

		if(U.PP_Levels == ""){
			// добавляем пройдиный уровень
			U.opened_levels[0] = U.current_level;
		} else {
			// получаем открытые уровни
			U.opened_levels = U.StringToArr(U.PP_Levels,U.current_level);
		}
		// foreach(var a in U.opened_levels) Debug.Log("the "+a);

		// записываем значение в player prefs
		U.PP_Levels = U.ArrToStringUniq(U.opened_levels);

		U.Answer.SetActive (true);
	}

}
