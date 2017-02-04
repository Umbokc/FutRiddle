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
		// проверяем совпадает ли введеный символ с сомволом из ответа если совпали предыдущие

		if (U._FIELD_ANSWER_CHARS.transform.GetChild (U.What_button_Enter).gameObject.GetComponentInChildren<TextMesh>().text.ToString().ToUpper() == U._LEVELS_ANSWER[U.current_level-1][U.What_button_Enter].ToString().ToUpper()){
			// если была введена последняя буква
			if ((U.What_button_Enter+1) == U._LEVELS_ANSWER[U.current_level-1].Length){
				// вызываем функциию в случае правильного ответа
				string answ = "";
				GameObject go; 
				for(int k = 0; k < U._FIELD_ANSWER_CHARS.transform.childCount; k++ ){
					go = U._FIELD_ANSWER_CHARS.transform.GetChild (k).gameObject;
					answ += go.GetComponentInChildren<TextMesh>().text.ToString().ToUpper();
				}

				if(answ == U._LEVELS_ANSWER[U.current_level-1].ToString().ToUpper()){
					// Invoke("TrueAnswer", 2);
					TrueAnswer();
				}
			}
		} else {
			Debug.Log("to fuck");
			// если ведена последняя буква и отвт не верен то перезагружаем сцену 
			if ((U.What_button_Enter+1) == U._LEVELS_ANSWER[U.current_level-1].Length){
				Debug.Log("fuck");
				// U.LoadScene ("_main");
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
