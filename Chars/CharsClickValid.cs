using UnityEngine;
using System.Collections;

public class CharsClickValid : MonoBehaviour {

	public static void Check_char (){
		// проверяем совпадает ли введеный символ с сомволом из ответа если совпали предыдущие
		if (U._FIELD_ANSWER_CHARS[U.What_button_Enter].gameObject.GetComponentInChildren<TextMesh>().text == U._LEVELS_ANSWER[U.current_level-1][U.What_button_Enter].ToString().ToUpper()
			 && U.WHILE_TRUE_ANSWER){
			// если была введена последняя буква
			if ((U.What_button_Enter+1) == U._LEVELS_ANSWER[U.current_level-1].Length){
				// обнуляем номер введенной буквы
				U.What_button_Enter = -1;
				// удаляем обьекты предыдущего уровня, если они есть
				foreach(GameObject go in U._ENTER_CHARS){
					Destroy(go);
				}
				// вызываем функциию
				TrueAnswer();
			}

		} else {
			// если ведена последняя буква и отвт не верен то перезагружаем сцену 
			if ((U.What_button_Enter+1) == U._LEVELS_ANSWER[U.current_level-1].Length){
				U.LoadScene ("_main");
			}
			// если текушие буквы не совпали, то дальше нет смысла сравнивать
			U.WHILE_TRUE_ANSWER = false;
		}
	}

	// введен правильный ответ  
	private static void TrueAnswer (){
		// выбубаем ребус
		U.TheLevel.SetActive (false);

		// переводи в начальный режим 
		U.GAME_STARTED = 0;

		// получаем открытые уровни
		string opened_lvls = PlayerPrefs.GetString("Levels");
		
		// если строка не пустая
		if (opened_lvls.Length > 0){

			
			PlayerPrefs.SetString("Levels", PlayerPrefs.GetString("Levels") + "," + U.current_level);
			
			opened_lvls = PlayerPrefs.GetString("Levels");

			// переводим из строки в числа
			string[] substrings = opened_lvls.Split(',');
			int i = 0;
			foreach (var substring in substrings) {
				int.TryParse (substring, out U.opened_levels[i]);
				i++;
			}

			string levels = "";
			for(int l = 0; l < U.opened_levels.Length; l++){
				if(U.opened_levels[l] == 0) continue;

				if(U.opened_levels[l+1] == 0){
					levels += U.opened_levels[l].ToString();
				} else{
					levels += (U.opened_levels[l].ToString() + ",");
				}

			}
			PlayerPrefs.SetString("Levels", levels);

		// если строка пустая 
		} else if (opened_lvls.Length == 0) {
			PlayerPrefs.SetString("Levels", U.current_level.ToString());
			
			U.opened_levels[0] = U.current_level;
		}

		U.Answer.SetActive (true);
	}

}
