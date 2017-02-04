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
		if (U._FIELD_ANSWER_CHARS[U.What_button_Enter].gameObject.GetComponentInChildren<TextMesh>().text == U._LEVELS_ANSWER[U.current_level-1][U.What_button_Enter].ToString().ToUpper() && U.WHILE_TRUE_ANSWER){
			// если была введена последняя буква
			if ((U.What_button_Enter+1) == U._LEVELS_ANSWER[U.current_level-1].Length){
				// вызываем функциию в случае правильного ответа
				// Invoke("TrueAnswer", 2);
				TrueAnswer();
			}
		} else {
			Debug.Log("to fuck");
			// если ведена последняя буква и отвт не верен то перезагружаем сцену 
			if ((U.What_button_Enter+1) == U._LEVELS_ANSWER[U.current_level-1].Length){
				Debug.Log("fuck");
				// U.LoadScene ("_main");
			}
			// если текушие буквы не совпали, то дальше нет смысла сравнивать
			U.WHILE_TRUE_ANSWER = false;
		}
		// увеличаваем номер введенного символа 
		U.What_button_Enter++;
	}

	// введен правильный ответ  
	void TrueAnswer (){

		// обнуляем номер введенной буквы
		U.What_button_Enter = -1;
		// удаляем обьекты предыдущего уровня, если они есть
		foreach(GameObject go in U._ENTER_CHARS){
			Destroy(go);
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
