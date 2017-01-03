using UnityEngine;
using System.Collections;

public class AllCharsClick : MonoBehaviour {

	void OnMouseDown(){
		transform.localScale += new Vector3(0.05f,0.05f,0);
	}

	void OnMouseUp(){
		transform.localScale -= new Vector3(0.05f,0.05f,0);
	}

	void OnMouseUpAsButton (){
		if (U.What_button_Enter < U._LEVELS_ANSWER[U.current_level-1].Length){
			TextMesh chr = gameObject.GetComponentInChildren<TextMesh>();
			
			U._ENTER_CHARS[U.What_button_Enter].gameObject.GetComponentInChildren<TextMesh>().text = chr.text;
			
			if (chr.text.ToString().ToUpper() == U._LEVELS_ANSWER[U.current_level-1][U.What_button_Enter].ToString().ToUpper() && U.WHILE_TRUE_ANSWER){
				
				if ((U.What_button_Enter+1) == U._LEVELS_ANSWER[U.current_level-1].Length){
					TrueAnswer();
				}

			} else {
				U.WHILE_TRUE_ANSWER = false;
			}

			U.What_button_Enter++;
		}
	}

	void TrueAnswer (){
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
