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
			
			if ((U.What_button_Enter+1) == U._LEVELS_ANSWER[U.current_level-1].Length){
				U.LoadScene ("_main");
			}

			U.WHILE_TRUE_ANSWER = false;
		}
	}

	private static void TrueAnswer (){
		U.TheLevel.SetActive (false);

		U.GAME_STARTED = 0;

		string opened_lvls = PlayerPrefs.GetString("Levels");
		
		if (opened_lvls.Length > 0){

			PlayerPrefs.SetString("Levels", PlayerPrefs.GetString("Levels") + "," + U.current_level);
			
			opened_lvls = PlayerPrefs.GetString("Levels");

			string[] substrings = opened_lvls.Split(',');
			int i = 0;
			foreach (var substring in substrings) {
				int.TryParse (substring, out U.opened_levels[i]);
				i++;
			}

		} else if (opened_lvls.Length == 0) {
			PlayerPrefs.SetString("Levels", U.current_level.ToString());
			
			U.opened_levels[0] = U.current_level;
		}

		U.Answer.SetActive (true);
	}

}
